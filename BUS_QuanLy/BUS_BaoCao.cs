using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_BaoCao
    {
        private DAL_BAOCAO dalBaoCao = new DAL_BAOCAO();

        // 1 Thống kê phòng
        public DataTable ThongKePhong() => dalBaoCao.ThongKePhong();

        // 2 Thống kê doanh thu — kiểm tra tháng/năm hợp lệ
        public DataTable ThongKeDoanhThu(int thang, int nam)
        {
            if (nam < 2000 || nam > 2100)
                return new DataTable();
            if (thang < 0 || thang > 12)
                return new DataTable();
            return dalBaoCao.ThongKeDoanhThu(thang, nam);
        }

        // 3 Thống kê lịch hẹn
        public DataTable ThongKeLichHen(int thang, int nam)
        {
            if (thang < 1 || thang > 12 || nam < 2000)
                return new DataTable();
            return dalBaoCao.ThongKeLichHen(thang, nam);
        }

        // 4 Báo cáo chất lượng
        public DataTable BaoCaoChatLuong() => dalBaoCao.BaoCaoChatLuong();

    // Lưu một bản ghi báo cáo mới vào DB
        public string LuuBaoCao(DTO_BAOCAO bc)
        {
            if (bc.MANV <= 0)
                return "Nhân viên lập báo cáo không hợp lệ!";
            if (!Enum.IsDefined(typeof(LoaiBaoCao), bc.LOAIBC))
            {
                return "Loại báo cáo không hợp lệ!";
            }

            if (string.IsNullOrWhiteSpace(bc.NOIDUNGBC))
                return "Nội dung báo cáo không được để trống!";

            bc.THOIGIANBC = DateTime.Now;

            return dalBaoCao.LuuBaoCao(bc) ? "" : "Thất bại: Lỗi hệ thống khi lưu báo cáo!";
        }

        //  Lấy lịch sử các báo cáo đã lưu
        public DataTable LayDanhSachBaoCao()
        {
            DataTable dt = dalBaoCao.LayDanhSachBaoCao();

            // Nếu kết quả từ DAL bị null, trả về một DataTable trống để an toàn cho giao diện
            if (dt == null) return new DataTable();

            return dt;
        }
    }
}