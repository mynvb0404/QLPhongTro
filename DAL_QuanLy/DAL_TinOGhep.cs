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

        private string GetStringGioiTinh(GioiTinh gt)
        {
            return gt == GioiTinh.Nam ? "Nam" : "Nữ";
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
                new SqlParameter("@GIOITINH", GetStringGioiTinh(og.GIOITINH)),

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
                new SqlParameter("@GIOITINH", GetStringGioiTinh(og.GIOITINH)),
                new SqlParameter("@GIACHIA",    og.GIACHIA),
                new SqlParameter("@MOTA",       og.MOTA),
                new SqlParameter("@MATINOG",    og.MATINOG)
            };
            return ExecuteNonQuery(query, p) > 0;
        }
        // 2 Tìm kiếm tin ở ghép
        public DataTable TimKiemTinOGhep(int maPhong, string gioiTinh, decimal giaChiaMax, int soNguoi, string tuKhoa)
        {
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
                      AND (@MAPHONG = 0 OR T.MAPHONG = @MAPHONG)
                      AND (@GIOITINH = '' OR T.GIOITINH = @GIOITINH)
                      AND (@GIACHAMAX = 0 OR T.GIACHIA <= @GIACHAMAX)
                      AND (@SONGUOI = 0 OR T.SONGUOICAN = @SONGUOI)
                      AND (@TUKHOA = '' OR T.MOTA LIKE @TUKHOA)";

            SqlParameter[] p = {
        new SqlParameter("@MAPHONG",   maPhong),
        new SqlParameter("@GIOITINH",  gioiTinh ?? ""),
        new SqlParameter("@GIACHAMAX", giaChiaMax),
        new SqlParameter("@SONGUOI",   soNguoi),
        new SqlParameter("@TUKHOA",    string.IsNullOrEmpty(tuKhoa) ? "" : "%" + tuKhoa + "%")
    };

            return ExecuteQuery(query, p);
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

        // 5 Lấy danh sách tin theo phòng


        public DataTable LayDanhSachTinTheoPhong(int maPhong)
        {
            string query = @"
        SELECT 
            T.MATINOG,
            P.TENPHONG,
            (K.HOKH + ' ' + K.TENKH) AS HOTENKHACH,
            T.SONGUOICAN,
            T.GIOITINH,
            T.GIACHIA,
            T.TRANGTHAITIN,
            T.MOTA,
            T.MAPHONG  AS MaPhongRaw,
            T.MAKH     AS MaKHRaw
        FROM TINOGHEP T
        INNER JOIN PHONG P ON T.MAPHONG = P.MAPHONG
        INNER JOIN KHACHTHUE K ON T.MAKH = K.MAKH
        WHERE @MAPHONG = 0 OR T.MAPHONG = @MAPHONG";

            SqlParameter[] p = { new SqlParameter("@MAPHONG", maPhong) };
            return ExecuteQuery(query, p);
        }

    }
}