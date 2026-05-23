using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_HOPDONG : DBConnect
    {
        private string GetStringTrangThaiHD(TrangThaiHopDong tt)
        {
            return tt == TrangThaiHopDong.ConHieuLuc ? "Còn hiệu lực" : "Hết hiệu lực";
        }

        public DataTable LayDanhSachHopDong()
        {
            return ExecuteQuery("SELECT * FROM HOPDONG");
        }

        public DataTable LayHopDongConHieuLuc()
        {
            string query = @"
                SELECT 
                    HD.MAHOPDONG,
                    HD.MAHOPDONG + N' - Phòng ' + P.TENPHONG AS HIENTHIHD
                FROM HOPDONG HD
                INNER JOIN PHONG P ON HD.MAPHONG = P.MAPHONG
                WHERE HD.TRANGTHAIHOPDONG = N'Còn hiệu lực'
                ORDER BY HD.MAHOPDONG";
            return ExecuteQuery(query);
        }
        public DataTable LayThongTinHopDong(
           string MAHOPDONG)
        {
            string QUERY =
            "SELECT * FROM HOPDONG " +
            "WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS =
            {
                new SqlParameter("@MAHOPDONG",
                MAHOPDONG)
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }

        public DataTable LayHopDongTheoPhong(
           int MAPHONG)
        {
            string QUERY =
            "SELECT * FROM HOPDONG " +
            "WHERE MAPHONG = @MAPHONG";

            SqlParameter[] PARAMETERS =
            {
                new SqlParameter("@MAPHONG",
                MAPHONG)
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }
        // 1 Thêm hợp đồng
        public bool ThemHopDong(DTO_HOPDONG hd)
        {
            string query = @"INSERT INTO HOPDONG (MAPHONG, MAKH, NGAYKT, TRANGTHAIHOPDONG, THONGTINHD)
                             VALUES (@MAPHONG, @MAKH, @NGAYKT, @TRANGTHAIHOPDONG, @THONGTINHD)";

            SqlParameter[] p = {
                new SqlParameter("@MAPHONG",          hd.MAPHONG),
                new SqlParameter("@MAKH",             hd.MAKH),
                new SqlParameter("@NGAYKT",           hd.NGAYKT),
                new SqlParameter("@TRANGTHAIHOPDONG", GetStringTrangThaiHD(hd.TRANGTHAIHOPDONG)),
                new SqlParameter("@THONGTINHD",       hd.THONGTINHD)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 2 Sửa thông tin hợp đồng
        public bool SuaHopDong(DTO_HOPDONG HD)
        {
            string QUERY =
            "UPDATE HOPDONG SET " +
            "MAPHONG = @MAPHONG, " +
            "MAKH = @MAKH, " +
            "NGAYKYHD = @NGAYKYHD, " +
            "NGAYKT = @NGAYKT, " +
            "TRANGTHAIHOPDONG = @TRANGTHAIHOPDONG, " +
            "THONGTINHD = @THONGTINHD " +
            "WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS =
            {
                new SqlParameter("@MAHOPDONG", HD.MAHOPDONG),

                new SqlParameter("@MAPHONG", HD.MAPHONG),

                new SqlParameter("@MAKH", HD.MAKH),

                new SqlParameter("@NGAYKYHD", HD.NGAYKYHD),

                new SqlParameter("@NGAYKT", HD.NGAYKT),

                new SqlParameter("@TRANGTHAIHOPDONG", HD.TRANGTHAIHOPDONG),

                new SqlParameter("@THONGTINHD", HD.THONGTINHD)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        // 3 Xóa hợp đồng
        public bool XoaHopDong(int maHopDong)
        {
            string query = "DELETE FROM HOPDONG WHERE MAHOPDONG = @MAHOPDONG";
            SqlParameter[] p = { new SqlParameter("@MAHOPDONG", maHopDong) };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 4 Tìm kiếm hợp đồng
        public DataTable TimKiemHopDong(string tuKhoa)
        {
            string query = @"SELECT * FROM HOPDONG
                             WHERE CAST(MAHOPDONG AS VARCHAR) LIKE @TK
                                OR CAST(MAKHACH AS VARCHAR) LIKE @TK
                                OR THONGTINHD LIKE @TK
                                OR TRANGTHAIHOPDONG LIKE @TK";
            SqlParameter[] p = {
                new SqlParameter("@TK", "%" + tuKhoa + "%")
            };
            return ExecuteQuery(query, p);
        }

        // 5 Xem thông tin hợp đồng theo mã
        public DataTable XemHopDong(int maHopDong)
        {
            string query = "SELECT * FROM HOPDONG WHERE MAHOPDONG = @MAHOPDONG";
            SqlParameter[] p = { new SqlParameter("@MAHOPDONG", maHopDong) };
            return ExecuteQuery(query, p);
        }

        public bool CapNhatTrangThai(int maHopDong, TrangThaiHopDong trangThai)
        {
            string query = "UPDATE HOPDONG SET TRANGTHAIHOPDONG = @TT WHERE MAHOPDONG = @MA";
            SqlParameter[] p = {
                new SqlParameter("@TT", GetStringTrangThaiHD(trangThai)),
                new SqlParameter("@MA", maHopDong)
            };
            return ExecuteNonQuery(query, p) > 0;
        }
    }
}