using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_KhachHang : DBConnect
    {
        public DataTable LayDanhSachKhachThue()
        {
            string query = @"SELECT *, 
                     (SELECT TENDANGNHAP FROM TAIKHOAN WHERE TAIKHOAN.MAKH = KHACHTHUE.MAKH) AS TENDANGNHAP,
                     (SELECT MATKHAU FROM TAIKHOAN WHERE TAIKHOAN.MAKH = KHACHTHUE.MAKH) AS MATKHAU
                     FROM KHACHTHUE";
            return ExecuteQuery(query);
        }

        public bool ThemKhachThue(DTO_KhachHang kh, string tenDangNhap, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(_conn.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string queryKhach = @"INSERT INTO KHACHTHUE 
                                    (HOKH, TENKH, NGAYSINH, GIOITINH, CCCD, SDT, NGAYBATDAUTHUE, TRANGTHAITHUE)
                                    OUTPUT INSERTED.MAKH
                                    VALUES (@HOKH, @TENKH, @NGAYSINH, @GIOITINH, @CCCD, @SDT, @NGAYBATDAUTHUE, @TRANGTHAITHUE)";

                        int newMaKH = 0;
                        using (SqlCommand cmdKhach = new SqlCommand(queryKhach, conn, trans))
                        {
                            cmdKhach.Parameters.AddWithValue("@HOKH", kh.HOKH);
                            cmdKhach.Parameters.AddWithValue("@TENKH", kh.TENKH);
                            cmdKhach.Parameters.AddWithValue("@NGAYSINH", kh.NGAYSINH.HasValue ? kh.NGAYSINH.Value : (object)DBNull.Value);
                            cmdKhach.Parameters.AddWithValue("@GIOITINH", kh.GIOITINH ?? (object)DBNull.Value);
                            cmdKhach.Parameters.AddWithValue("@CCCD", kh.CCCD ?? (object)DBNull.Value);
                            cmdKhach.Parameters.AddWithValue("@SDT", kh.SDT);
                            cmdKhach.Parameters.AddWithValue("@NGAYBATDAUTHUE", kh.NGAYBATDAUTHUE);
                            cmdKhach.Parameters.AddWithValue("@TRANGTHAITHUE", kh.TRANGTHAITHUE);

                            newMaKH = Convert.ToInt32(cmdKhach.ExecuteScalar());
                        }

                        string generatedMATK = "KH" + newMaKH;

                        string queryTaiKhoan = @"INSERT INTO TAIKHOAN (MATK, TENDANGNHAP, MATKHAU, LOAITK, MAKH, MANV) 
                                         VALUES (@MATK, @Username, @Password, 'KH', @MAKH, NULL)";

                        using (SqlCommand cmdTK = new SqlCommand(queryTaiKhoan, conn, trans))
                        {
                            cmdTK.Parameters.AddWithValue("@MATK", generatedMATK);
                            cmdTK.Parameters.AddWithValue("@Username", tenDangNhap);
                            cmdTK.Parameters.AddWithValue("@Password", matKhau);
                            cmdTK.Parameters.AddWithValue("@MAKH", newMaKH);

                            cmdTK.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Console.WriteLine("Lỗi Transaction ThemKhachThue: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool SuaKhachThue(DTO_KhachHang kh)
        {
            string query = @"UPDATE KHACHTHUE
                             SET HOKH = @HOKH,
                                 TENKH = @TENKH,
                                 SDT = @SDT
                             WHERE MAKH = @MAKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", kh.MAKH),
                new SqlParameter("@HOKH", kh.HOKH),
                new SqlParameter("@TENKH", kh.TENKH),
                new SqlParameter("@SDT", kh.SDT)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool XoaKhachThue(int maKH)
        {
            string queryDeleteTK = "DELETE FROM TAIKHOAN WHERE MAKH = @MAKH";
            string queryDeleteKH = "DELETE FROM KHACHTHUE WHERE MAKH = @MAKH";

            SqlParameter[] param1 = { new SqlParameter("@MAKH", maKH) };
            SqlParameter[] param2 = { new SqlParameter("@MAKH", maKH) };

            ExecuteNonQuery(queryDeleteTK, param1);
            return ExecuteNonQuery(queryDeleteKH, param2) > 0;
        }

        // Tìm kiếm khách thuê
        public DataTable TimKiemKhachThue(string keyword)
        {
            string query = @"SELECT *, 
                     (SELECT TENDANGNHAP FROM TAIKHOAN WHERE TAIKHOAN.MAKH = KHACHTHUE.MAKH) AS TENDANGNHAP,
                     (SELECT MATKHAU FROM TAIKHOAN WHERE TAIKHOAN.MAKH = KHACHTHUE.MAKH) AS MATKHAU
                     FROM KHACHTHUE
                     WHERE HOKH LIKE @KEYWORD 
                        OR TENKH LIKE @KEYWORD 
                        OR SDT LIKE @KEYWORD
                        OR MAKH IN (SELECT MAKH FROM TAIKHOAN WHERE TENDANGNHAP LIKE @KEYWORD)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }
        public bool KiemTraTrungSDT(string sdt)
        {
            string query = "SELECT COUNT(*) FROM KHACHTHUE WHERE SDT = @SDT";
            SqlParameter[] parameters = { new SqlParameter("@SDT", sdt) };
            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        public bool KiemTraCoHopDong(int maKH)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM HOPDONG WHERE MAKH = @MAKH";
                SqlParameter[] parameters = { new SqlParameter("@MAKH", maKH) };
                object result = ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}