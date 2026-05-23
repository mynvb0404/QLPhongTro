using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DAL_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmLogin : Form
    {
        private BUS_TaiKhoan tkBUS = new BUS_TaiKhoan();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            if (cboRole.SelectedIndex == 0)
            {
                lbUserName.Text = "Tên đăng nhập";
                txtUsername.PlaceholderText = "Nhập tên đăng nhập của bạn";
            }
            else if (cboRole.SelectedIndex == 1)
            {
                lbUserName.Text = "Số điện thoại";
                txtUsername.PlaceholderText = "Nhập số điện thoại";
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taiKhoan = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();
            DTO_TAIKHOAN tkAccount = tkBUS.DangNhap(taiKhoan, matKhau);

            if (tkAccount == null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBConnect db = new DBConnect();
            string hoTen = "";
            string email = "";

            if (cboRole.SelectedIndex == 0) // ---- KIỂM TRA QUYỀN NHÂN VIÊN ----
            {
                if (tkAccount.LOAITK == LoaiTaiKhoan.NV)
                {
                    string sqlNV = $"SELECT HONV + ' ' + TENNV AS HOTEN, EMAIL FROM NHANVIEN WHERE MANV = {tkAccount.MANV}";
                    DataTable dtNV = db.ExecuteQuery(sqlNV);
                    if (dtNV != null && dtNV.Rows.Count > 0)
                    {
                        hoTen = dtNV.Rows[0]["HOTEN"].ToString();
                        email = dtNV.Rows[0]["EMAIL"].ToString();
                    }
                    else
                    {
                        hoTen = "Nhân viên viên";
                        email = "nhanvien@system.com";
                    }

                    MessageBox.Show("Đăng nhập quyền Nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền truy cập dành cho Nhân viên!", "Sai vai trò", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (cboRole.SelectedIndex == 1) // ---- KIỂM TRA QUYỀN KHÁCH THUÊ ----
            {
                if (tkAccount.LOAITK == LoaiTaiKhoan.KH)
                {
                    string sqlKH = $"SELECT HOKH + ' ' + TENKH AS HOTEN, SDT FROM KHACHTHUE WHERE MAKH = {tkAccount.MAKH}";
                    DataTable dtKH = db.ExecuteQuery(sqlKH);

                    if (dtKH != null && dtKH.Rows.Count > 0)
                    {
                        hoTen = dtKH.Rows[0]["HOTEN"].ToString();
                        email = dtKH.Rows[0]["SDT"].ToString();
                    }
                    else
                    {
                        hoTen = "Khách thuê";
                        email = taiKhoan;
                    }

                    MessageBox.Show("Đăng nhập quyền Khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Số điện thoại này không đăng ký quyền Khách thuê!", "Sai vai trò", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            frmMenu mainMenu = new frmMenu(hoTen, email, tkAccount.LOAITK.ToString());

            this.Hide();

            mainMenu.FormClosed += (s, args) =>
            {
                if (!this.Visible)
                {
                    this.Close();
                }
            };

            mainMenu.Show();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cboRole.SelectedIndex = 0;
        }
    }
}