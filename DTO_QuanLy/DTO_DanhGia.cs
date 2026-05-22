using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_DanhGia
    {

        public int MADG { get; set; }

        public int MANGUOIDG { get; set; }

        public int MANGUOIDUOCDG { get; set; }

        public int MAHOPDONG { get; set; }

        public int DIEM { get; set; }

        public string NOIDUNG { get; set; } = "";

        public DateTime THOIGIAN { get; set; }

        public DTO_DanhGia() { }

        public DTO_DanhGia(int madg, int manguoidg, int manguoiduocdg,
                           int mahopdong, int diem, string noidung, DateTime thoigian)
        {
            MADG = madg;
            MANGUOIDG = manguoidg;
            MANGUOIDUOCDG = manguoiduocdg;
            MAHOPDONG = mahopdong;
            DIEM = diem;
            NOIDUNG = noidung;
            THOIGIAN = thoigian;
        }
    }
}

