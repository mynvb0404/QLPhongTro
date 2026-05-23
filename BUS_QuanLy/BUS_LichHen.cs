using System;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_LichHen
    {
        private DAL_LICHHEN dalLichHen = new DAL_LICHHEN();

        public DataTable LayDanhSachLichHen() => dalLichHen.LayDanhSachLichHen();


        // 1 Thêm lịch hẹn
        public string ThemLichHen(DTO_LICHHEN lh)
        {
            if (lh.MAKH <= 0)
                return "Mã khách hàng không được để trống!";
            if (lh.MANV <= 0) return "Vui lòng chọn nhân viên phụ trách!";
            if (lh.MAPHONG <= 0)
                return "Mã phòng không được để trống!";

            if (lh.THOIGIANHEN.Date < DateTime.Today)
                return "Ngày hẹn không được là ngày trong quá khứ!";
            lh.TRANGTHAIHEN = TrangThaiLichHen.DaDat;

            return dalLichHen.ThemLichHen(lh) ? "" : "Thêm lịch hẹn thất bại!";
        }

        // 2 Sửa thông tin lịch hẹn
        public string SuaLichHen(DTO_LICHHEN lh)
        {
            if (lh.MALH <= 0) return "Mã lịch hẹn không hợp lệ!";
            lh.THOIGIANCAPNHAT = DateTime.Now;
            if (lh.THOIGIANHEN.Date < DateTime.Today)
                return "Ngày hẹn không được là ngày trong quá khứ!";

            return dalLichHen.SuaLichHen(lh) ? "" : "Cập nhật thất bại!";
        }

        // 3 Xóa lịch hẹn
        public string XoaLichHen(int maLH)
        {
            if (maLH <= 0) return "Mã lịch hẹn không hợp lệ!";
            return dalLichHen.XoaLichHen(maLH) ? "" : "Xóa thất bại!";
        }

        // 4. Xem chi tiết lịch hẹn
        public DataTable XemChiTietLichHen(int maLH)
        {
            if (maLH <= 0) return new DataTable();

            DataTable dt = dalLichHen.XemChiTietLichHen(maLH);

            if (dt == null || dt.Rows.Count == 0)
            {
                return new DataTable();
            }

            return dt;
        }
        // 5 Cập nhật trạng thái lịch hẹn
        public string CapNhatTrangThai(int maLH, TrangThaiLichHen trangThai)
        {
            if (maLH <= 0)
                return "Mã lịch hẹn không hợp lệ!";

            // 2. Kiểm tra giá trị Enum truyền vào có tồn tại trong định nghĩa không
            if (!Enum.IsDefined(typeof(TrangThaiLichHen), trangThai))
                return "Trạng thái không hợp lệ!";

            return dalLichHen.CapNhatTrangThaiLichHen(maLH, trangThai) ? "" : "Cập nhật thất bại!";
        }

        public DataTable ThongKeLichHen(int thang, int nam)
        {
            if (nam < 0) return new DataTable();
            return dalLichHen.ThongKeLichHen(thang, nam);
        }
    }
}