using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaDon
    {
        public int MAHOADON { get; set; }

        public int MAHOPDONG { get; set; }

        public DateTime NGAYLAP { get; set; }

        public decimal TIENNUOC { get; set; }

        public decimal TIENDIEN { get; set; }

        public decimal TIENPHATSINH { get; set; }

        public decimal TONGTIEN { get; set; }

        public string TRANGTHAITT { get; set; } = "";

        public DTO_HoaDon() { }

        public DTO_HoaDon(int mahoadon, int mahopdong, DateTime ngaylap,
                          decimal tiennuoc, decimal tiendien,
                          decimal tienphatsinh, decimal tongtien,
                          string trangthaitt)
        {
            MAHOADON = mahoadon;
            MAHOPDONG = mahopdong;
            NGAYLAP = ngaylap;
            TIENNUOC = tiennuoc;
            TIENDIEN = tiendien;
            TIENPHATSINH = tienphatsinh;
            TONGTIEN = tongtien;
            TRANGTHAITT = trangthaitt;
        }
    }
}