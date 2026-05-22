using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_TINOGHEP : DBConnect
    {
        private string GetStringTrangThaiTin(TrangThaiTinOGhep tt)
        {
            switch (tt)
            {
                case TrangThaiTinOGhep.DangTim: return "Đang tìm";
                case TrangThaiTinOGhep.DaDuNguoi: return "Đã đủ người";
                case TrangThaiTinOGhep.DaDong: return "Đã đóng";
                default: return "Đang tìm";
            }
        }

        public DataTable LayDanhSachTinOGhep()
        {
            return ExecuteQuery("SELECT * FROM TINOGHEP");
        }

        //1 Đăng tin ở ghép
        public bool ThemTinOGhep(DTO_TINOGHEP og)
        {
            string query = @"INSERT INTO TINOGHEP (MAPHONG, MAKH, SONGUOICAN, GIOITINH, GIACHIA, MOTA, TRANGTHAITIN)
                             VALUES (@MAPHONG, @MAKH, @SONGUOICAN, @GIOITINH, @GIACHIA, @MOTA, @TRANGTHAITIN)";
            SqlParameter[] p = {
                new SqlParameter("@MAPHONG",     og.MAPHONG),
                new SqlParameter("@MAKH",        og.MAKH),
                new SqlParameter("@SONGUOICAN",  og.SONGUOICAN),
                new SqlParameter("@GIOITINH",    og.GIOITINH.ToString()),
                new SqlParameter("@GIACHIA",     og.GIACHIA),
                new SqlParameter("@MOTA",        og.MOTA),
                new SqlParameter("@TRANGTHAITIN", GetStringTrangThaiTin(og.TRANGTHAITIN))
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        public bool SuaTinOGhep(DTO_TINOGHEP og)
        {
            string query = @"UPDATE TINOGHEP 
                             SET SONGUOICAN  = @SONGUOICAN,
                                 GIOITINH   = @GIOITINH,
                                 GIACHIA    = @GIACHIA,
                                 MOTA       = @MOTA
                             WHERE MATINOG = @MATINOG";
            SqlParameter[] p = {
                new SqlParameter("@SONGUOICAN", og.SONGUOICAN),
                new SqlParameter("@GIOITINH",   og.GIOITINH.ToString()),
                new SqlParameter("@GIACHIA",    og.GIACHIA),
                new SqlParameter("@MOTA",       og.MOTA),
                new SqlParameter("@MATINOG",    og.MATINOG)
            };
            return ExecuteNonQuery(query, p) > 0;
        }
        // 2 Tìm kiếm tin ở ghép
        public DataTable TimKiemTinOGhep(string gioiTinh, decimal giaChiaMax, string tuKhoa)
        {
            // Sử dụng JOIN để lấy Tên phòng từ bảng PHONG và Tên khách từ bảng KHACHTHUE
            string query = @"SELECT 
                        T.MATINOG, 
                        P.TENPHONG, 
                        (K.HOKH + ' ' + K.TENKH) AS HOTENKHACH, 
                        T.SONGUOICAN, 
                        T.GIOITINH, 
                        T.GIACHIA, 
                        T.MOTA, 
                        T.TRANGTHAITIN
                    FROM TINOGHEP T
                    INNER JOIN PHONG P ON T.MAPHONG = P.MAPHONG
                    INNER JOIN KHACHTHUE K ON T.MAKH = K.MAKH
                    WHERE T.TRANGTHAITIN = N'Đang tìm'
                      AND (@GIOITINH = '' OR T.GIOITINH = @GIOITINH)
                      AND (@GIACHAMAX = 0 OR T.GIACHIA <= @GIACHAMAX)
                      AND (@TUKHOA = '' OR T.MOTA LIKE @TUKHOA)";

            SqlParameter[] p = {
        new SqlParameter("@GIOITINH", gioiTinh ?? ""),
        new SqlParameter("@GIACHAMAX", giaChiaMax),
        new SqlParameter("@TUKHOA", string.IsNullOrEmpty(tuKhoa) ? "" : "%" + tuKhoa + "%")
    };

            return ExecuteQuery(query, p);
        }

        // Chưa dùng  3 Gửi yêu cầu = thêm tin với trạng thái 'Đang tìm'
        public bool GuiYeuCauOGhep(DTO_TINOGHEP og)
        {
            og.TRANGTHAIYEUCAU = TrangThaiYeuCau.ChoDuyet;
            return ThemTinOGhep(og);
        }

        // Trong DAL_TinOGhep.cs
        public bool XuLyYeuCau(int maTinOGhep, TrangThaiYeuCau trangThai)
        {
            string query = "UPDATE YEUCAU SET TRANGTHAIYEUCAU = @TRANGTHAIYEUCAU  WHERE MATINOG = @MATINOG";
            SqlParameter[] p = {
              new SqlParameter("@TRANGTHAIYEUCAU", trangThai == TrangThaiYeuCau.DaDuyet ? "Đã duyệt" : "Từ chối"),
              new SqlParameter("@MATINOG", maTinOGhep)
             };
            return ExecuteNonQuery(query, p) > 0;
        }
        // 4 Xử lý yêu cầu — cập nhật trạng thái
        public bool CapNhatTrangThaiTin(int maTinOGhep, TrangThaiTinOGhep trangThai)
        {
            string query = @"UPDATE TINOGHEP 
                             SET TRANGTHAITIN = @TRANGTHAITIN 
                             WHERE MATINOG = @MATINOG";
            SqlParameter[] p = {
                new SqlParameter("@TRANGTHAITIN", GetStringTrangThaiTin(trangThai)),
                new SqlParameter("@MATINOG",      maTinOGhep)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // 5. Lấy danh sách tin theo phòng 
        //public DataTable LayDanhSachTinTheoPhong(int maPhong)
        //{
        //    string query = @"SELECT * FROM TINOGHEP 
        //                     WHERE MAPHONG = @MAPHONG";
        //    SqlParameter[] p = { new SqlParameter("@MAPHONG", maPhong) };
        //    return ExecuteQuery(query, p);
        //}

        // 5. Lấy danh sách tin theo phòng (Đã chỉnh sửa để lấy chuỗi chữ hiển thị trực quan)
        public DataTable LayDanhSachTinTheoPhong(int maPhong)
        {
            // Sử dụng câu lệnh tối ưu để kết nối thông tin giữa các bảng
            string query = @"
        SELECT 
            T.MATINOG AS [Mã tin], 
            (P.TENPHONG) AS [Phòng], 
            (K.HOKH + ' ' + K.TENKH) AS [Khách đăng], 
            T.SONGUOICAN AS [Số người], 
            T.GIOITINH AS [Giới tính], 
            T.GIACHIA AS [Giá chia], 
            T.TRANGTHAITIN AS [Trạng thái],
            T.MOTA AS [MoTa],
            T.MAPHONG AS [MaPhongRaw],
            T.MAKH AS [MaKHRaw]
        FROM TINOGHEP T
        INNER JOIN PHONG P ON T.MAPHONG = P.MAPHONG
        INNER JOIN KHACHTHUE K ON T.MAKH = K.MAKH
        WHERE @MAPHONG = 0 OR T.MAPHONG = @MAPHONG";

            SqlParameter[] p = { new SqlParameter("@MAPHONG", maPhong) };
            return ExecuteQuery(query, p);
        }

        // 6 Đánh giá và phản hồi
        public bool DanhGiaOGhep(int maTin, string danhGia)
        {
            string query = "UPDATE TINOGHEP SET DANHGIA = @DANHGIA WHERE MATINOG = @MATINOG";
            SqlParameter[] p = {
                new SqlParameter("@DANHGIA", danhGia),
                new SqlParameter("@MATINOG", maTin)
            };
            return ExecuteNonQuery(query, p) > 0;
        }
    }
}