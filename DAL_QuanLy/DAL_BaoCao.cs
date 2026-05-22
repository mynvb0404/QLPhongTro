using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_BAOCAO : DBConnect
    {
        private string GetStringLoaiBC(LoaiBaoCao loai)
        {
            switch (loai)
            {
                case LoaiBaoCao.ThongKePhong: return "Thống kê phòng";
                case LoaiBaoCao.ThongKeDoanhThu: return "Thống kê doanh thu";
                case LoaiBaoCao.ThongKeLichHen: return "Thống kê lịch hẹn";
                default: return "Khác";
            }
        }
        // 1 Thống kê phòng
        public DataTable ThongKePhong()
        {
            string query = @"SELECT 
                COUNT(*) AS TongPhong,
                SUM(CASE WHEN TRANGTHAIPHONG = N'Còn trống' THEN 1 ELSE 0 END) AS ConTrong,
                SUM(CASE WHEN TRANGTHAIPHONG = N'Đã thuê'   THEN 1 ELSE 0 END) AS DaThue,
                SUM(CASE WHEN TRANGTHAIPHONG = N'Cần ở ghép' THEN 1 ELSE 0 END) AS CanOGhep
                FROM PHONG"; 
            return ExecuteQuery(query);
        }

        // 2 Thống kê doanh thu 
        public DataTable ThongKeDoanhThu(int thang, int nam)
        {
            string query = @"SELECT 
                MONTH(NGAYLAP) AS Thang,
                YEAR(NGAYLAP)  AS Nam,
                SUM(TONGTIEN)  AS TongDoanhThu,
                COUNT(*)       AS SoHoaDon
                FROM HOADON
                WHERE TRANGTHAITT = N'Đã thanh toán'
                  AND YEAR(NGAYLAP) = @NAM
                  AND (@THANG = 0 OR MONTH(NGAYLAP) = @THANG)
                GROUP BY MONTH(NGAYLAP), YEAR(NGAYLAP)
                ORDER BY Thang"; 

            SqlParameter[] p = {
                new SqlParameter("@THANG", thang),
                new SqlParameter("@NAM",   nam)
            };
            return ExecuteQuery(query, p);
        }

        // 3 Thống kê lịch hẹn theo tháng/năm
        public DataTable ThongKeLichHen(int thang, int nam)
        {
            string query = @"SELECT
                COUNT(*) AS TongLichHen,
                SUM(CASE WHEN TRANGTHAIHEN = N'Hoàn thành' THEN 1 ELSE 0 END) AS HoanThanh,
                SUM(CASE WHEN TRANGTHAIHEN = N'Đã hủy'      THEN 1 ELSE 0 END) AS DaHuy,
                SUM(CASE WHEN TRANGTHAIHEN = N'Đã đặt'      THEN 1 ELSE 0 END) AS DaDat
                FROM LICHHEN
                WHERE (@THANG = 0 OR MONTH(THOIGIANHEN) = @THANG)
                  AND YEAR(THOIGIANHEN) = @NAM";

            SqlParameter[] p = {
                new SqlParameter("@THANG", thang),
                new SqlParameter("@NAM",   nam)
            };
            return ExecuteQuery(query, p);
        }

        // 4 Báo cáo / phản hồi từ khách thuê (bảng BAOCAO)
        public DataTable LayDanhSachBaoCao()
        {
            return ExecuteQuery("SELECT * FROM BAOCAO ORDER BY THOIGIANBC DESC");
        }

        public bool ThemBaoCao(DTO_BAOCAO bc)
        {
            // Viết hoa các cột MANV, LOAIBC, NOIDUNGBC, THOIGIANBC
            string query = @"INSERT INTO BAOCAO (MANV, LOAIBC, NOIDUNGBC, THOIGIANBC)
                             VALUES (@MANV, @LOAIBC, @NOIDUNGBC, GETDATE())"; 

            SqlParameter[] p = {
                new SqlParameter("@MANV",      bc.MANV),
                new SqlParameter("@LOAIBC",    bc.LOAIBC),
                new SqlParameter("@NOIDUNGBC", bc.NOIDUNGBC)
            };
            return ExecuteNonQuery(query, p) > 0;
        }
        public bool LuuBaoCao(DTO_BAOCAO bc)
        {
            // Các tên cột MABC không cần thêm vì nó là IDENTITY (tự tăng)
            string sql = "INSERT INTO BAOCAO (MANV, LOAIBC, NOIDUNGBC, THOIGIANBC) " +
                         "VALUES (@manv, @loaibc, @noidung, @thoigian)";

            SqlParameter[] pr = {
                new SqlParameter("@manv", bc.MANV),
                // Chuyển Enum (ThongKePhong...) thành chữ để lưu vào NVARCHAR
                new SqlParameter("@loaibc", bc.LOAIBC.ToString()),
                new SqlParameter("@noidung", bc.NOIDUNGBC),
                new SqlParameter("@thoigian", bc.THOIGIANBC)
            };

            // Thực thi và trả về true nếu số dòng bị tác động > 0
            return ExecuteNonQuery(sql, pr) > 0;
        }
    }
}