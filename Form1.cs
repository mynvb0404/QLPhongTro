using BUS_QuanLy;
using DTO_QuanLy;

namespace Lịch_Hẹn
{
    public partial class frmLichHen : Form
    {
        // tạo BUS
        BUS_LichHen busLH = new BUS_LichHen();
        public frmLichHen()
        {
            InitializeComponent();
        }
        // load form
        private void frmLichHen_Load(object sender, EventArgs e)
        {
            LoadDanhSachLichHen();

            cboTrangThai.Items.Add("Chờ xác nhận");
            cboTrangThai.Items.Add("Đã xác nhận");
            cboTrangThai.Items.Add("Đã hủy");
        }

        // hàm load data
        void LoadDanhSachLichHen()
        {
            dgvLichHen.DataSource =
                busLH.LayDanhSachLichHen();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text == "" ||
                   txtMaNV.Text == "")
                {
                    MessageBox.Show("Nhập thiếu dữ liệu");
                    return;
                }

                DTO_LichHen lh = new DTO_LichHen();

                lh.MAKH = int.Parse(txtMaKH.Text);

                lh.MANV = int.Parse(txtMaNV.Text);

                lh.MAPHONG =
                    Convert.ToInt32(cboPhong.Text);

                lh.THOIGIANHEN =
                    dtpThoiGianHen.Value;

                lh.TRANGTHAIHEN =
                    cboTrangThai.Text;

                lh.NOIDUNGHEN =
                    txtNoiDung.Text;

                lh.THOIGIANTAO =
                    DateTime.Now;

                lh.THOIGIANCAPNHAT =
                    DateTime.Now;

                if (busLH.ThemLichHen(lh))
                {
                    MessageBox.Show("Thêm thành công");

                    dgvLichHen.DataSource =
                        busLH.LayDanhSachLichHen();
                }
                else
                {
                    MessageBox.Show("SQL không thêm được");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvLichHen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;

            if (dong >= 0)
            {
                txtMaLH.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["MALH"].Value.ToString();

                txtMaKH.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["MAKH"].Value.ToString();

                txtMaNV.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["MANV"].Value.ToString();

                cboPhong.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["MAPHONG"].Value.ToString();

                cboTrangThai.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["TRANGTHAIHEN"].Value.ToString();

                txtNoiDung.Text =
                    dgvLichHen.Rows[dong]
                    .Cells["NOIDUNGHEN"].Value.ToString();

                dtpThoiGianHen.Value =
                    Convert.ToDateTime(
                        dgvLichHen.Rows[dong]
                        .Cells["THOIGIANHEN"].Value);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_LichHen lh = new DTO_LichHen();

            lh.MALH = int.Parse(txtMaLH.Text);

            lh.MAKH = int.Parse(txtMaKH.Text);

            lh.MANV = int.Parse(txtMaNV.Text);

            lh.MAPHONG = int.Parse(cboPhong.Text);

            lh.THOIGIANHEN = dtpThoiGianHen.Value;

            lh.TRANGTHAIHEN = cboTrangThai.Text;

            lh.NOIDUNGHEN = txtNoiDung.Text;

            lh.THOIGIANTAO = DateTime.Now;

            lh.THOIGIANCAPNHAT = DateTime.Now;

            if (busLH.SuaLichHen(lh))
            {
                MessageBox.Show("Sửa thành công");

                LoadDanhSachLichHen();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaLH.Text);
            if (busLH.XoaLichHen(id))
            {
                MessageBox.Show("Hủy thành công");
                LoadDanhSachLichHen();
            }
            else
            {
                MessageBox.Show("Hủy thất bại");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvLichHen.DataSource =
        busLH.LayDanhSachLichHen();
        }
    }
}
   
   