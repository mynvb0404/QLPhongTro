using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_NHANVIEN : DBConnect
    {
        /// Lấy danh sách nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN";
            return ExecuteQuery(query);
        }

        /// Thêm nhân viên
        public bool ThemNhanVien(DTO_NHANVIEN nv)
        {
            string query = @"INSERT INTO NHANVIEN
                            (HONV, TENNV, SDT, EMAIL, CHUCVU)
                            VALUES
                            (@HONV, @TENNV, @SDT, @EMAIL, @CHUCVU)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HONV", nv.HONV),
                new SqlParameter("@TENNV", nv.TENNV),
                new SqlParameter("@SDT", nv.SDT ?? (object)DBNull.Value),
                new SqlParameter("@EMAIL", nv.EMAIL ?? (object)DBNull.Value),
                new SqlParameter("@CHUCVU", nv.CHUCVU ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// Sửa thông tin nhân viên
        public bool SuaNhanVien(DTO_NHANVIEN nv)
        {
            string query = @"UPDATE NHANVIEN
                             SET HONV = @HONV,
                                 TENNV = @TENNV,
                                 SDT = @SDT,
                                 EMAIL = @EMAIL,
                                 CHUCVU = @CHUCVU
                             WHERE MANV = @MANV";

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

        /// Xóa nhân viên
        public bool XoaNhanVien(int maNV)
        {
            string query = "DELETE FROM NHANVIEN WHERE MANV = @MANV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MANV", maNV)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// Tìm kiếm nhân viên theo từ khóa
        public DataTable TimKiemNhanVien(string keyword)
        {
            string query = @"SELECT * FROM NHANVIEN 
                             WHERE HONV LIKE @keyword OR TENNV LIKE @keyword OR SDT LIKE @keyword OR CHUCVU LIKE @keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };
            return ExecuteQuery(query, parameters);
        }

     
        // Kiểm tra trùng Số điện thoại 
        public bool KiemTraTrungSDT(string sdt)
        {
            string sql = "SELECT COUNT(*) FROM NHANVIEN WHERE SDT = @SDT";
            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@SDT", sdt) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra trùng Email 
        public bool KiemTraTrungEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM NHANVIEN WHERE EMAIL = @EMAIL";
            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@EMAIL", email) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra nhân viên có đang quản lý khu vực nào không (Dành cho ràng buộc FOREIGN KEY)
        public bool KiemTraNhanVienDangQuanLy(int maNV)
        {
            string sql = "SELECT COUNT(*) FROM KHUVUC WHERE MANV = @MANV";
            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@MANV", maNV) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }
    }
}