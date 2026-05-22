using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_TAIKHOAN : DBConnect
    {
        public DataTable LayDanhSachTaiKhoan()
        {
            // Câu lệnh SQL tối ưu: Left Join sang bảng NHANVIEN và KHACHTHUE để lấy Tên tương ứng
            string query = @"
                SELECT 
                    TK.MATK AS [Mã tài khoản],
                    TK.TENDANGNHAP AS [Tên đăng nhập],
                    CASE 
                        WHEN TK.LOAITK = 'NV' THEN N'Nhân viên'
                        WHEN TK.LOAITK = 'KH' THEN N'Khách hàng'
                        ELSE TK.LOAITK 
                    END AS [Loại tài khoản],
                    ISNULL(NV.TENNV, K.TENKH) AS [Người sở hữu],
                    TK.MANV AS [Mã nhân viên],
                    TK.MAKH AS [Mã khách hàng]
                FROM TAIKHOAN TK
                LEFT JOIN NHANVIEN NV ON TK.MANV = NV.MANV
                LEFT JOIN KHACHTHUE K ON TK.MAKH = K.MAKH";

            try
            {
                // Thực thi câu lệnh truy vấn qua lớp cha DBConnect
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi hệ thống hoặc SQL, ghi nhận lỗi hoặc trả về bảng trống để tránh crash GUI
                Console.WriteLine("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
                return new DataTable();
            }
        }
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

        // KIỂM TRA TỒN TẠI (Dùng để chặn trùng tên khi đăng ký/thêm mới)
        public bool KiemTraTonTai(string tenDN)
        {
            string query = "SELECT COUNT(*) FROM TAIKHOAN WHERE TENDANGNHAP = @TEN";

            DataTable dt = ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@TEN", tenDN) });

            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }
        // 1. Thêm tài khoản
        public bool ThemTaiKhoan(DTO_TAIKHOAN tk)
        {
            string query = "INSERT INTO TAIKHOAN (MATK, MANV, MAKH, TENDANGNHAP, MATKHAU, LOAITK) VALUES (@MATK, @MANV, @MAKH, @TENDANGNHAP, @MATKHAU, @LOAITK)";

            string maTKAuto = "";

            if (tk.LOAITK == LoaiTaiKhoan.NV)
            {
                maTKAuto = "NV" + (tk.MANV.HasValue ? tk.MANV.Value.ToString("D3") : "000");
            }
            else if (tk.LOAITK == LoaiTaiKhoan.KH)
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
        public bool SuaTaiKhoan(DTO_TAIKHOAN tk)
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