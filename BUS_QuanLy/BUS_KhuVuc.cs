using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_KhuVuc
    {
        private DAL_KhuVuc dalKhuVuc = new DAL_KhuVuc();

        public DataTable LayDanhSachKhuVuc() => dalKhuVuc.LayDanhSachKhuVuc();

        // 1 Thêm khu vực
        public string ThemKhuVuc(DTO_KHUVUC kv)
        {
            if (kv.MAKV.Length > 5)
                return "Mã khu vực tối đa 5 ký tự!";
            if (string.IsNullOrWhiteSpace(kv.TENKV))
                return "Tên khu vực không được để trống!";
            if (string.IsNullOrWhiteSpace(kv.DCHI))
                return "Địa chỉ khu vực không được để trống!";
            if (dalKhuVuc.KiemTraTonTai(kv.MAKV))
                return "Mã khu vực này đã tồn tại trong hệ thống!";

            return dalKhuVuc.ThemKhuVuc(kv) ? "" : "Thêm khu vực thất bại!";
        }

        // 2 Sửa thông tin khu vực
        public string SuaKhuVuc(DTO_KHUVUC kv)
        {
            if (string.IsNullOrWhiteSpace(kv.MAKV))
                return "Mã khu vực không hợp lệ!";
            if (string.IsNullOrWhiteSpace(kv.TENKV))
                return "Tên khu vực không được để trống!";
            if (string.IsNullOrWhiteSpace(kv.DCHI))
                return "Địa chỉ không được để trống!";

            return dalKhuVuc.SuaKhuVuc(kv) ? "" : "Cập nhật thất bại!";
        }

        // 3 Xóa khu vực
        public string XoaKhuVuc(string maKV)
        {
            if (string.IsNullOrWhiteSpace(maKV))
                return "Mã khu vực không hợp lệ!";

            if (dalKhuVuc.KiemTraCoPhong(maKV))
                return "Không thể xóa! Khu vực này vẫn còn phòng đang hoạt động.";
            return dalKhuVuc.XoaKhuVuc(maKV) ? "" : "Xóa thất bại!";
        }

        // 4 Tìm kiếm khu vực
        public DataTable TimKiemKhuVuc(string tuKhoa) => dalKhuVuc.TimKiemKhuVuc(tuKhoa);
    }
}