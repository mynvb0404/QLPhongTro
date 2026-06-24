using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_TinOGhep : DBConnect
    {
        public bool DangTinOGhep(DTO_TinOGhep TIN)
        {
            string QUERY = "INSERT INTO TINOGHEP(MAPHONG, MAKH, SONGUOICAN, GIOITINH, GIACHIA, MOTA, TRANGTHAITIN) VALUES (@MAPHONG, @MAKH, @SONGUOICAN, @GIOITINH, @GIACHIA, @MOTA, @TRANGTHAITIN)";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", TIN.MAPHONG),
                new SqlParameter("@MAKH", TIN.MAKH),
                new SqlParameter("@SONGUOICAN", TIN.SONGUOICAN),
                new SqlParameter("@GIOITINH", TIN.GIOITINH),
                new SqlParameter("@GIACHIA", TIN.GIACHIA),
                new SqlParameter("@MOTA", TIN.MOTA),
                new SqlParameter("@TRANGTHAITIN", TIN.TRANGTHAITIN)
            };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        public bool SuaTinOGhep(DTO_TinOGhep TIN)
        {
            string QUERY = "UPDATE TINOGHEP SET SONGUOICAN=@SONGUOICAN, GIOITINH=@GIOITINH, GIACHIA=@GIACHIA, MOTA=@MOTA, TRANGTHAITIN=@TRANGTHAITIN WHERE MATINOG=@MATINOG";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MATINOG", TIN.MATINOG),
                new SqlParameter("@SONGUOICAN", TIN.SONGUOICAN),
                new SqlParameter("@GIOITINH", TIN.GIOITINH),
                new SqlParameter("@GIACHIA", TIN.GIACHIA),
                new SqlParameter("@MOTA", TIN.MOTA),
                new SqlParameter("@TRANGTHAITIN", TIN.TRANGTHAITIN)
            };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        public DataTable TimKiemTinOGhep(string TIEUCHI)
        {
            string QUERY = "SELECT * FROM TINOGHEP WHERE GIOITINH LIKE @TC OR MOTA LIKE @TC OR TRANGTHAITIN LIKE @TC";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@TC", "%" + TIEUCHI + "%")
            };
            return ExecuteQuery(QUERY, PARAMETERS);
        }

        public bool GUI_QuanLyYeuCauOGhep(int MATINOG, int MAKH_GUI_QuanLy)
        {
            string QUERY = "INSERT INTO YEUCAUOGHEP(MATINOG, MAKH_GUI_QuanLy, TRANGTHAI) VALUES (@MATINOG, @MAKH_GUI_QuanLy, N'Chờ duyệt')";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MATINOG", MATINOG),
                new SqlParameter("@MAKH_GUI_QuanLy", MAKH_GUI_QuanLy)
            };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        public bool XuLyYeuCauOGhep(int MAYC, string TRANGTHAI)
        {
            string QUERY = "UPDATE YEUCAUOGHEP SET TRANGTHAI=@TRANGTHAI WHERE MAYC=@MAYC";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@TRANGTHAI", TRANGTHAI),
                new SqlParameter("@MAYC", MAYC)
            };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        public DataTable LayDanhSachNguoiOGhep(int MAPHONG)
        {
            string QUERY = "SELECT K.MAKH, K.HOTEN, K.SDT FROM KHACHTHUE K WHERE K.MAPHONG = @MAPHONG";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", MAPHONG)
            };
            return ExecuteQuery(QUERY, PARAMETERS);
        }

        public bool LuuDanhGiaPhanHoi(int MAKH_DG, int MAKH_NHAN, string NOIDUNG)
        {
            string QUERY = "INSERT INTO DANHGIAPHANHOI(MAKH_DG, MAKH_NHAN, NOIDUNG, NGAYDG) VALUES (@MAKH_DG, @MAKH_NHAN, @NOIDUNG, GETDATE())";
            SqlParameter[] PARAMETERS = new SqlParameter[]
            {
                new SqlParameter("@MAKH_DG", MAKH_DG),
                new SqlParameter("@MAKH_NHAN", MAKH_NHAN),
                new SqlParameter("@NOIDUNG", NOIDUNG)
            };
            return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        }

        //public bool GUI_QuanLyTinNhanHoiThoai(DTO_HoiThoai HT)
        //{
        //    string QUERY = "INSERT INTO HOITHOAI(MAKH, MANV, THOIGIANTAOHT) VALUES (@MAKH, @MANV, @THOIGIANTAOHT)";
        //    SqlParameter[] PARAMETERS = new SqlParameter[]
        //    {
        //        new SqlParameter("@MAKH", HT.MAKH),
        //        new SqlParameter("@MANV", HT.MANV),
        //        new SqlParameter("@THOIGIANTAOHT", HT.THOIGIANTAOHT == default ? DateTime.Now : HT.THOIGIANTAOHT)
        //    };
        //    return ExecuteNonQuery(QUERY, PARAMETERS) > 0;
        //}
    }
}