using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HopDong
    {
        public string MAHOPDONG { get; set; } = "";

        public int MAPHONG { get; set; }

        public int MAKH { get; set; }

        public DateTime NGAYKYHD { get; set; }

        public DateTime NGAYKT { get; set; }

        public string TRANGTHAIHOPDONG { get; set; } = "";

        public string THONGTINHD { get; set; } = "";

        public DTO_HopDong()
        {

        }

        public DTO_HopDong(string mahd, int maphong, int makh, DateTime ngayky, DateTime ngaykt, string trangthai, string thongtin)
        {
            this.MAHOPDONG = mahd;
            this.MAPHONG = maphong;
            this.MAKH = makh;
            this.NGAYKYHD = ngayky;
            this.NGAYKT = ngaykt;
            this.TRANGTHAIHOPDONG = trangthai;
            this.THONGTINHD = thongtin;
        }
    }
}