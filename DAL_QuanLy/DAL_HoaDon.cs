using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_HOADON : DBConnect
    {
        private string GetStringTrangThaiTT(TrangThaiThanhToan tt)
            => tt == TrangThaiThanhToan.DaThanhToan ? "Đã thanh toán" : "Chưa thanh toán";

        private string GetStringPhuongThucTT(PhuongThucThanhToan pt)
        {
            switch (pt)
            {
                case PhuongThucThanhToan.TienMat: return "Tiền mặt";
                case PhuongThucThanhToan.ChuyenKhoan: return "Chuyển khoản";
                case PhuongThucThanhToan.QuetMaQR: return "Quét mã QR";
                default: return "";
            }
        }

        // Lấy toàn bộ hóa đơn
        public DataTable LayDanhSachHoaDon()
        {
            return ExecuteQuery("SELECT * FROM HOADON ORDER BY NGAYLAP DESC");
        }

        // 1. Tạo hóa đơn
        public bool TaoHoaDon(DTO_HOADON hd)
        {
            string query = @"
                INSERT INTO HOADON 
                    (MAHOPDONG, NGAYLAP, TIENNUOC, TIENDIEN, TIENPHATSINH, TIENTHUENHA, TRANGTHAITT)
                VALUES 
                    (@MAHOPDONG, GETDATE(), @TIENNUOC, @TIENDIEN, @TIENPHATSINH, @TIENTHUENHA, @TRANGTHAITT)";

            SqlParameter[] p = {
                new SqlParameter("@MAHOPDONG",    hd.MAHOPDONG),
                new SqlParameter("@TIENNUOC",     hd.TIENNUOC),
                new SqlParameter("@TIENDIEN",     hd.TIENDIEN),
                new SqlParameter("@TIENPHATSINH", hd.TIENPHATSINH),
                new SqlParameter("@TIENTHUENHA",     hd.TIENTHUENHA),
                new SqlParameter("@TRANGTHAITT",  GetStringTrangThaiTT(hd.TRANGTHAITT))
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 2. Cập nhật hóa đơn
        public bool CapNhatHoaDon(DTO_HOADON hd)
        {
            string query = @"
                UPDATE HOADON SET
                    TIENNUOC     = @TIENNUOC,
                    TIENDIEN     = @TIENDIEN,
                    TIENPHATSINH = @TIENPHATSINH,
                    TIENTHUENHA = @TIENTHUENHA,
                    TRANGTHAITT  = @TRANGTHAITT
                WHERE MAHOADON = @MAHOADON";

            SqlParameter[] p = {
                new SqlParameter("@MAHOADON",     hd.MAHOADON),
                new SqlParameter("@TIENNUOC",     hd.TIENNUOC),
                new SqlParameter("@TIENDIEN",     hd.TIENDIEN),
                new SqlParameter("@TIENPHATSINH", hd.TIENPHATSINH),
                new SqlParameter("@TIENTHUENHA", hd.TIENTHUENHA),
                new SqlParameter("@TRANGTHAITT",  GetStringTrangThaiTT(hd.TRANGTHAITT))
            };
            return ExecuteNonQuery(query, p) > 0;
        }
        public bool CapNhatTrangThaiHoaDon(int maHD, TrangThaiThanhToan trangThai)
        {
            string query = "UPDATE HOADON SET TRANGTHAITT = @TrangThai WHERE MAHOADON = @MaHD";

            SqlParameter[] p = {
        new SqlParameter("@MaHD",     maHD),

        new SqlParameter("@TrangThai", GetStringTrangThaiTT(trangThai))
        };

            return ExecuteNonQuery(query, p) > 0;
        }
        // 3. Thanh toán hóa đơn 
        public bool ThanhToanHoaDon(int maHoaDon, PhuongThucThanhToan pt)
        {
            string query = @"
                UPDATE HOADON SET
                    TRANGTHAITT   = N'Đã thanh toán',
                    NGAYTHANHTOAN = GETDATE(),
                    PHUONGTHUCTT  = @PHUONGTHUCTT
                WHERE MAHOADON = @MAHOADON";

            SqlParameter[] p = {
                new SqlParameter("@MAHOADON",    maHoaDon),
                new SqlParameter("@PHUONGTHUCTT", GetStringPhuongThucTT(pt))
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 4. Xóa hóa đơn
        public bool XoaHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM HOADON WHERE MAHOADON = @MAHOADON";
            SqlParameter[] p = { new SqlParameter("@MAHOADON", maHoaDon) };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 5. Xem lịch sử theo hợp đồng
        public DataTable XemLichSuThanhToan(string maHopDong)
        {
            string query = @"
                SELECT * FROM HOADON 
                WHERE MAHOPDONG = @MAHOPDONG 
                ORDER BY NGAYLAP DESC";
            SqlParameter[] p = { new SqlParameter("@MAHOPDONG", maHopDong) };
            return ExecuteQuery(query, p);
        }
    }
}