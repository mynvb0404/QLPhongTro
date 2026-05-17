using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_PHONG : DBConnect
    {
        private string GetStringTrangThai(TrangThaiPhong ttp)
        {
            switch (ttp)
            {
                case TrangThaiPhong.ConTrong: return "Còn trống";
                case TrangThaiPhong.DaThue: return "Đã thuê";
                case TrangThaiPhong.CanOGhep: return "Cần ở ghép";
                default: return "Còn trống";
            }
        }
        //Lấy toàn bộ danh sách phòng
        public DataTable LayDanhSachPhong()
        {
            string query = "SELECT * FROM PHONG";
            return ExecuteQuery(query, null);
        }
         // 1 Thêm phòng
        public bool ThemPhong(DTO_PHONG p)
        {
            string query = "INSERT INTO PHONG (TENPHONG, MAKV, GIAPHONG, DIENTICH, LOAIPHONG, TRANGTHAIPHONG, SONGUOIHIENTAI, NOITHAT) VALUES (@MAPHONG, @MAKV, @GIAPHONG, @DIENTICH, @LOAIPHONG, @TRANGTHAIPHONG, @SONGUOIHIENTAI, @NOITHAT);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TENPHONG", p.TENPHONG ?? (object)DBNull.Value),
                new SqlParameter("@MAKV", p.MAKV ?? (object)DBNull.Value),
                new SqlParameter("@GIAPHONG", p.GIAPHONG == 0 ? (object)DBNull.Value : p.GIAPHONG),
                new SqlParameter("@DIENTICH", p.DIENTICH == null ? (object)DBNull.Value : p.DIENTICH),
                new SqlParameter("@LOAIPHONG", p.LOAIPHONG ?? (object)DBNull.Value),
                new SqlParameter("@TRANGTHAIPHONG", GetStringTrangThai(p.TRANGTHAIPHONG)),
                new SqlParameter("@SONGUOIHIENTAI", p.SONGUOIHIENTAI),
                new SqlParameter("@NOITHAT", p.NOITHAT ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 2 Sửa phòng 
        public bool SuaPhong(DTO_PHONG p)
        {
            string query = "UPDATE PHONG SET TENPHONG = @TENPHONG, MAKV = @MAKV, GIAPHONG = @GIAPHONG, DIENTICH = @DIENTICH, LOAIPHONG = @LOAIPHONG, TRANGTHAIPHONG = @TRANGTHAIPHONG, SONGUOIHIENTAI = @SONGUOIHIENTAI, NOITHAT = @NOITHAT WHERE MAPHONG = @MAPHONG;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", p.MAPHONG),
                new SqlParameter("@TENPHONG", p.TENPHONG ?? (object)DBNull.Value),
                new SqlParameter("@MAKV", p.MAKV ?? (object)DBNull.Value),
                new SqlParameter("@GIAPHONG", p.GIAPHONG),
                new SqlParameter("@DIENTICH", p.DIENTICH == null ? (object)DBNull.Value : p.DIENTICH),
                new SqlParameter("@LOAIPHONG", p.LOAIPHONG ?? (object)DBNull.Value),
               new SqlParameter("@TRANGTHAIPHONG", GetStringTrangThai(p.TRANGTHAIPHONG)),
                new SqlParameter("@SONGUOIHIENTAI", p.SONGUOIHIENTAI),
                new SqlParameter("@NOITHAT", p.NOITHAT ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 3 Xóa phòng  
        public bool XoaPhong(int id)
        {
            string query = "DELETE FROM PHONG WHERE MAPHONG = @MAPHONG";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", id)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        // 4 Tìm kiếm phòng 
        public DataTable TimKiemPhong(string? maKV = null, decimal? minGia = null, decimal? maxGia = null, DTO_TINOGHEP tinOGhep = null)
        {
            var queryBuilder = new StringBuilder("SELECT * FROM PHONG WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maKV))
            {
                queryBuilder.Append(" AND MAKV = @MAKV");
                parameters.Add(new SqlParameter("@MAKV", maKV));
            }

            if (minGia.HasValue)
            {
                queryBuilder.Append(" AND GIAPHONG >= @MINGIA");
                parameters.Add(new SqlParameter("@MINGIA", minGia.Value));
            }

            if (maxGia.HasValue)
            {
                queryBuilder.Append(" AND GIAPHONG <= @MAXGIA");
                parameters.Add(new SqlParameter("@MAXGIA", maxGia.Value));
            }

            bool? oghepFilter = null;

            if (tinOGhep != null)
            {
                if (tinOGhep.TRANGTHAITIN == "Đang tìm")
                {
                    oghepFilter = true;
                }
            }

            if (oghepFilter.HasValue)
            {
                if (oghepFilter.Value)
                {
                    queryBuilder.Append(" AND TRANGTHAIPHONG = @TRANGTHAIPHONG");
                    parameters.Add(new SqlParameter("@TRANGTHAIPHONG", "Cần ở ghép"));
                }
                else
                {
                    queryBuilder.Append(" AND TRANGTHAIPHONG != @TRANGTHAIPHONG");
                    parameters.Add(new SqlParameter("@TRANGTHAIPHONG", "Cần ở ghép"));
                }
            }

            var parametersArray = parameters.Count > 0 ? parameters.ToArray() : null;

            return ExecuteQuery(queryBuilder.ToString(), parametersArray);
        }

        // 5 Xem thông tin phòng 
        public DataTable LayThongTinPhong(int maPhong)
        {
            string query = "SELECT * FROM PHONG WHERE MAPHONG = @MAPHONG";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", maPhong)
            };

            return ExecuteQuery(query, parameters);
        }

        // 6 Cập nhật trạng thái phòng 
        public bool CapNhatTrangThaiPhong(int maPhong, string trangThai)
        {
            string query = "UPDATE PHONG SET TRANGTHAIPHONG = @TRANGTHAIPHONG WHERE MAPHONG = @MAPHONG";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAPHONG", maPhong),
                new SqlParameter("@TRANGTHAIPHONG", GetStringTrangThai(trangThai))
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}