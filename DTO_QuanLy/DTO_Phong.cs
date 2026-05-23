using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum TinhTrangPhong
    {
        ConTrong,   // Còn trống
        DaThue,     // Đã thuê
        CanOGhep    // Cần ở ghép
    }

    public class DTO_PHONG
    {
        public int MAPHONG { get; set; }

        public string MAKV { get; set; } = "";

        public string TENPHONG { get; set; } = "";

        public decimal GIAPHONG { get; set; }

        public double? DIENTICH { get; set; }

        public string LOAIPHONG { get; set; } = "";

        public TinhTrangPhong TRANGTHAIPHONG { get; set; }

        public int SONGUOIHIENTAI { get; set; }

        public string? NOITHAT { get; set; }

        public DTO_PHONG() { }

        public DTO_PHONG(int maphong, string makv, string tenphong, decimal giaphong,
                         double? dientich, string loaiphong, TinhTrangPhong trangthaiphong,
                         int songuoihientai, string? noithat)
        {
            MAPHONG = maphong;
            MAKV = makv;
            TENPHONG = tenphong;
            GIAPHONG = giaphong;
            DIENTICH = dientich;
            LOAIPHONG = loaiphong;
            TRANGTHAIPHONG = trangthaiphong;
            SONGUOIHIENTAI = songuoihientai;
            NOITHAT = noithat;
        }
    }
}