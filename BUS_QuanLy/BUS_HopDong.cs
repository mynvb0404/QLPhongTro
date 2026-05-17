using System;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_HopDong
    {
        private DAL_HOPDONG dalHopDong = new DAL_HOPDONG();

        public DataTable LayDanhSachHopDong() => dalHopDong.LayDanhSachHopDong();
        

        // 1 Thêm hợp đồng
        public string ThemHopDong(DTO_HOPDONG hd)
        {
            if (hd.MAKH <= 0)
                return "Không được để trống khách thuê!";
            if (hd.MAPHONG <= 0)
                return "Không được để trống phòng!";
            hd.NGAYKYHD = DateTime.Now;
            if (hd.NGAYBATDAU >= hd.NGAYKETTHUC || hd.NGAYKT <= DateTime.Now)
                return "Ngày kết thúc phải sau ngày hiện tại và phải sau ngày bắt đầu!";
            
            if (string.IsNullOrWhiteSpace(hd.THONGTINHD))
                return "Thông tin hợp đồng không được để trống!";
            if (hd.GIATHUE <= 0)
                return "Giá thuê phải lớn hơn 0!";

            hd.TRANGTHAIHOPDONG = "Còn hiệu lực";
            return dalHopDong.ThemHopDong(hd) ? "" : "Thêm hợp đồng thất bại!";
        }

        // 2 Sửa hợp đồng
        public string SuaHopDong(DTO_HOPDONG hd)
        {
            if (hd.MAHOPDONG <= 0)
                return "Mã hợp đồng không hợp lệ!";
            if (hd.NGAYKT <= DateTime.Now || hd.NGAYBATDAU >= hd.NGAYKETTHUC)
                return "Ngày kết thúc phải sau ngày hiện tại và phải sau ngày bắt đầu!";
            if (hd.GIATHUE <= 0)
                return "Giá thuê phải lớn hơn 0!";
            if (string.IsNullOrWhiteSpace(hd.THONGTINHD))
                return "Thông tin hợp đồng không được để trống!";

            if (!Enum.IsDefined(typeof(TrangThaiHopDong), hd.TRANGTHAIHOPDONG))
            {
                return "Trạng thái hợp đồng không hợp lệ!";
            }

            return dalHopDong.SuaHopDong(hd) ? "" : "Cập nhật thất bại!";
        }

        // 3 Xóa hợp đồng
        public string XoaHopDong(int maHD)
        {
            if (maHD <= 0) return "Mã hợp đồng không hợp lệ!";
            return dalHopDong.XoaHopDong(maHD) ? "" : "Xóa thất bại!";
        }

        public DataTable TimKiemHopDong(string tk)
        {
            return string.IsNullOrWhiteSpace(tk) ? dalHopDong.LayDanhSachHopDong() : dalHopDong.TimKiemHopDong(tk.Trim());
        }
        public DataTable XemHopDong(int maHD) => dalHopDong.XemHopDong(maHD);
    }
}