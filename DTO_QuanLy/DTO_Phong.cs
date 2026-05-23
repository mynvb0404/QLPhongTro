using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Phong
    {
        public int MAPHONG { get; set; }

        public string TENPHONG { get; set; } = "";

        public string MAKV { get; set; } = "";

        public decimal? GIAPHONG { get; set; }

        public double? DIENTICH { get; set; }

        public string LOAIPHONG { get; set; } = "";

        public string TRANGTHAIPHONG { get; set; } = "";

        public int? SONGUOIHIENTAI { get; set; }

        public string? NOITHAT { get; set; }

        public DTO_Phong() { }

        public DTO_Phong(int maphong, string tenphong, string makv, decimal? giaphong,
                         double? dientich, string loaiphong, string trangthaiphong,
                         int? songuoihientai, string? noithat)
        {
            MAPHONG = maphong;
            TENPHONG = tenphong;
            MAKV = makv;
            GIAPHONG = giaphong;
            DIENTICH = dientich;
            LOAIPHONG = loaiphong;
            TRANGTHAIPHONG = trangthaiphong;
            SONGUOIHIENTAI = songuoihientai;
            NOITHAT = noithat;
        }
    }
}