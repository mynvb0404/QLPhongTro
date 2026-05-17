using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_TINOGHEP
    {
        private DAL_TINOGHEP dalTinOGhep = new DAL_TINOGHEP();

        // 1 Đăng ký và quản lý tin ở ghép
        public string ThemTinOGhep(DTO_TINOGHEP og)
        {
            if (og.MAPHONG <= 0) return "Mã phòng không được để trống!";
            if (og.MAKH <= 0) return "Mã khách hàng không được để trống!";
            if (og.SONGUOICAN <= 0) return "Số người cần tìm phải lớn hơn 0!";
            if (og.GIACHIA <= 0) return "Giá chia sẻ phải lớn hơn 0!";
            if (og.NGAYDANG.Date < System.DateTime.Today)
                return "Ngày đăng không hợp lệ!";
            string[] gtHopLe = { "Nam", "Nữ" };
            if (!Array.Exists(gtHopLe, g => g == og.GIOITINH))
                return "Giới tính yêu cầu không hợp lệ!";

            if (string.IsNullOrWhiteSpace(og.MOTA))
                return "Vui lòng nhập mô tả cho tin đăng!";

            og.TRANGTHAITIN = "Đang tìm";
            return dalOGhep.ThemTinOGhep(og) ? "" : "Đăng tin thất bại!";
        }

        // 2 Tìm kiếm ở ghép theo tiêu chí 
        public DataTable TimKiemOGhep(string gioiTinh, decimal giaMax, string tuKhoa)
        {
            // Chuẩn hóa dữ liệu để tránh lỗi query
            string gioiTinhChuan = string.IsNullOrWhiteSpace(gioiTinh) ? "" : gioiTinh.Trim();
            string tuKhoaChuan = string.IsNullOrWhiteSpace(tuKhoa) ? "" : tuKhoa.Trim();
            decimal giaChuan = giaMax < 0 ? 0 : giaMax; // Đảm bảo giá không âm

            return dalOGhep.TimKiemOGhep(gioiTinhChuan, giaChuan, tuKhoaChuan);
        }

        // 3 Gửi yêu cầu ở ghép
        public string GuiYeuCauOGhep(DTO_TINOGHEP og)
        {
            if (string.IsNullOrWhiteSpace(og.MAPHONG) || string.IsNullOrWhiteSpace(og.MAKH))
                return "Thông tin không đầy đủ!";
            return dalOGhep.GuiYeuCauOGhep(og) ? "" : "Gửi yêu cầu thất bại!";
        }

        // 4 Xử lý yêu cầu ở ghép
        public string XuLyYeuCau(int maTin, string trangThai)
        {
            string[] hopLe = { "Đã duyệt", "Từ chối" };
            if (!System.Array.Exists(hopLe, t => t == trangThai))
                return "Trạng thái xử lý không hợp lệ!";
            return dalOGhep.XuLyYeuCau(maTin, trangThai) ? "" : "Xử lý thất bại!";
        }

        // 3 Sửa tin ở ghép
        public string SuaTinOGhep(DTO_TINOGHEP og)
        {
            if (og.MATINOG <= 0) return "Mã tin không hợp lệ!";
            if (og.SONGUOICAN <= 0 || og.GIACHIA <= 0) return "Dữ liệu số người hoặc giá phải > 0!";
            if (string.IsNullOrWhiteSpace(og.MOTA)) return "Mô tả không được để trống!";

            return dalTinOGhep.SuaTinOGhep(og) ? "" : "Cập nhật tin thất bại!";
        }

        // 4 Cập nhật trạng thái tin (Duyệt/Đóng tin)
        public string CapNhatTrangThaiTin(int maTin, string trangThai)
        {
            string[] hopLe = { "Đang tìm", "Đã đủ người", "Đã đóng" };
            if (!Array.Exists(hopLe, t => t == trangThai))
                return "Trạng thái không hợp lệ!";

            if (maTin <= 0) return "Mã tin không hợp lệ!";

            return dalTinOGhep.CapNhatTrangThaiTin(maTin, trangThai) ? "" : "Cập nhật trạng thái thất bại!";
        }

        // 5 Lấy danh sách tin theo phòng
        public DataTable LayDanhSachTinTheoPhong(int maPhong)
        {
            if (maPhong <= 0) return null;
            return dalTinOGhep.LayDanhSachTinTheoPhong(maPhong);
        }

        // 6 Đánh giá và phản hồi
        public string DanhGiaOGhep(int maTin, string danhGia)
        {
            if (string.IsNullOrWhiteSpace(danhGia))
                return "Nội dung đánh giá không được để trống!";
            if (danhGia.Length > 500)
                return "Nội dung đánh giá không được quá 500 ký tự!";
            return dalOGhep.DanhGiaOGhep(maTin, danhGia) ? "" : "Gửi đánh giá thất bại!";
        }
    }
}