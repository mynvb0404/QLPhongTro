using System;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
namespace Khách_Hàng
{
    public partial class frmKhachHang : Form
    {
        BUS_KhachThue busKH = new BUS_KhachThue();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = busKH.LayDanhSachKhachHang();
        }

        private void LoadKhachHang()
        {
            dgvKhachHang.DataSource = busKH.LayDanhSachKhachHang();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
                txtHoKH.Text = row.Cells["HOKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TENKH"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                dtNgayThue.Value = Convert.ToDateTime(row.Cells["NGAYBATDAUTHUE"].Value);
                cboTrangThai.Text = row.Cells["TRANGTHAITHUE"].Value.ToString();

                txtMaKH.ReadOnly = true; 
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_KHACHTHUE kh = new DTO_KHACHTHUE();
            kh.MAKH = int.Parse(txtMaKH.Text);
            kh.HOKH = txtHoKH.Text;
            kh.TENKH = txtTenKH.Text;
            kh.SDT = txtSDT.Text;

            string ketQua = busKH.SuaKhachThue(kh);
            if (ketQua == "THÀNH CÔNG")
            {
                MessageBox.Show("Sửa thành công!");
                LoadKhachHang();
            }
            else MessageBox.Show(ketQua);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ketQua = busKH.XoaKhachHang(int.Parse(txtMaKH.Text));
                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Đã xóa!");
                    LoadKhachHang();
                }
                else MessageBox.Show(ketQua);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = busKH.TimKiemKhachHang(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ho = txtHoKH.Text.Trim();
            string ten = txtTenKH.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string trangThai = cboTrangThai.Text;

            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Họ khách hàng và Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_KHACHTHUE kh = new DTO_KHACHTHUE();
            kh.HOKH = ho;
            kh.TENKH = ten;
            kh.CCCD = cccd;
            kh.SDT = sdt;
            kh.NGAYBATDAUTHUE = dtNgayThue.Value;
            kh.TRANGTHAITHUE = TrangThaiKhachThue.DangThue;

            try
            {
                string ketQua = busKH.ThemKhachThue(kh, "user_" + sdt, "123456");

                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();


                    txtMaKH.Clear();
                    txtHoKH.Clear();
                    txtTenKH.Clear();
                    txtCCCD.Clear();
                    txtSDT.Clear();
                    txtMaKH.ReadOnly = false; 
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ketQua, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKhachHang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
