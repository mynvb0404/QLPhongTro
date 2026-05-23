using System;
using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;
using Microsoft.Data.SqlClient;

namespace BUS_QuanLy
{
    public class BUS_KhachThue
    {
        private DAL_KHACHTHUE dalKhachThue = new DAL_KHACHTHUE();

        public DataTable LayDanhSachKhachHang() => dalKhachThue.LayDanhSachKhachThue();

        public string ThemKhachThue(DTO_KHACHTHUE kt, string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(kt.HOKH) || string.IsNullOrWhiteSpace(kt.TENKH))
                return "Họ và Tên khách thuê không được để trống!";
            if (string.IsNullOrWhiteSpace(kt.SDT))
                return "Số điện thoại không được để trống!";
            if (!Regex.IsMatch(kt.SDT, @"^[0-9]{10,11}$"))
                return "Số điện thoại không hợp lệ! (Yêu cầu từ 10-11 số)";

            if (dalKhachThue.KiemTraTrungSDT(kt.SDT))
                return "Số điện thoại này đã tồn tại trên hệ thống!";

            if (!kt.NGAYSINH.HasValue) kt.NGAYSINH = DateTime.Now.AddYears(-20);
            kt.TRANGTHAITHUE = TrangThaiKhachThue.DangThue;
            if (kt.NGAYBATDAUTHUE == DateTime.MinValue) kt.NGAYBATDAUTHUE = DateTime.Today;

            try
            {
                bool IsThanhCong = dalKhachThue.ThemKhachThue(kt);

                if (IsThanhCong)
                {
                    // Tạo tài khoản cho khách thuê sau khi thêm thành công
                    DTO_TAIKHOAN tkNew = new DTO_TAIKHOAN()
                    {
                        TENDANGNHAP = tenDangNhap,
                        MATKHAU = matKhau,
                        LOAITK = LoaiTaiKhoan.KH,  // Khách hàng
                        MAKH = kt.MAKH,
                    };

                    DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();
                    dalTaiKhoan.ThemTaiKhoan(tkNew);
                    return "THÀNH CÔNG!";

                }
                return IsThanhCong ? "THÀNH CÔNG" : "Thêm khách thuê và khởi tạo tài khoản thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối CSDL: " + ex.Message;
            }
        }
        public string SuaKhachThue(DTO_KHACHTHUE kt)
        {
            if (kt.MAKH <= 0) return "Mã khách thuê không hợp lệ!";
            if (string.IsNullOrWhiteSpace(kt.HOKH) || string.IsNullOrWhiteSpace(kt.TENKH))
                return "Họ và tên không được để trống!";

            return dalKhachThue.SuaKhachThue(kt) ? "THÀNH CÔNG" : "Cập nhật dữ liệu thất bại!";
        }

        public string XoaKhachHang(int maKH)
        {
            if (maKH <= 0) return "Mã khách thuê không hợp lệ!";
            if (dalKhachThue.KiemTraCoHopDong(maKH))
                return "Không thể xóa! Khách thuê này hiện đang có hợp đồng nhà trọ còn hiệu lực.";

            return dalKhachThue.XoaKhachThue(maKH) ? "THÀNH CÔNG" : "Xóa tài khoản và dữ liệu thất bại!";
        }

        public DataTable TimKiemKhachHang(string tuKhoa) => dalKhachThue.TimKiemKhachThue(tuKhoa);
    }
}