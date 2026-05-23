using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum TrangThaiHopDong
    {
        ConHieuLuc, // Còn hiệu lực
        HetHieuLuc  // Hết hiệu lực
    }

    public class DTO_HOPDONG
    {
        public int MAHOPDONG { get; set; }

        public int MAPHONG { get; set; }

        public int MAKH { get; set; }

        public DateTime NGAYKYHD { get; set; }

        public DateTime NGAYKT { get; set; }

        public TrangThaiHopDong TRANGTHAIHOPDONG { get; set; }

        public string THONGTINHD { get; set; } = "";

        public DTO_HOPDONG() { }

        public DTO_HOPDONG(int mahopdong, int maphong, int makh,
                           DateTime ngaykyhd, DateTime ngaykt,
                           TrangThaiHopDong trangthaihopdong, string thongtinhd)
        {
            MAHOPDONG = mahopdong;
            MAPHONG = maphong;
            MAKH = makh;
            NGAYKYHD = ngaykyhd;
            NGAYKT = ngaykt;
            TRANGTHAIHOPDONG = trangthaihopdong;
            THONGTINHD = thongtinhd;
        }
    }
}