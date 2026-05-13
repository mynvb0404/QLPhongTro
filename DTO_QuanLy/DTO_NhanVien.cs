using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NHANVIEN
    {
        public int MANV { get; set; }
        public string HONV { get; set; } = "";
        public string TENNV { get; set; } = "";
        public string? SDT { get; set; }
        public string? EMAIL { get; set; }
        public string? CHUCVU { get; set; }

        public DTO_NHANVIEN() { }

        public DTO_NHANVIEN(int manv, string honv, string tennv, string? sdt, string? email, string? chucvu)
        {
            MANV = manv;
            HONV = honv;
            TENNV = tennv;
            SDT = sdt;
            EMAIL = email;
            CHUCVU = chucvu;
        }
    }
}