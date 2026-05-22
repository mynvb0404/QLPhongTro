using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_DanhGia : DBConnect
    {
        // 1 LẤY TẤT CẢ ĐÁNH GIÁ (Để đổ lên GridView xem)
        public DataTable GetAll()
        {
            string sql = "SELECT * FROM DANHGIA ORDER BY THOIGIAN DESC";
            return ExecuteQuery(sql);
        }

        // 2 THÊM ĐÁNH GIÁ 
        public bool Them(DTO_DanhGia dto)
        {
            string sql = @"INSERT INTO DANHGIA (MANGUOIDG, MANGUOIDUOCDG, MAHOPDONG, DIEM, NOIDUNG, THOIGIAN)
                           VALUES (@mndg, @mnddg, @mhd, @diem, @nd, GETDATE())"; 

            SqlParameter[] pr = {
                new SqlParameter("@mndg",  dto.MANGUOIDG),
                new SqlParameter("@mnddg", dto.MANGUOIDUOCDG),
                new SqlParameter("@mhd",   dto.MAHOPDONG),
                new SqlParameter("@diem",  dto.DIEM),
                new SqlParameter("@nd",    dto.NOIDUNG)
            };
            return ExecuteNonQuery(sql, pr) > 0;
        }

        // 3 XÓA ĐÁNH GIÁ
        //public bool Xoa(int maDG)
        //{
        //    string sql = "DELETE FROM DANHGIA WHERE MADG = @ma";
        //    return ExecuteNonQuery(sql, new SqlParameter("@ma", maDG)) > 0;
        //}

        public bool Xoa(int maDG)
        {
            string sql = "DELETE FROM DANHGIA WHERE MADG = @madg";
            return ExecuteNonQuery(sql, new SqlParameter[] { new SqlParameter("@madg", maDG) }) > 0;
        }
        // 4. Lấy tất cả đánh giá về một người cụ thể (để hiển thị uy tín khi tìm người ở ghép - Chức năng 6.2 & 6.6)
        public DataTable GetDanhGiaCuaNguoiDung(int maNguoiDuocDG)
        {
            string sql = "SELECT * FROM DANHGIA WHERE MANGUOIDUOCDG = @manddg"; 
            return ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@manddg", maNguoiDuocDG) });
        }

        // Kiểm tra xem một hợp đồng ở ghép đã được đánh giá chưa (Chức năng 6.6)
        public bool KiemTraDaDanhGia(int maHopDong)
        {
            string sql = "SELECT COUNT(*) FROM DANHGIA WHERE MAHOPDONG = @maHD"; 
            DataTable dt = ExecuteQuery(sql, new SqlParameter[] { new SqlParameter("@maHD", maHopDong) });

            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            return false;
        }
    }
}