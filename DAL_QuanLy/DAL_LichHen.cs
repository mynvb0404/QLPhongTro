using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_LICHHEN : DBConnect
    {
        private string GetStringTrangThai(TrangThaiLichHen tth)
        {
            switch (tth)
            {
                case TrangThaiLichHen.DaDat: return "Đã đặt";
                case TrangThaiLichHen.DaHuy: return "Đã hủy";
                case TrangThaiLichHen.HoanThanh: return "Hoàn thành";
                default: return "Đã đặt";
            }
        }
        // Lấy toàn bộ danh sách lịch hẹn
        public DataTable LayDanhSachLichHen()
        {
            string query = "SELECT * FROM LICHHEN";
            return ExecuteQuery(query);
        }

        // 1 Thêm lịch hẹn
        public bool ThemLichHen(DTO_LICHHEN lh)
        {
            string query = @"INSERT INTO LICHHEN (MAKH, MANV, MAPHONG, THOIGIANHEN, TRANGTHAIHEN, NOIDUNGHEN)
                             VALUES (@MAKH, @MANV, @MAPHONG, @THOIGIANHEN, @TRANGTHAIHEN, @NOIDUNGHEN)";
            SqlParameter[] p = {
                new SqlParameter("@MAKH",        lh.MAKH),
                new SqlParameter("@MANV",        lh.MANV),
                new SqlParameter("@MAPHONG",     lh.MAPHONG),
                new SqlParameter("@THOIGIANHEN", lh.THOIGIANHEN),
                new SqlParameter("@TRANGTHAIHEN", GetStringTrangThai(lh.TRANGTHAIHEN)),
                new SqlParameter("@NOIDUNGHEN", lh.NOIDUNGHEN!)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 2 Sửa thông tin lịch hẹn
        public bool SuaLichHen(DTO_LICHHEN lh)
        {
            string query = @"UPDATE LICHHEN SET
                            MAKH = @MAKH,
                            MANV = @MANV,
                            MAPHONG = @MAPHONG,
                            THOIGIANHEN = @THOIGIANHEN,
                            TRANGTHAIHEN = @TRANGTHAIHEN,
                            NOIDUNGHEN = @NOIDUNGHEN,
                            THOIGIANCAPNHAT = GETDATE()
                            WHERE MALH = @MALH";
            SqlParameter[] p = {
                new SqlParameter("@MALH",        lh.MALH),
                new SqlParameter("@MAKH",        lh.MAKH),
                new SqlParameter("@MANV",        lh.MANV),
                new SqlParameter("@MAPHONG",     lh.MAPHONG),
                new SqlParameter("@THOIGIANHEN", lh.THOIGIANHEN),
                new SqlParameter("@TRANGTHAIHEN", GetStringTrangThai(lh.TRANGTHAIHEN)),
                new SqlParameter("@NOIDUNGHEN", lh.NOIDUNGHEN!)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 3 Xóa lịch hẹn
        public bool XoaLichHen(int maLH)
        {
            string query = "DELETE FROM LICHHEN WHERE MALH = @MALH";
            SqlParameter[] p = { new SqlParameter("@MALH", maLH) };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 4 Xem chi tiết lịch hẹn 
        public DataTable XemChiTietLichHen(int maLH)
        {
            string query = @"SELECT 
                        LH.MALH, 
                        K.TENKH, 
                        N.TENNV, 
                        P.TENPHONG, 
                        LH.THOIGIANHEN, 
                        LH.TRANGTHAIHEN, 
                        LH.NOIDUNGHEN,
                        LH.THOIGIANTAO
                    FROM LICHHEN LH
                    JOIN KHACHTHUE K ON LH.MAKH = K.MAKH
                    JOIN NHANVIEN N ON LH.MANV = N.MANV
                    JOIN PHONG P ON LH.MAPHONG = P.MAPHONG
                    WHERE LH.MALH = @MALH";

            return ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@MALH", maLH) });
        }

        // 5 Cập nhật trạng thái lịch hẹn
        public bool CapNhatTrangThaiLichHen(int maLH, TrangThaiLichHen trangThai)
        {
            string query = @"UPDATE LICHHEN SET 
                            TRANGTHAIHEN = @TRANGTHAIHEN,
                            THOIGIANCAPNHAT = GETDATE()
                            WHERE MALH = @MALH";
            SqlParameter[] p = {
                new SqlParameter("@TRANGTHAIHEN", GetStringTrangThai(trangThai)),
                new SqlParameter("@MALH",         maLH)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

         // Thống kê lịch hẹn theo tháng và năm
        public DataTable ThongKeLichHen(int thang, int nam)
        {
            string query = @"SELECT TRANGTHAIHEN, COUNT(*) AS SOLUONG 
                    FROM LICHHEN 
                    WHERE MONTH(THOIGIANHEN) = @THANG AND YEAR(THOIGIANHEN) = @NAM
                    GROUP BY TRANGTHAIHEN";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@THANG", thang),
        new SqlParameter("@NAM", nam)
            };

            return ExecuteQuery(query, parameters);
        }
    }
}