using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LICHHEN
    {
        public int MALH { get; set; }

        public int MAKH { get; set; }

        public int MANV { get; set; }

        public int MAPHONG { get; set; }

        public DateTime THOIGIANHEN { get; set; }

        public string TRANGTHAIHEN { get; set; } = "";

        public string? NOIDUNGHEN { get; set; }

        public DateTime THOIGIANTAO { get; set; }

        public DateTime? THOIGIANCAPNHAT { get; set; }

        public DTO_LICHHEN() { }

        public DTO_LICHHEN(int malh, int makh, int manv, int maphong,
                           DateTime thoigianhen, string trangthaihen,
                           string? noidunghen, DateTime thoigiantao,
                           DateTime? thoigiancapnhat)
        {
            MALH = malh;
            MAKH = makh;
            MANV = manv;
            MAPHONG = maphong;
            THOIGIANHEN = thoigianhen;
            TRANGTHAIHEN = trangthaihen;
            NOIDUNGHEN = noidunghen;
            THOIGIANTAO = thoigiantao;
            THOIGIANCAPNHAT = thoigiancapnhat;
        }
    }
}