using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_KhuVuc : DBConnect
    {
        //Xem danh sách toàn bộ khu vực
        public DataTable LayDanhSachKhuVuc()
        {
            string query = "SELECT * FROM KHUVUC";
            return ExecuteQuery(query);
        }

        // Thêm khu vực mới
        public bool ThemKhuVuc(DTO_KHUVUC kv)
        {
            string query = "INSERT INTO KHUVUC (MAKV, TENKV, MANV, DCHI) VALUES (@MAKV, @TENKV, @MANV, @DCHI)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", kv.MAKV),
                new SqlParameter("@TENKV", kv.TENKV),
                new SqlParameter("@MANV", (object)kv.MANV ?? DBNull.Value),
                new SqlParameter("@DCHI", kv.DCHI)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //Sửa thông tin khu vực theo mã khu vực
        public bool SuaKhuVuc(DTO_KHUVUC kv)
        {
            string query = "UPDATE KHUVUC SET TENKV = @TENKV, MANV = @MANV, DCHI = @DCHI WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", kv.MAKV),
                new SqlParameter("@TENKV", kv.TENKV),
                new SqlParameter("@MANV", (object)kv.MANV ?? DBNull.Value),
                new SqlParameter("@DCHI", kv.DCHI)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //Xóa khu vực theo mã khu vực
        public bool XoaKhuVuc(string maKV)
        {
            string query = "DELETE FROM KHUVUC WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", maKV)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //Tìm kiếm khu vực (Tìm theo tên hoặc địa chỉ)
        public DataTable TimKiemKhuVuc(string keyword)
        {
            string query = "SELECT MAKV, TENKV, MANV, DCHI FROM KHUVUC WHERE TENKV LIKE @KEYWORD OR DCHI LIKE @KEYWORD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }


        //Kiểm tra xem Mã khu vực đã tồn tại hay chưa
        public bool KiemTraTonTai(string maKV)
        {
            string query = "SELECT COUNT(*) FROM KHUVUC WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", maKV)
            };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        //Kiểm tra xem khu vực này có chứa phòng nào không
        public bool KiemTraCoPhong(string maKV)
        {
            string query = "SELECT COUNT(*) FROM PHONG WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", maKV)
            };

            DataTable dt = ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }
    }
}