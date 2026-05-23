using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using GUI_QuanLy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_QuanLy
{
    public partial class frmMenu : Form
    {
        private string roleUser = "";
        private Form activeForm = null;
        public frmMenu()
        {
            InitializeComponent();
            lbFullName.Text = "Khách";
            lbEmail.Text = "Chưa đăng nhập";
        }

        public frmMenu(string hoTen, string email, string roleUser)
        {
            InitializeComponent();


            lbFullName.Text = hoTen;
            lbEmail.Text = email;
            this.roleUser = roleUser;

            this.Load += frmMenu_Load;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            PhanQuyenChucNang();
        }

        private void PhanQuyenChucNang()
        {
            if (roleUser == "KH") 
            {
                btArea.Enabled = false;
                btAcc.Enabled = false;
                btReport.Enabled = false;
                btRoom.Enabled = false;
                btAppointment.Enabled = false;
            }
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Form formLogin = Application.OpenForms["frmLogin"];

                if (formLogin != null)
                {
                    formLogin.Show();
                }
                else
                {
                    frmLogin newLoginForm = new frmLogin();
                    newLoginForm.Show();
                }

                this.Close();
            }
        }
        private void ChangeBtnColors(Button clickedButton)
        {
            foreach (Control c in this.pnSideBar.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                }
            }

            clickedButton.BackColor = Color.LightBlue;
            clickedButton.ForeColor = Color.MediumPurple;
        }

        private void btRoom_Click(object sender, EventArgs e)
        {
            ChangeBtnColors((Button)sender);
            openChildForm(new frmRoom());
        }

        private void btAcc_Click(object sender, EventArgs e)
        {
            ChangeBtnColors((Button)sender);
            openChildForm(new frmManageAcc());
        }

        private void btArea_Click(object sender, EventArgs e)
        {
            ChangeBtnColors((Button)sender);
            openChildForm(new frmArea());
        }
    }
}
