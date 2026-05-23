using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_KHACHTHUE : DBConnect
    {
        private string GetStringGioiTinh(GioiTinh gt)
        {
            return gt == GioiTinh.Nam ? "Nam" : "Nữ";
        }

        private string GetStringTrangThaiThue(TrangThaiKhachThue tt)
        {
            return tt == TrangThaiKhachThue.DangThue ? "Đang thuê" : "Đã trả phòng";
        }

        /// Lấy toàn bộ danh sách khách thuê
        public DataTable LayDanhSachKhachThue()
        {
            string query = "SELECT * FROM KHACHTHUE";
            return ExecuteQuery(query);
        }

        /// Thêm khách thuê
        //public bool ThemKhachThue(DTO_KHACHTHUE kh)
        //{
        //    string query = @"INSERT INTO KHACHTHUE
        //                    (HOKH, TENKH, NGAYSINH, GIOITINH, CCCD, SDT, NGAYBATDAUTHUE, TRANGTHAITHUE)
        //                    VALUES
        //                    (@HOKH, @TENKH, @NGAYSINH, @GIOITINH, @CCCD, @SDT, @NGAYBATDAUTHUE, @TRANGTHAITHUE)";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@HOKH", kh.HOKH),
        //        new SqlParameter("@TENKH", kh.TENKH),
        //        new SqlParameter("@NGAYSINH", kh.NGAYSINH.HasValue ? kh.NGAYSINH.Value : (object)DBNull.Value),
        //        new SqlParameter("@GIOITINH", GetStringGioiTinh(kh.GIOITINH ?? GioiTinh.Nam)),
        //        new SqlParameter("@CCCD", kh.CCCD),
        //        new SqlParameter("@SDT", kh.SDT),
        //        new SqlParameter("@NGAYBATDAUTHUE", kh.NGAYBATDAUTHUE),
        //        new SqlParameter("@TRANGTHAITHUE", GetStringTrangThaiThue(kh.TRANGTHAITHUE))
        //    };

        //    return ExecuteNonQuery(query, parameters) > 0;
        //}

        public bool ThemKhachThue(DTO_KHACHTHUE kh, string tenDangNhap, string matKhau)
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

        /// Cập nhật thông tin khách thuê theo MAKH
        public bool SuaKhachThue(DTO_KHACHTHUE kh)
        {
            string query = @"UPDATE KHACHTHUE
                             SET HOKH = @HOKH,
                                 TENKH = @TENKH,
                                 NGAYSINH = @NGAYSINH,
                                 GIOITINH = @GIOITINH,
                                 CCCD = @CCCD,
                                 SDT = @SDT,
                                 NGAYBATDAUTHUE = @NGAYBATDAUTHUE,
                                 TRANGTHAITHUE = @TRANGTHAITHUE
                             WHERE MAKH = @MAKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", kh.MAKH),
                new SqlParameter("@HOKH", kh.HOKH),
                new SqlParameter("@TENKH", kh.TENKH),
                new SqlParameter("@NGAYSINH", kh.NGAYSINH.HasValue ? kh.NGAYSINH.Value : (object)DBNull.Value),
                new SqlParameter("@GIOITINH", GetStringGioiTinh(kh.GIOITINH ?? GioiTinh.Nam)),
                new SqlParameter("@CCCD", kh.CCCD),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@NGAYBATDAUTHUE", kh.NGAYBATDAUTHUE),
                new SqlParameter("@TRANGTHAITHUE", GetStringTrangThaiThue(kh.TRANGTHAITHUE))
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }


        /// Xóa khách thuê
        public bool XoaKhachThue(int maKH)
        {
            string query = "DELETE FROM KHACHTHUE WHERE MAKH = @MAKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", maKH)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// Tìm kiếm khách thuê
        public DataTable TimKiemKhachThue(string keyword)
        {
            string query = @"SELECT *
                             FROM KHACHTHUE
                             WHERE HOKH LIKE @KEYWORD
                                OR TENKH LIKE @KEYWORD
                                OR CCCD LIKE @KEYWORD
                                OR SDT LIKE @KEYWORD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }

        /// Xem thông tin chi tiết một khách thuê theo mã
        public DataTable LayThongTinKhachThue(int maKH)
        {
            string query = "SELECT * FROM KHACHTHUE WHERE MAKH = @MAKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", maKH)
            };

            return ExecuteQuery(query, parameters);
        }

        public static GioiTinh ParseGioiTinh(string gt)
        {
            return gt == "Nam" ? GioiTinh.Nam : GioiTinh.Nu;
        }

        public static TrangThaiKhachThue ParseTrangThaiThue(string tt)
        {
            return tt == "Đang thuê" ? TrangThaiKhachThue.DangThue : TrangThaiKhachThue.DaTraPhong;
        }

        //  Kiểm tra trùng số CCCD
        public bool KiemTraTrungCCCD(string cccd)
        {
            string sql = "SELECT COUNT(*) FROM KHACHTHUE WHERE CCCD = @CCCD";

            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@CCCD", cccd) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra trùng Số điện thoại
        public bool KiemTraTrungSDT(string sdt)
        {
            string sql = "SELECT COUNT(*) FROM KHACHTHUE WHERE SDT = @SDT";

            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@SDT", sdt) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra khách thuê có đang trong hợp đồng nào không (Dùng trước khi Xóa)
        public bool KiemTraCoHopDong(int maKH)
        {
            string sql = "SELECT COUNT(*) FROM HOPDONG WHERE MAKH = @MAKH";

            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@MAKH", maKH) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }
    }
}