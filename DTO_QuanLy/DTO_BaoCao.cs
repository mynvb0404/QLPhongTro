using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum LoaiBaoCao
    {
        ThongKePhong,   // Thống kê phòng
        ThongKeDoanhThu,  // Thống kê doanh thu
        ThongKeLichHen,   // Thống kê lịch hẹn
    }
    public class DTO_BAOCAO
    {
        public int MABC { get; set; }

        public int MANV { get; set; }

        public LoaiBaoCao LOAIBC { get; set; }

        public string NOIDUNGBC { get; set; } = "";

        public DateTime THOIGIANBC { get; set; }

        public DTO_BAOCAO() { }

        public DTO_BAOCAO(int mabc, int manv, LoaiBaoCao loaibc, string noidungbc, DateTime thoigianbc)
        {
            MABC = mabc;
            MANV = manv;
            LOAIBC = loaibc;
            NOIDUNGBC = noidungbc;
            THOIGIANBC = thoigianbc;
        }
    }
}