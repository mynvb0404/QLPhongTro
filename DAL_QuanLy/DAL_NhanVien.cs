using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_NhanVien: DBConnect
    {
        // Lấy danh sách nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            string query = @"SELECT *, 
                     (SELECT TENDANGNHAP FROM TAIKHOAN WHERE TAIKHOAN.MANV = NHANVIEN.MANV) AS TENDANGNHAP,
                     (SELECT MATKHAU FROM TAIKHOAN WHERE TAIKHOAN.MANV = NHANVIEN.MANV) AS MATKHAU
                     FROM NHANVIEN";
            return ExecuteQuery(query);
        }

        public string ThemNhanVienVaTaiKhoan(DTO_NhanVien nv, string tenDN, string matKhau)
        {
            string query = @" DECLARE @InsertedRows TABLE (NewMANV INT);

                              INSERT INTO NHANVIEN (HONV, TENNV, SDT, EMAIL, CHUCVU)
                              OUTPUT INSERTED.MANV INTO @InsertedRows
                              VALUES (@HoNV, @TenNV, @SDT, @Email, @ChucVu);

                              DECLARE @NewMANV INT;
                              SELECT @NewMANV = NewMANV FROM @InsertedRows;

                              INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU, LOAITK, MANV, MAKH)
                              VALUES (@TenDN, @MatKhau, 'NV', @NewMANV, NULL);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoNV", nv.HONV),
                new SqlParameter("@TenNV", nv.TENNV),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@Email", nv.EMAIL),
                new SqlParameter("@ChucVu", nv.CHUCVU),
        
                new SqlParameter("@TenDN", tenDN),
                new SqlParameter("@MatKhau", matKhau)
            };

            try
            {
                int rowsAffected = ExecuteNonQuery(query, parameters);

                return rowsAffected > 0 ? "THÀNH CÔNG" : "Thất bại: Không có dữ liệu nào được thêm.";
            }
            catch (Exception ex)
            {
                return "Lỗi database hoặc trùng tên đăng nhập: " + ex.Message;
            }
        }
        //Thêm nhân viên
        public int ThemNhanVien(DTO_NhanVien nv)
        {
            string query = @"INSERT INTO NHANVIEN (HONV, TENNV, SDT, EMAIL, CHUCVU) 
                    OUTPUT INSERTED.MANV
                    VALUES (@HONV, @TENNV, @SDT, @EMAIL, @CHUCVU)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HONV", nv.HONV),
                new SqlParameter("@TENNV", nv.TENNV),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@EMAIL", nv.EMAIL),
                new SqlParameter("@CHUCVU", nv.CHUCVU)
            };

            DBConnect db = new DBConnect();
            object result = db.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }
        // Sửa thông tin nhân viên
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            string query = "UPDATE NHANVIEN SET HONV = @HONV, TENNV = @TENNV, SDT = @SDT, EMAIL = @EMAIL, CHUCVU = @CHUCVU WHERE MANV = @MANV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MANV", nv.MANV),
                new SqlParameter("@HONV", nv.HONV),
                new SqlParameter("@TENNV", nv.TENNV),
                new SqlParameter("@SDT", nv.SDT ?? (object)DBNull.Value),
                new SqlParameter("@EMAIL", nv.EMAIL ?? (object)DBNull.Value),
                new SqlParameter("@CHUCVU", nv.CHUCVU ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa nhân viên
        public bool XoaNhanVien(int maNV)
        {
            string query = "DELETE FROM NHANVIEN WHERE MANV = @MANV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MANV", maNV)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // Tìm kiếm nhân viên theo từ khóa
        public DataTable TimKiemNhanVien(string keyword)
        {
            string query = @"SELECT *, 
                     (SELECT TENDANGNHAP FROM TAIKHOAN WHERE TAIKHOAN.MANV = NHANVIEN.MANV) AS TENDANGNHAP,
                     (SELECT MATKHAU FROM TAIKHOAN WHERE TAIKHOAN.MANV = NHANVIEN.MANV) AS MATKHAU
                     FROM NHANVIEN
                     WHERE HONV LIKE @KEYWORD 
                        OR TENNV LIKE @KEYWORD 
                        OR SDT LIKE @KEYWORD
                        OR MANV IN (SELECT MANV FROM TAIKHOAN WHERE TENDANGNHAP LIKE @KEYWORD)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }
    }
}