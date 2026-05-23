using System;
using System.Data;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_QuanLy
{
    public partial class frmManageAcc : Form
    {
        private BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private BUS_KhachThue busKhachHang = new BUS_KhachThue();
        private BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        private int idSelected = 0;

        public frmManageAcc()
        {
            InitializeComponent();

        }

        private void LoadData()
        {
            if (cboRole.SelectedIndex == 0) // Nhân viên
            {
                dgvEmployee.DataSource = busNhanVien.LayDanhSachNhanVien();

                if (dgvEmployee.Columns.Contains("MATKHAU"))
                    dgvEmployee.Columns["MATKHAU"].Visible = false;
            }
            else // Khách thuê
            {
                dgvEmployee.DataSource = busKhachHang.LayDanhSachKhachHang();

                string[] columnsToHide = { "NGAYSINH", "GIOITINH", "CCCD", "NGAYBATDAUTHUE", "TRANGTHAITHUE", "MATKHAU" };
                foreach (string colName in columnsToHide)
                {
                    if (dgvEmployee.Columns.Contains(colName))
                    {
                        dgvEmployee.Columns[colName].Visible = false;
                    }
                }

                if (dgvEmployee.Columns.Contains("MAKH")) dgvEmployee.Columns["MAKH"].HeaderText = "Mã Khách";
                if (dgvEmployee.Columns.Contains("HOKH")) dgvEmployee.Columns["HOKH"].HeaderText = "Họ";
                if (dgvEmployee.Columns.Contains("TENKH")) dgvEmployee.Columns["TENKH"].HeaderText = "Tên";
                if (dgvEmployee.Columns.Contains("SDT")) dgvEmployee.Columns["SDT"].HeaderText = "Số điện thoại";
                if (dgvEmployee.Columns.Contains("TENDANGNHAP")) dgvEmployee.Columns["TENDANGNHAP"].HeaderText = "Tên đăng nhập";
            }
        }

        private void frmManageAcc_Load(object sender, EventArgs e)
        {
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[] { "Nhân viên", "Khách thuê" });
            cboRole.SelectedIndex = 0;
        }

        private void ChuyenDoiGiaoDien(bool laNhanVien)
        {
            if (laNhanVien)
            {
                lbTitle.Text = "QUẢN LÝ TÀI KHOẢN NHÂN VIÊN";

                txtEmail.Visible = true;

                if (this.Controls.ContainsKey("lblCCCD")) this.Controls["lblCCCD"].Visible = false;
                if (this.Controls.ContainsKey("txtCCCD")) this.Controls["txtCCCD"].Visible = false;
                if (this.Controls.ContainsKey("lblBirthDate")) this.Controls["lblBirthDate"].Visible = false;
                if (this.Controls.ContainsKey("dtpBirthDate")) this.Controls["dtpBirthDate"].Visible = false;

            }
            else
            {
                lbTitle.Text = "QUẢN LÝ TÀI KHOẢN KHÁCH THUÊ";

                txtEmail.Visible = false;

                if (this.Controls.ContainsKey("lblCCCD")) this.Controls["lblCCCD"].Visible = true;
                if (this.Controls.ContainsKey("txtCCCD")) this.Controls["txtCCCD"].Visible = true;
                if (this.Controls.ContainsKey("lblBirthDate")) this.Controls["lblBirthDate"].Visible = true;
                if (this.Controls.ContainsKey("dtpBirthDate")) this.Controls["dtpBirthDate"].Visible = true;
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laNhanVien = (cboRole.SelectedIndex == 0);

            ChuyenDoiGiaoDien(laNhanVien);
            LoadData();
            btReset_Click(sender, e);
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

                if (cboRole.SelectedIndex == 0) // Nhân viên
                {
                    txtFirstName.Text = row.Cells["HONV"].Value?.ToString();
                    txtName.Text = row.Cells["TENNV"].Value?.ToString();
                    txtPhoneNumber.Text = row.Cells["SDT"].Value?.ToString();
                    txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();

                    var cellValue = row.Cells["MANV"].Value;
                    idSelected = (cellValue != null && cellValue != DBNull.Value) ? Convert.ToInt32(cellValue) : 0;
                }
                else // Khách thuê
                {
                    txtFirstName.Text = row.Cells["HOKH"].Value?.ToString();
                    txtName.Text = row.Cells["TENKH"].Value?.ToString();
                    txtPhoneNumber.Text = row.Cells["SDT"].Value?.ToString();

                    if (dgvEmployee.Columns.Contains("CCCD") && this.Controls.ContainsKey("txtCCCD"))
                        this.Controls["txtCCCD"].Text = row.Cells["CCCD"].Value?.ToString();

                    if (dgvEmployee.Columns.Contains("NGAYSINH") && this.Controls.ContainsKey("dtpBirthDate"))
                    {
                        var ngaySinh = row.Cells["NGAYSINH"].Value;
                        if (ngaySinh != null && ngaySinh != DBNull.Value)
                            ((DateTimePicker)this.Controls["dtpBirthDate"]).Value = Convert.ToDateTime(ngaySinh);
                    }

                    var cellValue = row.Cells["MAKH"].Value;
                    idSelected = (cellValue != null && cellValue != DBNull.Value) ? Convert.ToInt32(cellValue) : 0;
                }

                txtUserName.Text = row.Cells["TENDANGNHAP"].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["MATKHAU"].Value?.ToString() ?? "";
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            idSelected = 0;
            txtFirstName.Clear();
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtFirstName.Focus();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ và Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDangNhapMacDinh = (txtName.Text.Trim() + txtPhoneNumber.Text.Trim()).ToLower();
            string matKhauMacDinh = "123456";

            if (cboRole.SelectedIndex == 0)
            {
                DTO_NhanVien nv = new DTO_NhanVien()
                {
                    HONV = txtFirstName.Text.Trim(),
                    TENNV = txtName.Text.Trim(),
                    SDT = txtPhoneNumber.Text.Trim(),
                    EMAIL = txtEmail.Text.Trim(),
                    CHUCVU = "Nhân viên"
                };

                string ketQua = busNhanVien.ThemNhanVien(nv, tenDangNhapMacDinh, matKhauMacDinh);
                XulyKetQuaTraVe(ketQua, tenDangNhapMacDinh, matKhauMacDinh);
            }
            else // KHÁCH THUÊ
            {
                DTO_KHACHTHUE kh = new DTO_KHACHTHUE()
                {
                    HOKH = txtFirstName.Text.Trim(),
                    TENKH = txtName.Text.Trim(),
                    SDT = txtPhoneNumber.Text.Trim(),
                    NGAYBATDAUTHUE = DateTime.Today,
                    TRANGTHAITHUE = TrangThaiKhachThue.DangThue,
                };

                string ketQua = busKhachHang.ThemKhachThue(kh, tenDangNhapMacDinh, matKhauMacDinh);

                XulyKetQuaTraVe(ketQua, tenDangNhapMacDinh, matKhauMacDinh);
            }
        }
        private void XulyKetQuaTraVe(string ketQua, string tk, string mk)
        {
            if (ketQua == "THÀNH CÔNG")
            {
                MessageBox.Show("Thêm thành công tài khoản!\nTài khoản: {tk}\nMật khẩu: {mk}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btReset_Click(null, null);
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (idSelected == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng từ danh sách trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboRole.SelectedIndex == 0)
            {
                DTO_NhanVien nv = new DTO_NhanVien()
                {
                    MANV = idSelected,
                    HONV = txtFirstName.Text.Trim(),
                    TENNV = txtName.Text.Trim(),
                    SDT = txtPhoneNumber.Text.Trim(),
                    EMAIL = txtEmail.Text.Trim(),
                    CHUCVU = "Nhân viên"
                };
                string ketQuaNV = busNhanVien.SuaNhanVien(nv);
                DTO_TAIKHOAN tkNV = new DTO_TAIKHOAN()
                {
                    TENDANGNHAP = txtUserName.Text.Trim(),
                    MATKHAU = txtPassword.Text.Trim(),
                    LOAITK = LoaiTaiKhoan.NV,
                    MANV = idSelected
                };
                string ketQuaTK = busTaiKhoan.SuaTaiKhoan(tkNV);
                if (ketQuaNV == "THÀNH CÔNG" && ketQuaTK == "THÀNH CÔNG")
                {
                    MessegeBoxKetQua("THÀNH CÔNG", "Cập nhật thông tin nhân viên và tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show(string.Format("Có lỗi xảy ra!\nNhân viên: {0}\nTài khoản: {1}", ketQuaNV, ketQuaTK, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }
            else
            {
                DTO_KHACHTHUE kh = new DTO_KHACHTHUE()
                {
                    MAKH = idSelected,
                    HOKH = txtFirstName.Text.Trim(),
                    TENKH = txtName.Text.Trim(),
                    SDT = txtPhoneNumber.Text.Trim()
                };
                string ketQuaKH = busKhachHang.SuaKhachThue(kh);
                DTO_TAIKHOAN tkKH = new DTO_TAIKHOAN()
                {
                    TENDANGNHAP = txtUserName.Text.Trim(),
                    MATKHAU = txtPassword.Text.Trim(),
                    LOAITK = LoaiTaiKhoan.KH,
                    MAKH = idSelected
                };
                string ketQuaTK = busTaiKhoan.SuaTaiKhoan(tkKH);


                if (ketQuaKH == "THÀNH CÔNG" && ketQuaTK == "THÀNH CÔNG")
                {
                    MessegeBoxKetQua("THÀNH CÔNG", "Cập nhật thông tin khách thuê và tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show(string.Format("Có lỗi xảy ra!\nKhách thuê: {0}\nTài khoản: {1}", ketQuaKH, ketQuaTK, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }
        }

        private void MessegeBoxKetQua(string ketQua, string msgThanhCong)
        {
            if (ketQua == "THÀNH CÔNG")
            {
                MessageBox.Show(msgThanhCong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btReset_Click(null, null);
            }
            else
            {
                MessageBox.Show(ketQua, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (idSelected == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần xóa dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Xác nhận xóa đối tượng này khỏi hệ thống?\nThao tác này đồng thời gỡ bỏ tài khoản đăng nhập liên kết!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string ketQua = (cboRole.SelectedIndex == 0)
                    ? busNhanVien.XoaNhanVien(idSelected)
                    : busKhachHang.XoaKhachHang(idSelected);

                MessegeBoxKetQua(ketQua, "Xóa toàn bộ thông tin gốc và tài khoản thành công!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex == 0)
            {
                dgvEmployee.DataSource = busNhanVien.TimKiemNhanVien(txtSearch.Text);
            }
            else
            {
                dgvEmployee.DataSource = busKhachHang.TimKiemKhachHang(txtSearch.Text);
            }
        }
    }
}