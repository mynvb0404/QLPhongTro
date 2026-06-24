using System;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_KhuVuc
    {
        private DAL_KhuVuc dalKhuVuc = new DAL_KhuVuc();

        //Lấy danh sách toàn bộ khu vực
        public DataTable LayDanhSachKhuVuc() => dalKhuVuc.LayDanhSachKhuVuc();

        //Thêm khu vực mới
        public string ThemKhuVuc(DTO_KhuVuc kv)
        {
            if (string.IsNullOrWhiteSpace(kv.MAKV))
                return "Mã khu vực không được để trống!";
            if (kv.MAKV.Length > 5)
                return "Mã khu vực tối đa 5 ký tự!";
            if (string.IsNullOrWhiteSpace(kv.TENKV))
                return "Tên khu vực không được để trống!";
            if (string.IsNullOrWhiteSpace(kv.DCHI))
                return "Địa chỉ khu vực không được để trống!";

            if (dalKhuVuc.KiemTraTonTai(kv.MAKV))
                return "Mã khu vực này đã tồn tại trong hệ thống!";

            return dalKhuVuc.ThemKhuVuc(kv) ? "THÀNH CÔNG" : "Thất bại: Lỗi hệ thống khi thêm khu vực!";
        }

        //Sửa thông tin khu vực
        public string SuaKhuVuc(DTO_KhuVuc kv)
        {
            if (string.IsNullOrWhiteSpace(kv.MAKV))
                return "Mã khu vực không hợp lệ!";
            if (string.IsNullOrWhiteSpace(kv.TENKV))
                return "Tên khu vực không được để trống!";
            if (string.IsNullOrWhiteSpace(kv.DCHI))
                return "Địa chỉ không được để trống!";

            return dalKhuVuc.SuaKhuVuc(kv) ? "THÀNH CÔNG" : "Thất bại: Không thể cập nhật thông tin khu vực!";
        }

        //Xóa khu vực 
        public string XoaKhuVuc(string maKV)
        {
            if (string.IsNullOrWhiteSpace(maKV))
                return "Mã khu vực không hợp lệ!";

            if (dalKhuVuc.KiemTraCoPhong(maKV))
                return "Không thể xóa! Khu vực này đang có các phòng trọ hoạt động.";

            return dalKhuVuc.XoaKhuVuc(maKV) ? "THÀNH CÔNG" : "Thất bại: Khu vực có thể đang liên kết với dữ liệu lịch sử khác!";
        }

        //Tìm kiếm khu vực
        public DataTable TimKiemKhuVuc(string tuKhoa)
        {
            string thamSoTuKhoa = string.IsNullOrWhiteSpace(tuKhoa) ? "" : tuKhoa.Trim();
            return dalKhuVuc.TimKiemKhuVuc(thamSoTuKhoa);
        }
    }
}