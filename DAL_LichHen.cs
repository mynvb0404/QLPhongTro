using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using Microsoft.Data.SqlClient;

using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;

namespace DAL_QuanLy
{
    public class DAL_LichHen : DBConnect
    {
        //lấy ds lịch hẹn
        public DataTable LayDanhSachLichHen()
        {
            string query = "SELECT * FROM LICHHEN";
            return ExecuteQuery(query);
        }

        //Thêm lịch hẹn
        public bool ThemLichHen(DTO_LichHen lh)
        {
            string query = "INSERT INTO LICHHEN (MAKH ,MANV ,MAPHONG ,THOIGIANHEN ,TRANGTHAIHEN ,NOIDUNGHEN ,THOIGIANTAO ,THOIGIANCAPNHAT) VALUES(@MAKH, @MANV, @MAPHONG, @THOIGIANHEN, @TRANGTHAIHEN, @NOIDUNGHEN ,@THOIGIANTAO ,@THOIGIANCAPNHAT)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", lh.MAKH),
                new SqlParameter("@MANV", lh.MANV),
                new SqlParameter("@MAPHONG", lh.MAPHONG),
                new SqlParameter("@THOIGIANHEN", lh.THOIGIANHEN),
                new SqlParameter("@TRANGTHAIHEN", lh.TRANGTHAIHEN),
                new SqlParameter("@NOIDUNGHEN", lh.NOIDUNGHEN),
                new SqlParameter("@THOIGIANTAO", lh.THOIGIANTAO),
                new SqlParameter("@THOIGIANCAPNHAT", lh.THOIGIANCAPNHAT)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }
        
        //sửa lịch hẹn
        public bool SuaLichHen(DTO_LichHen lh)
        {
            string query = @"UPDATE LICHHEN
                             SET   MAKH = @MAKH
                                  ,MANV = @MANV
                                  ,MAPHONG = @MAPHONG
                                  ,THOIGIANHEN = @THOIGIANHEN
                                  ,TRANGTHAIHEN = @TRANGTHAIHEN
                                  ,NOIDUNGHEN = @NOIDUNGHEN
                                  ,THOIGIANTAO = @THOIGIANTAO
                                  ,THOIGIANCAPNHAT = @THOIGIANCAPNHAT
                             WHERE MALH = @MALH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAKH", lh.MAKH),
                new SqlParameter("@MANV", lh.MANV),
                new SqlParameter("@MAPHONG", lh.MAPHONG),
                new SqlParameter("@THOIGIANHEN", lh.THOIGIANHEN),
                new SqlParameter("@TRANGTHAIHEN", lh.TRANGTHAIHEN),
                new SqlParameter("@NOIDUNGHEN", lh.NOIDUNGHEN),
                new SqlParameter("@THOIGIANTAO", lh.THOIGIANTAO),
                new SqlParameter("@THOIGIANCAPNHAT", lh.THOIGIANCAPNHAT)           };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //xóa
        public bool XoaLichHen(int id)
        {
            string query = "DELETE FROM LICHHEN WHERE MALH = @MALH";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MALH", id)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        //tìm kiếm
        public DataTable TimKiemLichHen(string keyword)
        {
            string query = @"SELECT lh.*, kh.TENKH, nv.TENNV 
                             FROM LICHHEN lh, KHACHTHUE kh, NHANVIEN nv
                             WHERE lh.MAKH = kh.MAKH 
                               AND lh.MANV = nv.MANV
                               AND (kh.TENKH LIKE @KEYWORD 
                                    OR nv.TENNV LIKE @KEYWORD 
                                    OR lh.TRANGTHAIHEN LIKE @KEYWORD 
                                    OR lh.NOIDUNGHEN LIKE @KEYWORD)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@KEYWORD", "%" + keyword + "%")
            };

            return ExecuteQuery(query, parameters);
        }

        //Cập nhật trạng thái
        public bool CapNhatTrangThaiLichHen(int id, string trangThai)
        {
            string query = @"UPDATE LICHHEN 
                             SET TRANGTHAIHEN = @TRANGTHAI, 
                                 THOIGIANCAPNHAT = GETDATE() 
                             WHERE MALH = @MALH";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MALH", id),
        new SqlParameter("@TRANGTHAI", trangThai)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
