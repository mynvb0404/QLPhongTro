using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan : DBConnect
    {
        // Kiểm tra đăng nhập
        public DataTable KiemTraDangNhap(string tenDN, string matKhau)
        {
            string query = "SELECT TENDANGNHAP, LOAITK FROM TAIKHOAN WHERE TENDANGNHAP = @TENDANGNHAP AND MATKHAU = @MATKHAU";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TENDANGNHAP", tenDN),
                new SqlParameter("@MATKHAU", matKhau)
            };

            return ExecuteQuery(query, parameters);
        }

        // 1. Thêm tài khoản
        public bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            string query = "INSERT INTO TAIKHOAN (MATK, MANV, MAKH, TENDANGNHAP, MATKHAU, LOAITK) VALUES (@MATK, @MANV, @MAKH, @TENDANGNHAP, @MATKHAU, @LOAITK)";

            string maTKAuto = "";

            if (tk.LOAITK == "NV")
            {
                maTKAuto = "NV" + (tk.MANV.HasValue ? tk.MANV.Value.ToString("D3") : "000");
            }
            else if (tk.LOAITK == "KH")
            {
                maTKAuto = "KH" + (tk.MAKH.HasValue ? tk.MAKH.Value.ToString("D3") : "000");
            }
            else
            {
                maTKAuto = tk.MATK;
            }

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MATK", maTKAuto),
                new SqlParameter("@MANV", tk.MANV.HasValue ? tk.MANV : DBNull.Value),
                new SqlParameter("@MAKH", tk.MAKH.HasValue ? tk.MAKH : DBNull.Value),
                new SqlParameter("@TENDANGNHAP", tk.TENDANGNHAP),
                new SqlParameter("@MATKHAU", tk.MATKHAU),
                new SqlParameter("@LOAITK", tk.LOAITK)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 2. Sửa tài khoản
        public bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            string query = "UPDATE TAIKHOAN SET TENDANGNHAP = @TENDANGNHAP, MATKHAU = @MATKHAU WHERE MATK = @MATK";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MATK", tk.MATK),
                new SqlParameter("@TENDANGNHAP", tk.TENDANGNHAP),
                new SqlParameter("@MATKHAU", tk.MATKHAU),
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 3. Xóa tài khoản
        public bool XoaTaiKhoan(string maTK)
        {
            string query = "DELETE FROM TAIKHOAN WHERE MATK = @MATK";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MATK", maTK)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 4. Tìm kiếm tài khoản
        public DataTable TimKiemTaiKhoan(string keyword)
        {
            string query = "SELECT MATK, MANV, MAKH, TENDANGNHAP, LOAITK FROM TAIKHOAN WHERE MATK LIKE @MATK OR TENDANGNHAP LIKE @TENDANGNHAP";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MATK", "%" + keyword + "%"),
                new SqlParameter("@TENDANGNHAP", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }
    }
}