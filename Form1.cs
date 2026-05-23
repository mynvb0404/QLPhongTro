using System;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using System.Data;

namespace Hợp_Đồng
{
    public partial class frmHopDong : Form
    {
        BUS_HopDong busHD = new BUS_HopDong();

        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            LoadHopDong();
            ResetForm();
        }

        private void LoadHopDong()
        {
            dgvHopDong.DataSource = busHD.LayDanhSachHopDong();
        }

        private void ResetForm()
        {
            txtMaHD.Clear();
            txtMaKH.Clear();
            txtMaPhong.Clear(); // Đảm bảo tên control là txtPhong
            rtxtThongTin.Clear();
            txtMaHD.ReadOnly = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MAHOPDONG"].Value.ToString();
                txtMaPhong.Text = row.Cells["MAPHONG"].Value.ToString();
                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
                dtNgayKy.Value = Convert.ToDateTime(row.Cells["NGAYKYHD"].Value);
                dtNgayKT.Value = Convert.ToDateTime(row.Cells["NGAYKT"].Value);
                cboTrangThai.Text = row.Cells["TRANGTHAIHOPDONG"].Value.ToString();
                rtxtThongTin.Text = row.Cells["THONGTINHD"].Value.ToString();

                txtMaHD.ReadOnly = true; // Khóa mã để không sửa được PK
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_HopDong hd = new DTO_HopDong();
                hd.MAHOPDONG = txtMaHD.Text.Trim();
                hd.MAPHONG = int.Parse(txtMaPhong.Text.Trim());
                hd.MAKH = int.Parse(txtMaKH.Text.Trim());
                hd.NGAYKYHD = dtNgayKy.Value;
                hd.NGAYKT = dtNgayKT.Value;
                hd.TRANGTHAIHOPDONG = cboTrangThai.Text;
                hd.THONGTINHD = rtxtThongTin.Text;

                string ketQua = busHD.ThemHopDong(hd);
                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadHopDong();
                    ResetForm();
                }
                else MessageBox.Show(ketQua);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi định dạng: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_HopDong hd = new DTO_HopDong(txtMaHD.Text, int.Parse(txtMaPhong.Text), int.Parse(txtMaKH.Text), dtNgayKy.Value, dtNgayKT.Value, cboTrangThai.Text, rtxtThongTin.Text);
                string ketQua = busHD.SuaHopDong(hd);
                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadHopDong();
                    ResetForm();
                }
                else MessageBox.Show(ketQua);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busHD.XoaHopDong(txtMaHD.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadHopDong();
                    ResetForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvHopDong.DataSource = busHD.TimKiemHopDong(txtTimKiem.Text);
        }
    }
}