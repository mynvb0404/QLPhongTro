using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_KhuVuc : DBConnect
    {
        // 1. Xem danh sách toàn bộ khu vực
        public DataTable LayDanhSachKhuVuc()
        {
            string query = "SELECT * FROM KHUVUC";
            return ExecuteQuery(query);
        }

        // 2. Thêm khu vực mới
        public bool ThemKhuVuc(DTO_KhuVuc kv)
        {
            string query = "INSERT INTO KHUVUC (MAKV, TENKV, MANV, DCHI) VALUES (@MAKV, @TENKV, @MANV, @DCHI)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", kv.MAKV),
                new SqlParameter("@TENKV", kv.TENKV),
                new SqlParameter("@MANV", kv.MANV),
                new SqlParameter("@DCHI", kv.DCHI)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 3. Sửa thông tin khu vực theo mã khu vực
        public bool SuaKhuVuc(DTO_KhuVuc kv)
        {
            string query = "UPDATE KHUVUC SET TENKV = @TENKV, MANV = @MANV, DCHI = @DCHI WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", kv.MAKV),
                new SqlParameter("@TENKV", kv.TENKV),
                new SqlParameter("@MANV", kv.MANV),
                new SqlParameter("@DCHI", kv.DCHI)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 4. Xóa khu vực theo mã khu vực
        public bool XoaKhuVuc(string maKV)
        {
            string query = "DELETE FROM KHUVUC WHERE MAKV = @MAKV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKV", maKV)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 5. Tìm kiếm khu vực (Tìm theo tên hoặc địa chỉ)
        public DataTable TimKiemKhuVuc(string keyword)
        {
            string query = "SELECT MAKV, TENKV, MANV, DCHI FROM KHUVUC WHERE TENKV LIKE @KEYWORD OR DCHI LIKE @KEYWORD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }
    }
}