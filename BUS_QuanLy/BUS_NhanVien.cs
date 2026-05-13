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

        // 2. Chức năng Thêm Nhân Viên mới (Có kiểm tra luật nghiệp vụ)
        public string ThemNhanVien(DTO_NHANVIEN nv)
        {
            // Không được để trống Họ và Tên nhân viên
            if (string.IsNullOrWhiteSpace(nv.HONV) || string.IsNullOrWhiteSpace(nv.TENNV))
            {
                return "Họ và tên nhân viên không được để trống!";
            }

            // Kiểm tra định dạng Số điện thoại
            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^[0-9]{10,11}$"))
                {
                    return "Số điện thoại không hợp lệ! (Phải từ 10 - 11 chữ số).";
                }
            }

            //Kiểm tra định dạng Email
            if (!string.IsNullOrWhiteSpace(nv.EMAIL))
            {
                if (!Regex.IsMatch(nv.EMAIL, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    return "Định dạng Email không hợp lệ!";
                }
            }

            bool kq = dalNhanVien.ThemNhanVien(nv);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Lỗi hệ thống khi thêm dữ liệu!";
        }

        // 3. Chức năng Sửa thông tin Nhân Viên
        public string SuaNhanVien(DTO_NHANVIEN nv)
        {
            if (nv.MANV <= 0)
            {
                return "Mã nhân viên không hợp lệ!";
            }

            if (string.IsNullOrWhiteSpace(nv.HONV) || string.IsNullOrWhiteSpace(nv.TENNV))
            {
                return "Họ và tên nhân viên không được để trống!";
            }

            if (!string.IsNullOrWhiteSpace(nv.SDT) && !Regex.IsMatch(nv.SDT, @"^[0-9]{10,11}$"))
            {
                return "Số điện thoại không hợp lệ!";
            }

            if (!string.IsNullOrWhiteSpace(nv.EMAIL) && !Regex.IsMatch(nv.EMAIL, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                return "Định dạng Email không hợp lệ!";
            }

            bool kq = dalNhanVien.SuaNhanVien(nv);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Không thể cập nhật thông tin nhân viên!";
        }

        // 4. Chức năng Xóa Nhân Viên
        public string XoaNhanVien(int maNV)
        {
            if (maNV <= 0)
            {
                return "Mã nhân viên không hợp lệ!";
            }

            bool kq = dalNhanVien.XoaNhanVien(maNV);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Nhân viên đang liên kết với các dữ liệu khác, không thể xóa!";
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