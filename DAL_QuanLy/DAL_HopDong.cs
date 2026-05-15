using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_HopDong : DBConnect
    {
        //Thêm hợp đồng
        public bool ThemHopDong(DTO_HopDong HD)
        {
            string QUERY = "INSERT INTO HOPDONG (MAPHONG, MAKH, NGAYKYHD, NGAYKT, TRANGTHAIHOPDONG, THONGTINHD)  VALUES (@MAPHONG, @MAKH, @NGAYKYHD, @NGAYKT, @TRANGTHAIHOPDONG, @THONGTINHD)";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", HD.MAPHONG),
                new SqlParameter("@MAKH", HD.MAKH),
                new SqlParameter("@NGAYKYHD", HD.NGAYKYHD == default ? DateTime.Now : HD.NGAYKYHD),
                new SqlParameter("@NGAYKT", HD.NGAYKT),
                new SqlParameter("@TRANGTHAIHOPDONG", HD.TRANGTHAIHOPDONG),
                new SqlParameter("@THONGTINHD", HD.THONGTINHD)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //Sửa hợp đồng
        public bool SuaHopDong(DTO_HopDong HD)
        {
            string QUERY = "UPDATE HOPDONG SET MAPHONG = @MAPHONG, MAKH = @MAKH, NGAYKYHD = @NGAYKYHD, NGAYKT = @NGAYKT, TRANGTHAIHOPDONG = @TRANGTHAIHOPDONG, THONGTINHD = @THONGTINHD WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS = new SqlParameter[]
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

        //Xóa hợp đồng
        public bool XoaHopDong(int MAHOPDONG)
        {
            string QUERY = "DELETE FROM HOPDONG WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOPDONG", MAHOPDONG)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        public DataTable TimKiemHopDong(string KEYWORD)
        {
            string QUERY = "SELECT * FROM HOPDONG WHERE THONGTINHD LIKE @KEYWORD OR TRANGTHAIHOPDONG LIKE @KEYWORD OR CAST(MAHOPDONG AS NVARCHAR) LIKE @KEYWORD";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@KEYWORD", "%" + KEYWORD + "%")
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }

        // Lấy thông tin chi tiết một hợp đồng 
        public DataTable LayThongTinHopDong(int MAHOPDONG)
        {
            string QUERY = "SELECT * FROM HOPDONG WHERE MAHOPDONG = @MAHOPDONG";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOPDONG", MAHOPDONG)
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }

        // Lấy danh sách hợp đồng theo phòng
        public DataTable LayHopDongTheoPhong(int MAPHONG)
        {
            string QUERY = "SELECT * FROM HOPDONG WHERE MAPHONG = @MAPHONG";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", MAPHONG)
            };
            return ExecuteQuery(QUERY, PARAMETERS);
        }
    }
}