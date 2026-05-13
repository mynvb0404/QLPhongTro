using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HOITHOAI
    {
        public int MAHT { get; set; }

        public int MAKH { get; set; }

        public int MANV { get; set; }

        public DateTime THOIGIANTAOHT { get; set; }

        public DTO_HOITHOAI() { }

        public DTO_HOITHOAI(int maht, int makh, int manv, DateTime thoigiantaoht)
        {
            MAHT = maht;
            MAKH = makh;
            MANV = manv;
            THOIGIANTAOHT = thoigiantaoht;
        }
    }
}