using System;
using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        private DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();

        public DataTable LayDanhSachTaiKhoan() => dalTaiKhoan.LayDanhSachTaiKhoan();

        // 1. Thêm tài khoản
        public string ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            if (string.IsNullOrWhiteSpace(tk.TENDANGNHAP))
                return "Tên đăng nhập không được để trống!";

            if (!Regex.IsMatch(tk.TENDANGNHAP, @"^[a-zA-Z0-9_]+$"))
                return "Tên đăng nhập chỉ được chứa chữ, số và dấu gạch dưới!";

            if (string.IsNullOrWhiteSpace(tk.MATKHAU) || tk.MATKHAU.Length < 6)
                return "Mật khẩu phải từ 6 đến 20 ký tự!";

            if (tk.LOAITK == "NV" && (tk.MANV == null || tk.MAKH != null))
                return "Tài khoản nhân viên phải có MANV và không có MAKH!";

            if (tk.LOAITK == "KH" && (tk.MAKH == null || tk.MANV != null))
                return "Tài khoản khách hàng phải có MAKH và không có MANV!";

            if (dalTaiKhoan.KiemTraTonTai(tk.TENDANGNHAP))
                return "Tên đăng nhập này đã được sử dụng!";

            return dalTaiKhoan.ThemTaiKhoan(tk) ? "THÀNH CÔNG" : "Thêm tài khoản thất bại!";
        }

        // 2. Sửa tài khoản
        public string SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(tk.TENDANGNHAP))
                return "Tên đăng nhập không được để trống!";

            if (!Regex.IsMatch(tk.TENDANGNHAP, @"^[a-zA-Z0-9_]+$"))
                return "Tên đăng nhập chỉ được chứa chữ, số và dấu gạch dưới!";

            if (string.IsNullOrWhiteSpace(tk.MATKHAU) || tk.MATKHAU.Length < 6)
                return "Mật khẩu chỉnh sửa phải từ 6 ký tự trở lên!";

            // 2. Kiểm tra tính hợp lệ của ID đi kèm tài khoản
            if (tk.LOAITK == "NV" && tk.MANV == null)
                return "Tài khoản nhân viên phải đi kèm với Mã nhân viên (MANV)!";

            if (tk.LOAITK == "KH" && tk.MAKH == null)
                return "Tài khoản khách hàng phải đi kèm với Mã khách hàng (MAKH)!";

            // 3. Gọi xuống DAL để thực thi
            return dalTaiKhoan.SuaTaiKhoan(tk) ? "THÀNH CÔNG" : "Cập nhật tài khoản thất bại!";
        }

        // 3. Xóa tài khoản
        public string XoaTaiKhoan(string maTK)
        {
            if (string.IsNullOrWhiteSpace(maTK))
                return "Mã tài khoản không hợp lệ!";
            return dalTaiKhoan.XoaTaiKhoan(maTK) ? "THÀNH CÔNG" : "Xóa thất bại!";
        }

        // 4. Tìm kiếm tài khoản
        public DataTable TimKiemTaiKhoan(string tuKhoa) => dalTaiKhoan.TimKiemTaiKhoan(tuKhoa);

        // 5. Hàm Đăng Nhập chuẩn hóa trả về đối tượng DTO
        public DTO_TaiKhoan DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            return dalTaiKhoan.DangNhap(tenDN, matKhau);
        }
    }
}