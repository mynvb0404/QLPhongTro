using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum TrangThaiYeuCau
    {
        ChoDuyet,  // Chờ duyệt
        DaDuyet,   // Đã duyệt
        TuChoi     // Từ chối
    }
    // Enum cho trạng thái tin ở ghép
    public enum TrangThaiTinOGhep
    {
        DangTim,    // Đang tìm
        DaDuNguoi,  // Đã đủ người
        DaDong      // Đã đóng
    }
    public class DTO_TINOGHEP
    {
        public int MATINOG { get; set; }

        public int MAPHONG { get; set; }

        public int MAKH { get; set; }

        public int SONGUOICAN { get; set; }

        public GioiTinh GIOITINH { get; set; }

        public decimal GIACHIA { get; set; }

        public string MOTA { get; set; } = "";

        public TrangThaiTinOGhep TRANGTHAITIN { get; set; }

        public TrangThaiYeuCau TRANGTHAIYEUCAU { get; set; }
        public DTO_TINOGHEP() { }

        public DTO_TINOGHEP(int matinog, int maphong, int makh, int songuoican,
                           GioiTinh gioitinh, decimal giachia,
                            string mota, TrangThaiTinOGhep trangthaitin, TrangThaiYeuCau trangthaiyeucau)
        {
            MATINOG = matinog;
            MAPHONG = maphong;
            MAKH = makh;
            SONGUOICAN = songuoican;
            GIOITINH = gioitinh;
            GIACHIA = giachia;
            MOTA = mota;
            TRANGTHAITIN = trangthaitin;
            TRANGTHAIYEUCAU = trangthaiyeucau;
        }
    }
}