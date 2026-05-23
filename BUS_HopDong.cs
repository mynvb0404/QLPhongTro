using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_HopDong
    {
        DAL_HopDong dalHD =
             new DAL_HopDong();

        //THÊM
        public string ThemHopDong(DTO_HopDong hd)
        {
            if (string.IsNullOrWhiteSpace(hd.MAHOPDONG)) return "Mã hợp đồng không được để trống!";
            if (hd.MAPHONG <= 0) return "Mã phòng không hợp lệ!";
            if (hd.NGAYKT <= hd.NGAYKYHD) return "Ngày kết thúc phải sau ngày ký!";

            if (dalHD.ThemHopDong(hd)) return "THÀNH CÔNG";
            return "Thất bại: Mã hợp đồng đã tồn tại hoặc lỗi dữ liệu!";
        }
        //SỬA
        public string SuaHopDong(DTO_HopDong hd)
        {
            // Giả sử hàm dalHD.SuaHopDong trả về bool
            if (dalHD.SuaHopDong(hd))
            {
                return "THÀNH CÔNG";
            }
            else
            {
                return "Sửa thất bại!";
            }
        }

        //XÓA
        public bool XoaHopDong(string MAHOPDONG)
        {
            return dalHD.XoaHopDong(MAHOPDONG);
        }

        //TÌM KIẾM
        public DataTable TimKiemHopDong(
            string keyword)
        {
            return dalHD.TimKiemHopDong(keyword);
        }

        //XEM DANH SÁCH
        public DataTable LayDanhSachHopDong()
        {
            return dalHD.LayDanhSachHopDong();
        }

        //LẤY THÔNG TIN
        public DataTable LayThongTinHopDong(
            string MAHOPDONG)
        {
            return dalHD.LayThongTinHopDong(
                MAHOPDONG);
        }

        //LẤY THEO PHÒNG
        public DataTable LayHopDongTheoPhong(
            int MAPHONG)
        {
            return dalHD.LayHopDongTheoPhong(
                MAPHONG);
        }
    }
}
