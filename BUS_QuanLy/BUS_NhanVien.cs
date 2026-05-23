using System;
using System.Data;
using System.Text.RegularExpressions;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        private DAL_NhanVien dalNhanVien = new DAL_NhanVien();

        // 1. Lấy danh sách toàn bộ nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            return dalNhanVien.LayDanhSachNhanVien();
        }

        // 2. Chức năng Thêm Nhân Viên mới
        public string ThemNhanVien(DTO_NhanVien nv, string tenDN, string matKhau)
        {
            DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();
            try
            {
                int maNVVuaTao = dalNhanVien.ThemNhanVien(nv);

                if (maNVVuaTao > 0)
                {

                    DTO_TaiKhoan tkNew = new DTO_TaiKhoan()
                    {
                        TENDANGNHAP = tenDN,
                        MATKHAU = matKhau,
                        LOAITK = "NV",
                        MANV = maNVVuaTao
                    };

                    bool kqTaiKhoan = dalTaiKhoan.SuaTaiKhoan(tkNew);

                    return kqTaiKhoan ? "THÀNH CÔNG" : "Thêm nhân viên thành công nhưng khởi tạo tài khoản thất bại!";
                }

                return "Lỗi hệ thống: Không thể thêm thông tin nhân viên!";
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối CSDL: " + ex.Message;
            }
        }
        //3. Sửa nhân viên
        public string SuaNhanVien(DTO_NhanVien nv)
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