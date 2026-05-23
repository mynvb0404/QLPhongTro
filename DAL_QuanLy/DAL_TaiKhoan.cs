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

        //Kiểm tra tồn tại
        public bool KiemTraTonTai(string tenDangNhap)
        {
            string query = "SELECT COUNT(*) FROM TAIKHOAN WHERE TENDANGNHAP = @TenDN";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenDN", tenDangNhap)
            };

            object result = ExecuteScalar(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result) > 0;
            }
            return false;
        }


        //Đăng nhập
        public DTO_TaiKhoan DangNhap(string tenDN, string matKhau)
        {
            string query = "SELECT TENDANGNHAP, MATKHAU, LOAITK, MANV, MAKH FROM TAIKHOAN " +
                           "WHERE TENDANGNHAP = @TenDN AND MATKHAU = @MatKhau";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenDN", tenDN),
                new SqlParameter("@MatKhau", matKhau)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                DTO_TaiKhoan tk = new DTO_TaiKhoan()
                {
                    TENDANGNHAP = row["TENDANGNHAP"].ToString(),
                    MATKHAU = row["MATKHAU"].ToString(),
                    LOAITK = row["LOAITK"].ToString(),
                    MANV = row["MANV"] != DBNull.Value ? (int?)Convert.ToInt32(row["MANV"]) : null,
                    MAKH = row["MAKH"] != DBNull.Value ? (int?)Convert.ToInt32(row["MAKH"]) : null
                };
                return tk;
            }

            return null;
        }

        // 1. Thêm tài khoản
        public bool ThemTaiKhoan(DTO_TaiKhoan tk)
        {
            string query = "INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU, LOAITK, MANV, MAKH) VALUES (@TenDN, @MK, @LoaiTK, @MaNV, @MaKH)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenDN", tk.TENDANGNHAP),
                new SqlParameter("@MK", tk.MATKHAU),
                new SqlParameter("@LoaiTK", tk.LOAITK),
                new SqlParameter("@MaNV", (object)tk.MANV ?? DBNull.Value),
                new SqlParameter("@MaKH", (object)tk.MAKH ?? DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        // lấy danh sách tài khoản
        public DataTable LayDanhSachTaiKhoan()
        {
            string query = "SELECT * FROM TAIKHOAN";
            return ExecuteQuery(query);
        }

        // 2. Sửa tài khoản
        public bool SuaTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                string loaiTK = tk.LOAITK?.Trim().ToUpper();
                string cotDieuKien = (loaiTK == "NV") ? "MANV" : "MAKH";
                int? idDoiTuong = (loaiTK == "NV") ? tk.MANV : tk.MAKH;

                if (idDoiTuong == null)
                {
                    throw new Exception("Mã đối tượng (MANV/MAKH) truyền vào bị NULL!");
                }

                string queryCheck = $"SELECT COUNT(*) FROM TAIKHOAN WHERE {cotDieuKien} = @IDDoiTuong";
                SqlParameter[] paramCheck = { new SqlParameter("@IDDoiTuong", idDoiTuong.Value) };

                object checkResult = ExecuteScalar(queryCheck, paramCheck);
                bool daCoTaiKhoan = (checkResult != null && Convert.ToInt32(checkResult) > 0);

                string query;
                SqlParameter[] parameters;

                if (daCoTaiKhoan)
                {
                    query = $@"UPDATE TAIKHOAN 
                      SET TENDANGNHAP = @TENDANGNHAP, 
                          MATKHAU = @MATKHAU 
                      WHERE {cotDieuKien} = @IDDoiTuong";

                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@IDDoiTuong", idDoiTuong.Value),
                        new SqlParameter("@TENDANGNHAP", tk.TENDANGNHAP),
                        new SqlParameter("@MATKHAU", tk.MATKHAU)
                    };
                }
                else
                {
                    string matkMoi = (loaiTK == "NV") ? $"NV{idDoiTuong.Value}" : $"KH{idDoiTuong.Value}";

                    if (loaiTK == "NV")
                    {
                        query = "INSERT INTO TAIKHOAN (MATK, TENDANGNHAP, MATKHAU, LOAITK, MANV, MAKH) VALUES (@MATK, @TENDANGNHAP, @MATKHAU, 'NV', @IDDoiTuong, NULL)";
                    }
                    else
                    {
                        query = "INSERT INTO TAIKHOAN (MATK, TENDANGNHAP, MATKHAU, LOAITK, MANV, MAKH) VALUES (@MATK, @TENDANGNHAP, @MATKHAU, 'KH', NULL, @IDDoiTuong)";
                    }

                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MATK", matkMoi),
                        new SqlParameter("@IDDoiTuong", idDoiTuong.Value),
                        new SqlParameter("@TENDANGNHAP", tk.TENDANGNHAP),
                        new SqlParameter("@MATKHAU", tk.MATKHAU)
                    };
                }

                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"[Lỗi Hệ Thống SQL]: {ex.Message}");
            }
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