using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmArea : Form
    {
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();
        public frmArea()
        {
            InitializeComponent();
        }

        private void HienThiDanhSachKhuVuc()
        {
            DataTable dt = busKhuVuc.LayDanhSachKhuVuc();
            dgvArea.DataSource = dt;

            if (dgvArea.Columns["MAKV"] != null) dgvArea.Columns["MAKV"].HeaderText = "Mã Khu Vực";
            if (dgvArea.Columns["TENKV"] != null) dgvArea.Columns["TENKV"].HeaderText = "Tên Khu Vực";
            if (dgvArea.Columns["DCHI"] != null) dgvArea.Columns["DCHI"].HeaderText = "Địa Chỉ";
            if (dgvArea.Columns["MANV"] != null) dgvArea.Columns["MANV"].HeaderText = "Mã Quản Lý";
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhuVuc();
        }

        private void dgvArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvArea.Rows[e.RowIndex];

                txtMa.Text = row.Cells["MAKV"].Value?.ToString();
                txtName.Text = row.Cells["TENKV"].Value?.ToString();
                txtAddress.Text = row.Cells["DCHI"].Value?.ToString();
                txtEmp.Text = row.Cells["MANV"].Value?.ToString();

                txtMa.ReadOnly = true;
            }
        }

        private void ResetForm()
        {
            txtMa.ReadOnly = false;
            txtMa.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtEmp.Clear();
            txtMa.Focus();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int.TryParse(txtEmp.Text.Trim(), out int maNV);

            DTO_KHUVUC kv = new DTO_KHUVUC()
            {
                MAKV = txtMa.Text.Trim(),
                TENKV = txtName.Text.Trim(),
                DCHI = txtAddress.Text.Trim(),
                MANV = maNV
            };

            string ketQua = busKhuVuc.ThemKhuVuc(kv);

            if (ketQua == "THÀNH CÔNG")
            {
                MessageBox.Show("Thêm khu vực mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HienThiDanhSachKhuVuc();
                ResetForm();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn khu vực cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int.TryParse(txtEmp.Text.Trim(), out int maNV);

            DTO_KHUVUC kv = new DTO_KHUVUC()
            {
                MAKV = txtMa.Text.Trim(),
                TENKV = txtName.Text.Trim(),
                DCHI = txtAddress.Text.Trim(),
                MANV = maNV
            };

            string ketQua = busKhuVuc.SuaKhuVuc(kv);

            if (ketQua == "THÀNH CÔNG")
            {
                MessageBox.Show("Cập nhật thông tin khu vực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachKhuVuc();
                ResetForm();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string maKV = txtMa.Text.Trim();

            if (string.IsNullOrEmpty(maKV))
            {
                MessageBox.Show("Vui lòng chọn khu vực muốn xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khu vực {maKV} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string ketQua = busKhuVuc.XoaKhuVuc(maKV);

                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Xóa khu vực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachKhuVuc();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtName.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = txtAddress.Text.Trim();
            }

            DataTable dtKetQua = busKhuVuc.TimKiemKhuVuc(tuKhoa);
            dgvArea.DataSource = dtKetQua;

            if (dtKetQua == null || dtKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khu vực nào khớp với từ khóa!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }
}

