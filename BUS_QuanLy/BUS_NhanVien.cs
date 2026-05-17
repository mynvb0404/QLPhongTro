using System;
using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        private DAL_NHANVIEN dalNhanVien = new DAL_NHANVIEN();

        // 1. Lấy danh sách toàn bộ nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            return dalNhanVien.LayDanhSachNhanVien();
        }

        // 2. Chức năng Thêm Nhân Viên mới 
        public string ThemNhanVien(DTO_NHANVIEN nv)
        {
            // Không được để trống Họ và Tên nhân viên
            if (string.IsNullOrWhiteSpace(nv.HONV) || string.IsNullOrWhiteSpace(nv.TENNV))
            {
                return "Họ và tên nhân viên không được để trống!";
            }

            if (string.IsNullOrWhiteSpace(nv.CHUCVU))
                return "Chức vụ không được để trống!";

            // Kiểm tra định dạng Số điện thoại
            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^[0-9]{10,11}$"))
                    return "Số điện thoại không hợp lệ! (Phải từ 10 - 11 chữ số).";
                if (dalNhanVien.KiemTraTrungSDT(nv.SDT))
                    return "Số điện thoại này đã thuộc về nhân viên khác!";
            }

            //Kiểm tra định dạng Email
            if (!string.IsNullOrWhiteSpace(nv.EMAIL))
            {
                if (!Regex.IsMatch(nv.EMAIL, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    return "Định dạng Email không hợp lệ!";
                if (dalNhanVien.KiemTraTrungEmail(nv.EMAIL))
                    return "Email này đã được sử dụng!";
            }

            return dalNhanVien.ThemNhanVien(nv) ? "" : "Thất bại: Lỗi hệ thống khi thêm dữ liệu!";
        }

        // 3. Chức năng Sửa thông tin Nhân Viên
        public string SuaNhanVien(DTO_NHANVIEN nv)
        {
            if (nv.MANV <= 0) return "Mã nhân viên không hợp lệ!";
            if (string.IsNullOrWhiteSpace(nv.HONV) || string.IsNullOrWhiteSpace(nv.TENNV) || string.IsNullOrWhiteSpace(nv.CHUCVU))
                return "Thông tin bắt buộc (Họ, Tên, Chức vụ) không được để trống!";

            if (!string.IsNullOrWhiteSpace(nv.SDT) && !Regex.IsMatch(nv.SDT, @"^[0-9]{10,11}$"))
                return "Số điện thoại không hợp lệ!";

            if (!string.IsNullOrWhiteSpace(nv.EMAIL) && !Regex.IsMatch(nv.EMAIL, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                return "Định dạng Email không hợp lệ!";

            return dalNhanVien.SuaNhanVien(nv) ? "" : "Thất bại: Không thể cập nhật thông tin nhân viên!";
        }

        // 4. Chức năng Xóa Nhân Viên
        public string XoaNhanVien(int maNV)
        {
            if (maNV <= 0) return "Mã nhân viên không hợp lệ!";

            if (dalNhanVien.KiemTraNhanVienDangQuanLy(maNV))
                return "Không thể xóa! Nhân viên này đang chịu trách nhiệm quản lý khu vực.";

            return dalNhanVien.XoaNhanVien(maNV) ? "" : "Thất bại: Nhân viên đang liên kết với dữ liệu khác!";
        }

        // 5. Chức năng tìm kiếm nhân viên theo Từ khóa
        public DataTable TimKiemNhanVien(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return dalNhanVien.LayDanhSachNhanVien();
            }
            return dalNhanVien.TimKiemNhanVien(keyword.Trim());
        }
    }
}