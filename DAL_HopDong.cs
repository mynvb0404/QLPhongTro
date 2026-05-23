using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_HopDong : DBConnect
    {
        //THÊM
        public bool ThemHopDong(DTO_HopDong HD)
        {
            string QUERY = "INSERT INTO HOPDONG (MAHOPDONG, MAPHONG, MAKH, NGAYKYHD, NGAYKT, TRANGTHAIHOPDONG, THONGTINHD) " +
                           "VALUES (@MAHOPDONG, @MAPHONG, @MAKH, @NGAYKYHD, @NGAYKT, @TRANGTHAIHOPDONG, @THONGTINHD)";

            SqlParameter[] PARAMETERS = {
        new SqlParameter("@MAHOPDONG", HD.MAHOPDONG),
        new SqlParameter("@MAPHONG", HD.MAPHONG),
        new SqlParameter("@MAKH", HD.MAKH),
        new SqlParameter("@NGAYKYHD", HD.NGAYKYHD),
        new SqlParameter("@NGAYKT", HD.NGAYKT),
        new SqlParameter("@TRANGTHAIHOPDONG", HD.TRANGTHAIHOPDONG ?? (object)DBNull.Value),
        new SqlParameter("@THONGTINHD", HD.THONGTINHD ?? (object)DBNull.Value)
    };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //SỬA
        public bool SuaHopDong(DTO_HopDong HD)
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

        //XÓA
        public bool XoaHopDong(string MAHOPDONG)
        {
            string QUERY =
            "DELETE FROM HOPDONG " +
            "WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS =
            {
                new SqlParameter("@MAHOPDONG", MAHOPDONG)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //TÌM KIẾM
        public DataTable TimKiemHopDong(string KEYWORD)
        {
            string QUERY =
            "SELECT * FROM HOPDONG " +
            "WHERE MAHOPDONG LIKE @KEYWORD " +
            "OR TRANGTHAIHOPDONG LIKE @KEYWORD " +
            "OR THONGTINHD LIKE @KEYWORD";

            SqlParameter[] PARAMETERS =
            {
                new SqlParameter("@KEYWORD",
                "%" + KEYWORD + "%")
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }

        //XEM DANH SÁCH
        public DataTable LayDanhSachHopDong()
        {
            string QUERY =
            "SELECT * FROM HOPDONG";

            return ExecuteQuery(QUERY);
        }

        //LẤY THÔNG TIN
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

        //LẤY THEO PHÒNG
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

    }
}