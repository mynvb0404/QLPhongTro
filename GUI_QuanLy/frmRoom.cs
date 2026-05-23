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
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmRoom : Form
    {
        private BUS_Phong busPhong = new BUS_Phong();
        private BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();
        public frmRoom()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmRoom_Load);
        }

        private int idSelected = 0;

        private void frmRoom_Load(object sender, EventArgs e)
        {
            LoadKhuVucComboBox();
            LoadLoaiPhongComboBox();
            LoadTrangThaiComboBox();
            LoadDataPhong();
            ResetForm();
        }

        // Đổ Dữ Liệu Từ CSDL Vào ComboBox Khu Vực
        private void LoadKhuVucComboBox()
        {
            try
            {
                DataTable dtKV = busKhuVuc.LayDanhSachKhuVuc();
                if (dtKV != null && dtKV.Rows.Count > 0)
                {
                    cboArea.DataSource = dtKV;
                    cboArea.DisplayMember = "TENKV";
                    cboArea.ValueMember = "MAKV";
                    cboArea.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách khu vực: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoaiPhongComboBox()
        {
            cboType.Items.Clear();
            cboType.Items.Add("Phòng Thường");
            cboType.Items.Add("Phòng VIP");
            cboType.SelectedIndex = 0;
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadTrangThaiComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Còn trống");
            cboStatus.Items.Add("Đã thuê");
            cboStatus.Items.Add("Cần ở ghép");
            cboStatus.SelectedIndex = 0;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Tải Danh Sách Phòng Lên Lưới Hiển Thị
        private void LoadDataPhong()
        {
            DataTable dt = busPhong.LayDanhSachPhong();
            dgvRoom.DataSource = dt;

            if (dgvRoom.Columns.Contains("MAPHONG")) dgvRoom.Columns["MAPHONG"].HeaderText = "Mã Phòng";
            if (dgvRoom.Columns.Contains("TENPHONG")) dgvRoom.Columns["TENPHONG"].HeaderText = "Tên Phòng";
            if (dgvRoom.Columns.Contains("MAKV")) dgvRoom.Columns["MAKV"].HeaderText = "Mã Khu Vực";
            if (dgvRoom.Columns.Contains("GIAPHONG")) dgvRoom.Columns["GIAPHONG"].HeaderText = "Giá Phòng (VND)";
            if (dgvRoom.Columns.Contains("DIENTICH")) dgvRoom.Columns["DIENTICH"].HeaderText = "Diện Tích (m²)";
            if (dgvRoom.Columns.Contains("LOAIPHONG")) dgvRoom.Columns["LOAIPHONG"].HeaderText = "Loại Phòng";
            if (dgvRoom.Columns.Contains("TRANGTHAIPHONG")) dgvRoom.Columns["TRANGTHAIPHONG"].HeaderText = "Trạng Thái";
            if (dgvRoom.Columns.Contains("SONGUOIHIENTAI")) dgvRoom.Columns["SONGUOIHIENTAI"].HeaderText = "Số Người Ở";
            if (dgvRoom.Columns.Contains("NOITHAT")) dgvRoom.Columns["NOITHAT"].HeaderText = "Nội Thất";
        }

        // Sự Kiện Click Chọn Dòng Trên DataGridView
        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoom.Rows[e.RowIndex];

                idSelected = Convert.ToInt32(row.Cells["MAPHONG"].Value);
                txtName.Text = row.Cells["TENPHONG"].Value?.ToString();

                string maKV = row.Cells["MAKV"].Value?.ToString();
                if (!string.IsNullOrEmpty(maKV)) cboArea.SelectedValue = maKV;

                txtPrice.Text = row.Cells["GIAPHONG"].Value?.ToString();
                txtS.Text = row.Cells["DIENTICH"].Value?.ToString();
                cboType.SelectedItem = row.Cells["LOAIPHONG"].Value?.ToString();
                cboStatus.SelectedItem = row.Cells["TRANGTHAIPHONG"].Value?.ToString();
                txtPopulation.Text = row.Cells["SONGUOIHIENTAI"].Value?.ToString();
                txtFuniture.Text = row.Cells["NOITHAT"].Value?.ToString();

                btAdd.Enabled = false;
                btEdit.Enabled = true;
                btDelete.Enabled = true;
            }
        }

        // Chức Năng Thêm Phòng Mới
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaPhong = string.IsNullOrWhiteSpace(txtPrice.Text) ? 0 : Convert.ToDecimal(txtPrice.Text.Trim());
                double? dienTich = string.IsNullOrWhiteSpace(txtS.Text) ? null : (double?)Convert.ToDouble(txtS.Text.Trim());
                int soNguoi = string.IsNullOrWhiteSpace(txtPopulation.Text) ? 0 : Convert.ToInt32(txtPopulation.Text.Trim());
                DTO_PHONG p = new DTO_PHONG(
                    0,
                    txtName.Text.Trim(),
                    cboArea.SelectedValue?.ToString() ?? "",
                    giaPhong,
                    dienTich,
                    cboType.SelectedItem?.ToString() ?? "",
                    //cboStatus.SelectedItem?.ToString() ?? "",
                    TinhTrangPhong.ConTrong,
                    soNguoi,
                    txtFuniture.Text.Trim()
                );

                string ketQua = busPhong.ThemPhong(p);

                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Thêm mới phòng trọ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhong();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi kiểm tra nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá phòng, Diện tích hoặc Số người nhập vào phải là định dạng số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức Năng Cập Nhật Thông Tin Phòng
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (idSelected <= 0) return;

            try
            {
                decimal? giaPhong = string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)Convert.ToDecimal(txtPrice.Text.Trim());
                double? dienTich = string.IsNullOrWhiteSpace(txtS.Text) ? null : (double?)Convert.ToDouble(txtS.Text.Trim());
                int? soNguoi = string.IsNullOrWhiteSpace(txtPopulation.Text) ? null : (int?)Convert.ToInt32(txtPopulation.Text.Trim());
                string tenPhong = string.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim();
                string maKV = (cboArea.SelectedValue == null || string.IsNullOrWhiteSpace(cboArea.SelectedValue.ToString())) ? null : cboArea.SelectedValue.ToString();
                string loaiPhong = (cboType.SelectedItem == null || string.IsNullOrWhiteSpace(cboType.SelectedItem.ToString())) ? null : cboType.SelectedItem.ToString();
                string trangThai = (cboStatus.SelectedItem == null || string.IsNullOrWhiteSpace(cboStatus.SelectedItem.ToString())) ? null : cboStatus.SelectedItem.ToString();
                string noiThat = string.IsNullOrWhiteSpace(txtFuniture.Text) ? null : txtFuniture.Text.Trim();

                DTO_PHONG p = new DTO_PHONG(
                    idSelected,
                    tenPhong,
                    maKV,
                    giaPhong ?? 0,
                    dienTich,
                    loaiPhong,
                     Enum.TryParse(trangThai, out TinhTrangPhong tt) ? tt : TinhTrangPhong.ConTrong,  
                    soNguoi ?? 0,
                    noiThat
                );

                string ketQua = busPhong.SuaPhong(p);

                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Cập nhật dữ liệu phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhong();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi kiểm tra nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng kiểm tra lại định dạng dữ liệu số của Giá phòng/Diện tích/Số người!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức Năng Xóa Phòng
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (idSelected <= 0) return;

            DialogResult r = MessageBox.Show($"Bạn có chắc chắn muốn xóa dữ liệu của [{txtName.Text}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string ketQua = busPhong.XoaPhong(idSelected);

                if (ketQua == "THÀNH CÔNG")
                {
                    MessageBox.Show("Đã xóa phòng khỏi cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhong();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ketQua, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Thiết Lập Lại Trạng Thái Form Khởi Tạo
        private void ResetForm()
        {
            idSelected = 0;
            txtName.Clear();
            txtPrice.Clear();
            txtS.Clear();
            txtPopulation.Clear();
            txtFuniture.Clear();

            if (cboArea.Items.Count > 0) cboArea.SelectedIndex = 0;
            if (cboType.Items.Count > 0) cboType.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            btAdd.Enabled = true;
            btEdit.Enabled = false;
            btDelete.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDataPhong();
        }

        //Tìm Kiếm Phòng Nâng Cao
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string maKV = cboArea.SelectedValue?.ToString();

            decimal? minGia = string.IsNullOrWhiteSpace(txtPrice.Text) || txtPrice.Text == "0"
                ? null : (decimal?)Convert.ToDecimal(txtPrice.Text.Trim());

            decimal? maxGia = null;

            DTO_TINOGHEP tin = new DTO_TINOGHEP();
            if (cboStatus.SelectedItem?.ToString() == "Cần ở ghép")
            {
                tin.TRANGTHAITIN = TrangThaiTinOGhep.DangTim;
            }
            else
            {
                tin.TRANGTHAITIN = TrangThaiTinOGhep.DaDong;
            }

            dgvRoom.DataSource = busPhong.TimKiemPhong(maKV, minGia, maxGia, tin);
        }

        private void frmRoom_Load_1(object sender, EventArgs e)
        {

        }
    }
}
