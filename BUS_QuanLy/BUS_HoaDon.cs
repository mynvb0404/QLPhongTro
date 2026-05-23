using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_HoaDon
    {
        private DAL_HOADON dalHoaDon = new DAL_HOADON();

        // Lấy danh sách hóa đơn
        public DataTable LayDanhSachHoaDon() => dalHoaDon.LayDanhSachHoaDon();

        // 1. Tạo hóa đơn
        public string TaoHoaDon(DTO_HOADON hd)
        {
            if (string.IsNullOrWhiteSpace(hd.MAHOPDONG))
                return "Vui lòng chọn mã hợp đồng!";
            if (hd.TIENNUOC < 0 || hd.TIENDIEN < 0 || hd.TIENPHATSINH < 0)
                return "Số tiền không được là số âm!";

            hd.TRANGTHAITT = TrangThaiThanhToan.ChuaThanhToan;
            return dalHoaDon.TaoHoaDon(hd) ? "" : "Lỗi: Không thể tạo hóa đơn!";
        }

        // 2. Cập nhật hóa đơn
        public string CapNhatHoaDon(DTO_HOADON hd)
        {
            if (hd.MAHOADON <= 0) return "Mã hóa đơn không hợp lệ!";
            if (hd.TIENNUOC < 0 || hd.TIENDIEN < 0 || hd.TIENPHATSINH < 0)
                return "Số tiền không hợp lệ!";
            return dalHoaDon.CapNhatHoaDon(hd) ? "" : "Cập nhật thất bại!";
        }

        // 3. Cập nhật trạng thái 
        public string CapNhatTrangThaiHoaDon(int maHD, TrangThaiThanhToan trangThai)
        {
            if (maHD <= 0) return "Mã hóa đơn không hợp lệ!";
            return dalHoaDon.CapNhatTrangThaiHoaDon(maHD, trangThai)
                ? ""
                : "Cập nhật trạng thái thất bại!";
        }

        // 3. Thanh toán
        public string ThanhToanHoaDon(int maHD, PhuongThucThanhToan phuongThuc)
        {
            if (maHD <= 0) return "Mã hóa đơn không hợp lệ!";
            return dalHoaDon.ThanhToanHoaDon(maHD, phuongThuc) ? "" : "Thanh toán thất bại!";
        }

        // 4. Xóa hóa đơn
        public string XoaHoaDon(int maHD)
        {
            if (maHD <= 0) return "Mã hóa đơn không hợp lệ!";
            return dalHoaDon.XoaHoaDon(maHD) ? "" : "Không thể xóa! Hóa đơn có thể đã thanh toán.";
        }

        // 5. Lịch sử theo hợp đồng
        public DataTable XemLichSuThanhToan(string maHopDong)
        {
            if (string.IsNullOrWhiteSpace(maHopDong)) return new DataTable();
            return dalHoaDon.XemLichSuThanhToan(maHopDong);
        }
    }
}