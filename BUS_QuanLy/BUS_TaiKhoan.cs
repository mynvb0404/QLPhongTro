using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        private DAL_TAIKHOAN dalTaiKhoan = new DAL_TAIKHOAN();

        public DataTable LayDanhSachTaiKhoan() => dalTaiKhoan.LayDanhSachTaiKhoan();

        // 1 Thêm tài khoản
        public string ThemTaiKhoan(DTO_TAIKHOAN tk)
        {

            if (string.IsNullOrWhiteSpace(tk.TENDANGNHAP))
                return "Tên đăng nhập không được để trống!";

            if (!Regex.IsMatch(tk.TENDANGNHAP, @"^[a-zA-Z0-9_]+$"))
                return "Tên đăng nhập chỉ được chứa chữ, số và dấu gạch dưới!";

            if (string.IsNullOrWhiteSpace(tk.MATKHAU) || tk.MATKHAU.Length < 6)
                return "Mật khẩu phải từ 6 đến 20 ký tự!";

            if (tk.LOAITK == LoaiTaiKhoan.NV)
            {
                if (tk.MANV == null || tk.MAKH != null)
                    return "Tài khoản nhân viên phải gắn liền với Mã nhân viên và không có Mã khách hàng!";
            }

            // KIỂM TRA ENUM: Ràng buộc loại tài khoản Khách hàng (KH)
            if (tk.LOAITK == LoaiTaiKhoan.KH)
            {
                if (tk.MAKH == null || tk.MANV != null)
                    return "Tài khoản khách hàng phải gắn liền với Mã khách hàng và không có Mã nhân viên!";
            }

            if (dalTaiKhoan.KiemTraTonTai(tk.TENDANGNHAP))
                return "Tên đăng nhập này đã được sử dụng!";

            return dalTaiKhoan.ThemTaiKhoan(tk) ? "" : "Thêm tài khoản thất bại!";
        }

        // 2 Sửa tài khoản
        public string SuaTaiKhoan(DTO_TAIKHOAN tk)
        {
            if (string.IsNullOrWhiteSpace(tk.MATKHAU) || tk.MATKHAU.Length < 6)
                return "Mật khẩu phải có ít nhất 6 ký tự!";
            return dalTaiKhoan.SuaTaiKhoan(tk) ? "" : "Cập nhật thất bại!";
        }

        // 3 Xóa tài khoản
        public string XoaTaiKhoan(string maTK)
        {
            if (string.IsNullOrWhiteSpace(maTK))
                return "Mã tài khoản không hợp lệ!";
            return dalTaiKhoan.XoaTaiKhoan(maTK) ? "" : "Xóa thất bại!";
        }

        // 4 Tìm kiếm tài khoản
        public DataTable TimKiemTaiKhoan(string tuKhoa) => dalTaiKhoan.TimKiemTaiKhoan(tuKhoa);

        public DataTable KiemTraDangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
               return new DataTable();

            return dalTaiKhoan.KiemTraDangNhap(tenDN, matKhau);
        }
    }
}