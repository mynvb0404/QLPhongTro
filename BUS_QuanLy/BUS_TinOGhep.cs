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
        public DataTable TimKiemTinOGhep(string gioiTinh, decimal giaMax, string tuKhoa)
        {
            string gioiTinhChuan = string.IsNullOrWhiteSpace(gioiTinh) ? "" : gioiTinh.Trim();
            string tuKhoaChuan = string.IsNullOrWhiteSpace(tuKhoa) ? "" : tuKhoa.Trim();
            decimal giaChuan = giaMax < 0 ? 0 : giaMax;

            return dalTinOGhep.TimKiemTinOGhep(gioiTinhChuan, giaChuan, tuKhoaChuan); // Sửa: đúng tên hàm DAL
        }

        // Chưa dùng 
        // 3. Gửi yêu cầu ở ghép (đăng tin với trạng thái mặc định DangTim)
        public string GuiYeuCauOGhep(DTO_TINOGHEP og)
        {
            if (og.MAPHONG <= 0) return "Mã phòng không hợp lệ!"; // Sửa: MAPHONG là int
            if (og.MAKH <= 0) return "Mã khách hàng không hợp lệ!";
            og.TRANGTHAITIN = TrangThaiTinOGhep.DangTim;
            return dalTinOGhep.ThemTinOGhep(og) ? "" : "Gửi yêu cầu thất bại!";
        }

        // 4 Xử lý yêu cầu ở ghép
        public string XuLyYeuCau(int maTin, TrangThaiYeuCau trangThai)
        {
            if (trangThai == TrangThaiYeuCau.ChoDuyet)
            {
                return "Vui lòng chọn Duyệt hoặc Từ chối!";
            }
            return dalTinOGhep.XuLyYeuCau(maTin, trangThai) ? "" : "Xử lý thất bại!";
        }

      // Phần này dùng 
        // 3 Sửa tin ở ghép
        public string SuaTinOGhep(DTO_TINOGHEP og)
        {
            if (og.MATINOG <= 0) return "Mã tin không hợp lệ!";
            if (og.SONGUOICAN <= 0) return "Số người cần phải lớn hơn 0!";
            if (og.GIACHIA <= 0) return "Giá chia sẻ phải lớn hơn 0!";
            if (string.IsNullOrWhiteSpace(og.MOTA)) return "Mô tả không được để trống!";

            return dalTinOGhep.SuaTinOGhep(og) ? "" : "Cập nhật tin thất bại!";
        }

        // 4 Cập nhật trạng thái tin (Duyệt/Đóng tin)
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

        // 6 Đánh giá và phản hồi
        public string DanhGiaOGhep(int maTin, string danhGia)
        {
            if (string.IsNullOrWhiteSpace(danhGia))
                return "Nội dung đánh giá không được để trống!";
            if (danhGia.Length > 500)
                return "Nội dung đánh giá không được quá 500 ký tự!";
            return dalTinOGhep.DanhGiaOGhep(maTin, danhGia) ? "" : "Gửi đánh giá thất bại!";
        }
    }
}