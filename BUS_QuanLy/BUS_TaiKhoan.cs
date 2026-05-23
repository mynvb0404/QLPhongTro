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

            return dalTaiKhoan.ThemTaiKhoan(tk) ? "THÀNH CÔNG" : "Thêm tài khoản thất bại!";
        }

        // 2. Sửa tài khoản
        public string SuaTaiKhoan(DTO_TAIKHOAN tk)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(tk.TENDANGNHAP))
                return "Tên đăng nhập không được để trống!";

            if (!Regex.IsMatch(tk.TENDANGNHAP, @"^[a-zA-Z0-9_]+$"))
                return "Tên đăng nhập chỉ được chứa chữ, số và dấu gạch dưới!";

            if (string.IsNullOrWhiteSpace(tk.MATKHAU) || tk.MATKHAU.Length < 6)
                return "Mật khẩu chỉnh sửa phải từ 6 ký tự trở lên!";

            // 2. Kiểm tra tính hợp lệ của ID đi kèm tài khoản
            if (tk.LOAITK == LoaiTaiKhoan.NV)
            {
                if (tk.MANV == null || tk.MAKH != null)
                    return "Tài khoản nhân viên phải gắn liền với Mã nhân viên và không có Mã khách hàng!";
            }


            if (tk.LOAITK == LoaiTaiKhoan.KH)
            {
                if (tk.MAKH == null || tk.MANV != null)
                    return "Tài khoản khách hàng phải gắn liền với Mã khách hàng và không có Mã nhân viên!";
            }
            ;

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
        public DTO_TAIKHOAN DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            return dalTaiKhoan.DangNhap(tenDN, matKhau);
        }
    }
}