using DAL_QuanLy;
using DTO_QuanLy;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace BUS_QuanLy
{

    public class BUS_DanhGia
    {
        private readonly DAL_DanhGia dal = new DAL_DanhGia();

        // 1 LẤY DANH SÁCH ĐÁNH GIÁ
        public DataTable GetAll() => dal.GetAll();


        // 2 THÊM ĐÁNH GIÁ MỚI
        public string ThemDanhGia(DTO_DanhGia dto)
        {

            if (dto.MANGUOIDG <= 0 || dto.MANGUOIDUOCDG <= 0)
                return "Thông tin người dùng không hợp lệ.";

            if (dto.MAHOPDONG <= 0)
                return "Mã hợp đồng không được để trống.";
            if (dto.MANGUOIDG == dto.MANGUOIDUOCDG)
                return "Bạn không thể tự đánh giá chính mình!";

            if (dto.DIEM < 1 || dto.DIEM > 5)
                return "Số điểm đánh giá phải từ 1 đến 5 sao.";

            if (string.IsNullOrWhiteSpace(dto.NOIDUNG))
                return "Vui lòng nhập nội dung nhận xét.";

            // Gán thời gian hiện tại nếu chưa có
            if (dto.THOIGIAN == default)
                dto.THOIGIAN = DateTime.Now;

            return dal.Them(dto) ? "Thành công" : "Lỗi hệ thống khi lưu đánh giá.";
        }

        // 3 XÓA ĐÁNH GIÁ
        public bool XoaDanhGia(int maDG)
        {
            if (maDG <= 0) return "Mã đánh giá không hợp lệ!";
            return dal.Xoa(maDG) ? "" : "Xóa đánh giá thất bại!";
        }

        // 4 LẤY ĐÁNH GIÁ VỀ MỘT NGƯỜI (Phục vụ xem uy tín khi ở ghép)
        public DataTable GetDanhGiaVeNguoi(int maNguoiDuocDG)
        {
            if (maNguoiDuocDG <= 0) return new DataTable();

            string sql = "SELECT * FROM DANHGIA WHERE MaNguoiDuocDG = @ma";
            SqlParameter pr = new SqlParameter("@ma", maNguoiDuocDG);
            return dal.ExecuteQuery(sql, pr);
        }
    }
}