using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_KHACHTHUE : DBConnect
    {
        /// <summary>
        /// Lấy toàn bộ danh sách khách thuê
        /// </summary>
        public DataTable LayDanhSachKhachThue()
        {
            string query = "SELECT * FROM KHACHTHUE";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// Thêm khách thuê
        /// </summary>
        public bool ThemKhachThue(DTO_KHACHTHUE kh)
        {
            string query = @"INSERT INTO KHACHTHUE
                            (HOKH, TENKH, NGAYSINH, GIOITINH, CCCD, SDT, NGAYBATDAUTHUE, TRANGTHAITHUE)
                            VALUES
                            (@HOKH, @TENKH, @NGAYSINH, @GIOITINH, @CCCD, @SDT, @NGAYBATDAUTHUE, @TRANGTHAITHUE)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HOKH", kh.HOKH),
                new SqlParameter("@TENKH", kh.TENKH),
                new SqlParameter("@NGAYSINH", kh.NGAYSINH.HasValue ? kh.NGAYSINH.Value : (object)DBNull.Value),
                new SqlParameter("@GIOITINH", kh.GIOITINH ?? (object)DBNull.Value),
                new SqlParameter("@CCCD", kh.CCCD),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@NGAYBATDAUTHUE", kh.NGAYBATDAUTHUE),
                new SqlParameter("@TRANGTHAITHUE", kh.TRANGTHAITHUE)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Cập nhật thông tin khách thuê theo MAKH
        /// </summary>
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
                new SqlParameter("@GIOITINH", kh.GIOITINH ?? (object)DBNull.Value),
                new SqlParameter("@CCCD", kh.CCCD),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@NGAYBATDAUTHUE", kh.NGAYBATDAUTHUE),
                new SqlParameter("@TRANGTHAITHUE", kh.TRANGTHAITHUE)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Xóa khách thuê
        /// </summary>
        public bool XoaKhachThue(int maKH)
        {
            string query = "DELETE FROM KHACHTHUE WHERE MAKH = @MAKH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", maKH)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Tìm kiếm khách thuê
        /// </summary>
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
    }
}