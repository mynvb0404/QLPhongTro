using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public enum TrangThaiThanhToan
    {
        ChuaThanhToan, // Chưa thanh toán
        DaThanhToan    // Đã thanh toán
    }

    // Enum cho phương thức thanh toán
    public enum PhuongThucThanhToan
    {
        TienMat,      // Tiền mặt
        ChuyenKhoan,  // Chuyển khoản
        QuetMaQR      // Quét mã QR
    }
    public class DTO_HOADON
    {
        public int MAHOADON { get; set; }

        public string MAHOPDONG { get; set; }

        public DateTime NGAYLAP { get; set; }

        public decimal TIENNUOC { get; set; }

        public decimal TIENDIEN { get; set; }

        public decimal TIENPHATSINH { get; set; }

        public decimal TIENTHUENHA { get; set; }

        public decimal TONGTIEN { get; set; }

        public TrangThaiThanhToan TRANGTHAITT { get; set; }

        public DateTime? NGAYTHANHTOAN { get; set; }

        public PhuongThucThanhToan? PHUONGTHUCTT { get; set; }


        public DTO_HOADON() { }

        public DTO_HOADON(int mahoadon, string mahopdong, DateTime ngaylap,
                          decimal tiennuoc, decimal tiendien,
                          decimal tienphatsinh, decimal tienthuenha, decimal tongtien,
                          TrangThaiThanhToan trangthaitt, DateTime? ngaythanhtoan,
                          PhuongThucThanhToan? phuongthuctt)
        {
            MAHOADON = mahoadon;
            MAHOPDONG = mahopdong;
            NGAYLAP = ngaylap;
            TIENNUOC = tiennuoc;
            TIENDIEN = tiendien;
            TIENPHATSINH = tienphatsinh;
            TIENTHUENHA = tienthuenha;
            TONGTIEN = tongtien;
            TRANGTHAITT = trangthaitt;
            NGAYTHANHTOAN = ngaythanhtoan;
            PHUONGTHUCTT = phuongthuctt;
        }
    }
}