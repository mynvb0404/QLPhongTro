using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum LoaiTaiKhoan
    {
        NV, // Nhân viên
        KH  // Khách hàng
    }

    public class DTO_TAIKHOAN
    {
        public string MATK { get; set; } = "";

        public int? MANV { get; set; }

        public int? MAKH { get; set; }

        public string TENDANGNHAP { get; set; } = "";

        public string MATKHAU { get; set; } = "";

        public LoaiTaiKhoan LOAITK { get; set; }

        public DTO_TAIKHOAN() { }

        public DTO_TAIKHOAN(string matk, int? manv, int? makh,
                            string tendangnhap, string matkhau, LoaiTaiKhoan loaitk)
        {
            MATK = matk;
            MANV = manv;
            MAKH = makh;
            TENDANGNHAP = tendangnhap;
            MATKHAU = matkhau;
            LOAITK = loaitk;
        }
    }
}