using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum GioiTinh
    {
        Nam,
        Nu
    }

    //  Enum cho trạng thái thuê
    public enum TrangThaiKhachThue
    {
        DangThue,   // Đang thuê
        DaTraPhong   // Đã trả phòng
    }

    public class DTO_KHACHTHUE
    {
        public int MAKH { get; set; }

        public string HOKH { get; set; } = "";

        public string TENKH { get; set; } = "";

        public DateTime? NGAYSINH { get; set; }

        public GioiTinh? GIOITINH { get; set; }

        public string CCCD { get; set; } = "";

        public string SDT { get; set; } = "";

        public DateTime NGAYBATDAUTHUE { get; set; }

        public TrangThaiKhachThue TRANGTHAITHUE { get; set; }
        
        public string TRANGTHAITHUE { get; set; } = "";

        public DTO_KHACHTHUE() { }

        public DTO_KHACHTHUE(int makh, string hokh, string tenkh, DateTime? ngaysinh,
                             GioiTinh? gioitinh, string cccd, string sdt,
                             DateTime ngaybatdauthue, TrangThaiKhachThue trangthaithue)
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