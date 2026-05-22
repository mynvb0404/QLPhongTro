using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_KhachThue
    {
        private DAL_KHACHTHUE dalKhachThue = new DAL_KHACHTHUE();

        public DataTable LayDanhSachKhachThue() => dalKhachThue.LayDanhSachKhachThue();

        // 1 Thêm khách thuê
        public string ThemKhachThue(DTO_KHACHTHUE kt)
        {
            // Kiểm tra trống các trường bắt buộc
            if (string.IsNullOrWhiteSpace(kt.HOKH))
                return "Họ khách thuê không được để trống!";
            if (string.IsNullOrWhiteSpace(kt.TENKH))
                return "Tên khách thuê không được để trống!";
            if (string.IsNullOrWhiteSpace(kt.CCCD))
                return "Số CCCD không được để trống!";
            if (string.IsNullOrWhiteSpace(kt.SDT))
                return "Số điện thoại không được để trống!";

            // Kiểm tra định dạng CCCD (12 chữ số)
            if (!Regex.IsMatch(kt.CCCD, @"^\d{12}$"))
                return "CCCD phải đúng 12 chữ số!";

            // Kiểm tra định dạng Số điện thoại (10-11 chữ số)
            if (!Regex.IsMatch(kt.SDT, @"^[0-9]{10,11}$"))
                return "Số điện thoại không hợp lệ! (Phải từ 10-11 chữ số)";

            // Kiểm tra Ngày sinh (Phải đủ tuổi >= 18 tuổi)
            if (kt.NGAYSINH.HasValue)
            {
                int tuoi = DateTime.Now.Year - kt.NGAYSINH.Value.Year;
                if (tuoi < 18)
                    return "Khách thuê phải từ 18 tuổi trở lên!";
                if (kt.NGAYSINH.Value > DateTime.Now)
                    return "Ngày sinh không thể lớn hơn ngày hiện tại!";
            }
            else
            {
                return "Ngày sinh không được để trống!";
            }

            if (kt.NGAYBATDAUTHUE == DateTime.MinValue)
                kt.NGAYBATDAUTHUE = DateTime.Now;
            // Kiểm tra Ngày bắt đầu thuê
            if (kt.NGAYBATDAUTHUE.Date < DateTime.Today)
                return "Ngày bắt đầu thuê không được nhỏ hơn ngày hiện tại!";

            if (dalKhachThue.KiemTraTrungCCCD(kt.CCCD)) return "Số CCCD này đã tồn tại!";
            if (dalKhachThue.KiemTraTrungSDT(kt.SDT)) return "Số điện thoại này đã tồn tại!";

            kt.TRANGTHAITHUE = TrangThaiKhachThue.DangThue;

            try
            {
                return dalKhachThue.ThemKhachThue(kt) ? "" : "Lỗi hệ thống: Không thể lưu khách thuê!";
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối CSDL: " + ex.Message;
            }
        }

        // 2 Sửa thông tin khách thuê
        public string SuaKhachThue(DTO_KHACHTHUE kt)
        {
            if (kt.MAKH <= 0) return "Mã khách thuê không hợp lệ!";
            if (string.IsNullOrWhiteSpace(kt.HOKH) || string.IsNullOrWhiteSpace(kt.TENKH))
                return "Họ và tên không được để trống!";
            if (!string.IsNullOrWhiteSpace(kt.CCCD) && !Regex.IsMatch(kt.CCCD, @"^\d{12}$"))
                return "CCCD phải là 12 chữ số!";
            if (!string.IsNullOrWhiteSpace(kt.SDT) && !Regex.IsMatch(kt.SDT, @"^[0-9]{10,11}$"))
                return "Số điện thoại không hợp lệ!";
            return dalKhachThue.SuaKhachThue(kt) ? "" : "Cập nhật thất bại!";
        }

        // 3 Xóa khách thuê
        public string XoaKhachThue(int maKH)
        {
            if (maKH <= 0) return "Mã khách thuê không hợp lệ!";
            // Kiểm tra khách có hợp đồng đang hiệu lực không
            if (dalKhachThue.KiemTraCoHopDong(maKH))
                return "Không thể xóa! Khách thuê này đang có hợp đồng hiệu lực.";
            return dalKhachThue.XoaKhachThue(maKH) ? "" : "Xóa thất bại!";
        }

        // 4 Tìm kiếm khách thuê
        public DataTable TimKiemKhachThue(string tuKhoa) => dalKhachThue.TimKiemKhachThue(tuKhoa);

        // 5 Xem thông tin người thuê
        public DataTable XemThongTinNguoiThue(int maKH) => dalKhachThue.  LayThongTinKhachThue(maKH);
    }
}