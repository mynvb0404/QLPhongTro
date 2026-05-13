using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KHACHTHUE
    {
        public int MAKH { get; set; }

        public string HOKH { get; set; } = "";

        public string TENKH { get; set; } = "";

        public DateTime? NGAYSINH { get; set; }

        public string? GIOITINH { get; set; }

        public string CCCD { get; set; } = "";

        public string SDT { get; set; } = "";

        public DateTime NGAYBATDAUTHUE { get; set; }

        public string TRANGTHAITHUE { get; set; } = "";

        public DTO_KHACHTHUE() { }

        public DTO_KHACHTHUE(int makh, string hokh, string tenkh, DateTime? ngaysinh,
                             string? gioitinh, string cccd, string sdt,
                             DateTime ngaybatdauthue, string trangthaithue)
        {
            MAKH = makh;
            HOKH = hokh;
            TENKH = tenkh;
            NGAYSINH = ngaysinh;
            GIOITINH = gioitinh;
            CCCD = cccd;
            SDT = sdt;
            NGAYBATDAUTHUE = ngaybatdauthue;
            TRANGTHAITHUE = trangthaithue;
        }
    }
}