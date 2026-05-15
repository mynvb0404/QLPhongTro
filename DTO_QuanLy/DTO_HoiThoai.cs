using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoiThoai
    {
        public int MAHT { get; set; }

        public int MAKH { get; set; }

        public int MANV { get; set; }

        public DateTime THOIGIANTAOHT { get; set; }

        public DTO_HoiThoai() { }

        public DTO_HoiThoai(int maht, int makh, int manv, DateTime thoigiantaoht)
        {
            MAHT = maht;
            MAKH = makh;
            MANV = manv;
            THOIGIANTAOHT = thoigiantaoht;
        }
    }
}