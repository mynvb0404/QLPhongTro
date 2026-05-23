using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_TINOGHEP
    {
        private DAL_TINOGHEP dalTinOGhep = new DAL_TINOGHEP();

        // 1 Đăng ký và quản lý tin ở ghép
        public string ThemTinOGhep(DTO_TINOGHEP og)
        {
            if (og.MAPHONG <= 0) return "Mã phòng không được để trống!";
            if (og.MAKH <= 0) return "Mã khách hàng không được để trống!";
            if (og.SONGUOICAN <= 0) return "Số người cần tìm phải lớn hơn 0!";
            if (og.GIACHIA <= 0) return "Giá chia sẻ phải lớn hơn 0!";
            
            if (og.GIOITINH != GioiTinh.Nam && og.GIOITINH != GioiTinh.Nu)
                return "Giới tính yêu cầu không hợp lệ!";

            if (string.IsNullOrWhiteSpace(og.MOTA))
                return "Vui lòng nhập mô tả cho tin đăng!";

            og.TRANGTHAITIN = TrangThaiTinOGhep.DangTim;
            return dalTinOGhep.ThemTinOGhep(og) ? "" : "Đăng tin thất bại!";
        }

        // 2. Tìm kiếm tin ở ghép
        public DataTable TimKiemTinOGhep(int maPhong, string gioiTinh, decimal giaMax, int soNguoi)
        {
            string gioiTinhChuan = string.IsNullOrWhiteSpace(gioiTinh) ? "" : gioiTinh.Trim();
            decimal giaChuan = giaMax < 0 ? 0 : giaMax;
            return dalTinOGhep.TimKiemTinOGhep(maPhong, gioiTinhChuan, giaChuan, soNguoi, "");
        }

        // 3 Sửa tin ở ghép
        public string SuaTinOGhep(DTO_TINOGHEP og)
        {
            if (og.MATINOG <= 0) return "Mã tin không hợp lệ!";
            if (og.SONGUOICAN <= 0) return "Số người cần phải lớn hơn 0!";
            if (og.GIACHIA <= 0) return "Giá chia sẻ phải lớn hơn 0!";
            if (string.IsNullOrWhiteSpace(og.MOTA)) return "Mô tả không được để trống!";

            return dalTinOGhep.SuaTinOGhep(og) ? "" : "Cập nhật tin thất bại!";
        }

        // 4 Cập nhật trạng thái tin
        public string CapNhatTrangThaiTin(int maTin, TrangThaiTinOGhep trangThai)
        {
            if (maTin <= 0) return "Mã tin không hợp lệ!";

            // Sửa: kiểm tra enum hợp lệ thay vì string array
            if (!Enum.IsDefined(typeof(TrangThaiTinOGhep), trangThai))
                return "Trạng thái không hợp lệ!";

            return dalTinOGhep.CapNhatTrangThaiTin(maTin, trangThai) ? "" : "Cập nhật trạng thái thất bại!";
        }

        // 5 Lấy danh sách tin theo phòng
        public DataTable LayDanhSachTinTheoPhong(int maPhong)
        {
            if (maPhong <= 0) return new DataTable();
            return dalTinOGhep.LayDanhSachTinTheoPhong(maPhong);
        }
    }
}