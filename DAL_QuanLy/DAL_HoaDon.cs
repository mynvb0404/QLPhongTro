using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_HoaDon : DBConnect
    {
        //Tạo hóa đơn
        public bool TaoHoaDon(DTO_HoaDon HD)
        {
            string QUERY = "INSERT INTO HOADON (MAHOPDONG, NGAYLAP, TIENNUOC, TIENDIEN, TIENPHATSINH, TRANGTHAITT) VALUES (@MAHOPDONG, @NGAYLAP, @TIENNUOC, @TIENDIEN, @TIENPHATSINH, @TRANGTHAITT)";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOPDONG", HD.MAHOPDONG),
                new SqlParameter("@NGAYLAP", HD.NGAYLAP == default ? DateTime.Now : HD.NGAYLAP),
                new SqlParameter("@TIENNUOC", HD.TIENNUOC),
                new SqlParameter("@TIENDIEN", HD.TIENDIEN),
                new SqlParameter("@TIENPHATSINH", HD.TIENPHATSINH),
                new SqlParameter("@TRANGTHAITT", HD.TRANGTHAITT)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //Cập nhật hóa đơn
        public bool CapNhatHoaDon(DTO_HoaDon HD)
        {
            string QUERY = "UPDATE HOADON SET TIENNUOC = @TIENNUOC, TIENDIEN = @TIENDIEN, TIENPHATSINH = @TIENPHATSINH, TRANGTHAITT = @TRANGTHAITT WHERE MAHOADON = @MAHOADON";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOADON", HD.MAHOADON),
                new SqlParameter("@TIENNUOC", HD.TIENNUOC),
                new SqlParameter("@TIENDIEN", HD.TIENDIEN),
                new SqlParameter("@TIENPHATSINH", HD.TIENPHATSINH),
                new SqlParameter("@TRANGTHAITT", HD.TRANGTHAITT)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //Xác nhận thanh toán
        public bool XacNhanThanhToan(int MAHOADON, string PHUONGTHUC)
        {
            string QUERY = "UPDATE HOADON SET TRANGTHAITT = N'Đã thanh toán' WHERE MAHOADON = @MAHOADON";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOADON", MAHOADON)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //Xem lịch sử thanh toán
        public DataTable LayLichSuThanhToan(int MAHOPDONG)
        {
            string QUERY = "SELECT * FROM HOADON WHERE MAHOPDONG = @MAHOPDONG ORDER BY NGAYLAP DESC";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOPDONG", MAHOPDONG)
            };

            return ExecuteQuery(QUERY, PARAMETERS);
        }

        //Cập nhật trạng thái
        public bool CapNhatTrangThaiHoaDon(int MAHOADON, string TRANGTHAI)
        {
            string QUERY = "UPDATE HOADON SET TRANGTHAITT = @TRANGTHAI WHERE MAHOADON = @MAHOADON";

            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@TRANGTHAI", TRANGTHAI),
                new SqlParameter("@MAHOADON", MAHOADON)
            };

            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //lấy chi tiết hóa đơn
        public DataTable LayChiTietHoaDon(int MAHOADON)
        {
            string QUERY = "SELECT * FROM HOADON WHERE MAHOADON = @MAHOADON";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAHOADON", MAHOADON)
            };
            return ExecuteQuery(QUERY, PARAMETERS);
        }
    }
}