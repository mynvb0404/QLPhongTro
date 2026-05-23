using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_LichHen
    {
        DAL_LichHen dal = new DAL_LichHen();

        //lấy ds
        public DataTable LayDanhSachLichHen()
        {
            return dal.LayDanhSachLichHen();
        }

        //thêm
        public bool ThemLichHen(DTO_LichHen lh)
        {
            return dal.ThemLichHen(lh);
        }

        //sửa
        public bool SuaLichHen(DTO_LichHen lh)
        {
            return dal.SuaLichHen(lh);
        }

        //xóa
        public bool XoaLichHen(int id)
        {
            return dal.XoaLichHen(id);
        }

        //tìm kiếm
        public DataTable TimKiemLichHen(string keyword)
        {
            return dal.TimKiemLichHen(keyword);
        }

        //cập nhật trạng thái
        public bool CapNhatTrangThai(int id, string trangThai)
        {
            return dal.CapNhatTrangThaiLichHen(id, trangThai);
        }
    }
}
