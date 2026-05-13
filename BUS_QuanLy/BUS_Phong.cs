using System;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_Phong
    {
        private DAL_PHONG dalPhong = new DAL_PHONG();

        // 1. Lấy danh sách toàn bộ phòng
        public DataTable LayDanhSachPhong()
        {
            return dalPhong.LayDanhSachPhong();
        }

        // 2. Lấy thông tin chi tiết của một phòng theo ID
        public DataTable LayThongTinPhong(int maPhong)
        {
            if (maPhong <= 0)
            {
                return null;
            }
            return dalPhong.LayThongTinPhong(maPhong);
        }

        // 3. Thêm phòng mới
        public string ThemPhong(DTO_PHONG phong)
        {
            if (string.IsNullOrWhiteSpace(phong.TENPHONG))
            {
                return "Tên phòng không được để trống!";
            }

            if (phong.GIAPHONG <= 0)
            {
                return "Giá phòng phải lớn hơn 0 VND!";
            }

            if (phong.DIENTICH != null && phong.DIENTICH <= 0)
            {
                return "Diện tích phòng phải lớn hơn 0 m²!";
            }

            if (string.IsNullOrWhiteSpace(phong.LOAIPHONG))
            {
                return "Loại phòng không được để trống!";
            }

            if (phong.SONGUOIHIENTAI < 0)
            {
                return "Số người hiện tại không được là số âm!";
            }

            if (string.IsNullOrWhiteSpace(phong.TRANGTHAIPHONG))
            {
                phong.TRANGTHAIPHONG = "Còn trống";
            }
            else if (phong.TRANGTHAIPHONG != "Còn trống" &&
                     phong.TRANGTHAIPHONG != "Đã thuê" &&
                     phong.TRANGTHAIPHONG != "Cần ở ghép")
            {
                return "Trạng thái phòng không hợp lệ! (Chỉ chấp nhận: Còn trống, Đã thuê, Cần ở ghép).";
            }

            bool kq = dalPhong.ThemPhong(phong);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Lỗi hệ thống khi tạo phòng mới!";
        }

        // 4. Sửa thông tin phòng
        public string SuaPhong(DTO_PHONG phong)
        {
            if (phong.MAPHONG <= 0)
            {
                return "Mã phòng không hợp lệ!";
            }

            if (string.IsNullOrWhiteSpace(phong.TENPHONG))
            {
                return "Tên phòng không được để trống!";
            }

            if (phong.GIAPHONG <= 0)
            {
                return "Giá phòng phải lớn hơn 0 VND!";
            }

            if (phong.DIENTICH != null && phong.DIENTICH <= 0)
            {
                return "Diện tích phòng phải lớn hơn 0 m²!";
            }

            if (phong.TRANGTHAIPHONG != "Còn trống" &&
                phong.TRANGTHAIPHONG != "Đã thuê" &&
                phong.TRANGTHAIPHONG != "Cần ở ghép")
            {
                return "Trạng thái phòng không hợp lệ!";
            }

            bool kq = dalPhong.SuaPhong(phong);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Không thể cập nhật thông tin phòng!";
        }

        // 5. Cập nhật nhanh trạng thái phòng (Khi ký HĐ/Trả phòng)
        public string CapNhatTrangThaiPhong(int maPhong, string trangThai)
        {
            if (maPhong <= 0)
            {
                return "Mã phòng không hợp lệ!";
            }

            if (trangThai != "Còn trống" && trangThai != "Đã thuê" && trangThai != "Cần ở ghép")
            {
                return "Trạng thái yêu cầu không hợp lệ!";
            }

            bool kq = dalPhong.CapNhatTrangThaiPhong(maPhong, trangThai);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Không thể cập nhật trạng thái phòng!";
        }

        // 6. Xóa phòng (Có check nghiệp vụ phòng đang thuê)
        public string XoaPhong(int maPhong)
        {
            if (maPhong <= 0)
            {
                return "Mã phòng không hợp lệ!";
            }

            DataTable dt = dalPhong.LayThongTinPhong(maPhong);
            if (dt != null && dt.Rows.Count > 0)
            {
                string trangThaiHienTai = dt.Rows[0]["TRANGTHAIPHONG"].ToString();
                if (trangThaiHienTai == "Đã thuê")
                {
                    return "Thất bại: Phòng đang có khách ở, không được phép xóa!";
                }
            }

            bool kq = dalPhong.XoaPhong(maPhong);
            if (kq)
            {
                return "THÀNH CÔNG";
            }
            return "Thất bại: Phòng đang có liên kết dữ liệu với hóa đơn/hợp đồng cũ!";
        }

        // 7. Tìm kiếm và lọc phòng nâng cao
        public DataTable TimKiemPhong(string maKV, decimal? minGia, decimal? maxGia, DTO_TINOGHEP tinOGhep)
        {
            string thamSoMaKV = string.IsNullOrWhiteSpace(maKV) ? null : maKV.Trim();

            return dalPhong.TimKiemPhong(thamSoMaKV, minGia, maxGia, tinOGhep);
        }
    }
}