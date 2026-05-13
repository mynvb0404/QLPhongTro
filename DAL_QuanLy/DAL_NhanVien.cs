using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_NHANVIEN : DBConnect
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        public DataTable LayDanhSachNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
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

        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
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

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        public bool XoaNhanVien(int maNV)
        {
            string query = "DELETE FROM NHANVIEN WHERE MANV = @MANV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MANV", maNV)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}