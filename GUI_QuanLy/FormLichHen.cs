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

                DTO_LICHHEN lh = new DTO_LICHHEN();

                lh.MAKH = int.Parse(txtMaKH.Text);

                lh.MANV = int.Parse(txtMaNV.Text);

                lh.MAPHONG =
                    Convert.ToInt32(cboPhong.Text);

                lh.THOIGIANHEN =
                    dtpThoiGianHen.Value;

                lh.TRANGTHAIHEN = cboTrangThai.SelectedIndex switch
                {
                    0 => TrangThaiLichHen.DaDat,
                    1 => TrangThaiLichHen.DaHuy,
                    2 => TrangThaiLichHen.HoanThanh,
                    _ => TrangThaiLichHen.DaDat
                };

                lh.NOIDUNGHEN =
                    txtNoiDung.Text;

                lh.THOIGIANTAO =
                    DateTime.Now;

                lh.THOIGIANCAPNHAT =
                    DateTime.Now;

                BUS_LichHen busLH = new BUS_LichHen();
                string ketQua = busLH.ThemLichHen(lh);

                if (ketQua == "THÀNH CÔNG")  // hoặc chuỗi mà BUS trả về khi thành công
                {
                    MessageBox.Show("Thêm thành công!");
                    dgvLichHen.DataSource = busLH.LayDanhSachLichHen();
                }
                else
                {
                    MessageBox.Show(ketQua); // hiển thị thông báo lỗi
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
            DTO_LICHHEN lh = new DTO_LICHHEN();

            lh.MALH = int.Parse(txtMaLH.Text);

            lh.MAKH = int.Parse(txtMaKH.Text);

            lh.MANV = int.Parse(txtMaNV.Text);

            lh.MAPHONG = int.Parse(cboPhong.Text);

            lh.THOIGIANHEN = dtpThoiGianHen.Value;

            lh.TRANGTHAIHEN = cboTrangThai.SelectedIndex switch
            {
                0 => TrangThaiLichHen.DaDat,
                1 => TrangThaiLichHen.DaHuy,
                2 => TrangThaiLichHen.HoanThanh,
                _ => TrangThaiLichHen.DaDat
            };

            lh.NOIDUNGHEN = txtNoiDung.Text;

            lh.THOIGIANTAO = DateTime.Now;

            lh.THOIGIANCAPNHAT = DateTime.Now;

            string ketQuaSua = busLH.SuaLichHen(lh);
            if (ketQuaSua == "THÀNH CÔNG")
            {
                MessageBox.Show("Sửa thành công");
                LoadDanhSachLichHen();
            }
            else
            {
                MessageBox.Show(ketQuaSua);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaLH.Text);
            string ketQuaXoa = busLH.XoaLichHen(id);
            if (ketQuaXoa == "THÀNH CÔNG")
            {
                MessageBox.Show("Hủy thành công");
                LoadDanhSachLichHen();
            }
            else
            {
                MessageBox.Show(ketQuaXoa);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvLichHen.DataSource =
        busLH.LayDanhSachLichHen();
        }

        private void frmLichHen_Load_1(object sender, EventArgs e)
        {

        }
    }
}
   
   