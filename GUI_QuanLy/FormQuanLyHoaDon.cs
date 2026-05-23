using System;
using System.Data;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class FormQuanLyHoaDon : Form
    {
        private BUS_HoaDon busHoaDon = new BUS_HoaDon();
        private int maHoaDonDangChon = 0;

        public FormQuanLyHoaDon()
        {
            InitializeComponent();


            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            btnCapNhatHoaDon.Click += btnCapNhatHoaDon_Click;
            btnXoa.Click += btnXoa_Click;
            btnCapNhatTrangThai.Click += btnCapNhatTrangThai_Click;
            label1.Click += btnDanhSachHoaDon_Click;

            // Tự tính tổng tiền khi nhập
            txtTienNuoc.TextChanged += txtTienNuoc_TextChanged;
            txtTienDien.TextChanged += txtTienDien_TextChanged;
            txtTienPhatSinh.TextChanged += txtTienPhatSinh_TextChanged;
            txtTienThueNha.TextChanged += TxtTienThueNha_TextChanged;

            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
        }

        private void TxtTienThueNha_TextChanged(object? sender, EventArgs e)
        {

        }

        //  LOAD FORM

        private void FormQuanLyHoaDoncs_Load(object? sender, EventArgs e)
        {
            LoadComboBoxHopDong();
            LoadComboBoxTrangThai();
            LoadDanhSachHoaDon();
        }

        private void LoadComboBoxHopDong()
        {
            try
            {
                BUS_HopDong busHD = new BUS_HopDong();
                DataTable dt = busHD.LayHopDongConHieuLuc();
                cboMaHopDong.DataSource = dt;
                cboMaHopDong.DisplayMember = "MAHOPDONG";
                cboMaHopDong.ValueMember = "MAHOPDONG";
            }
            catch
            {
                cboMaHopDong.Items.Clear();
            }
        }

        private void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Chưa thanh toán");
            cboTrangThai.Items.Add("Đã thanh toán");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadDanhSachHoaDon()
        {
            try
            {
                dgvHoaDon.AutoGenerateColumns = true;
                DataTable dt = busHoaDon.LayDanhSachHoaDon();
                dgvHoaDon.DataSource = dt;

                SetCol("MAHOADON", "Mã HĐ");
                SetCol("MAHOPDONG", "Mã hợp đồng");
                SetCol("NGAYLAP", "Ngày lập");
                SetCol("TIENNUOC", "Tiền nước");
                SetCol("TIENDIEN", "Tiền điện");
                SetCol("TIENPHATSINH", "Tiền PS");
                SetCol("TIENTHUENHA", "Tiền thuê nhà");
                SetCol("TONGTIEN", "Tổng tiền");

                SetCol("TRANGTHAITT", "Trạng thái");
                SetCol("NGAYTHANHTOAN", "Ngày TT");
                SetCol("PHUONGTHUCTT", "Phương thức");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCol(string colName, string header)
        {
            if (dgvHoaDon.Columns.Contains(colName))
                dgvHoaDon.Columns[colName].HeaderText = header;
        }


        private DTO_HOADON DocDuLieuTuForm()
        {
            DTO_HOADON hd = new DTO_HOADON();
            hd.MAHOADON = maHoaDonDangChon;
            hd.MAHOPDONG = cboMaHopDong.SelectedValue?.ToString()
                           ?? cboMaHopDong.Text.Trim();

            decimal.TryParse(txtTienNuoc.Text.Trim(), out decimal nuoc);
            decimal.TryParse(txtTienDien.Text.Trim(), out decimal dien);
            decimal.TryParse(txtTienPhatSinh.Text.Trim(), out decimal ps);
            decimal.TryParse(txtTienThueNha.Text.Trim(), out decimal tn);

            hd.TIENNUOC = nuoc;
            hd.TIENDIEN = dien;
            hd.TIENPHATSINH = ps;
            hd.TIENTHUENHA = tn;
            hd.TONGTIEN = nuoc + dien + ps;    

            hd.TRANGTHAITT = cboTrangThai.SelectedIndex == 1
                ? TrangThaiThanhToan.DaThanhToan
                : TrangThaiThanhToan.ChuaThanhToan;

            return hd;
        }

        // Hiển thị thông báo kết quả
        private void ThongBao(string loi, string tieuDe = "Thông báo")
        {
            if (string.IsNullOrEmpty(loi))
                MessageBox.Show("Thao tác thành công!", tieuDe,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(loi, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void XoaTrang()
        {
            if (cboMaHopDong.Items.Count > 0)
                cboMaHopDong.SelectedIndex = 0;
            txtTienNuoc.Clear();
            txtTienDien.Clear();
            txtTienPhatSinh.Clear();
            txtTienThueNha.Clear();
            txtTongTien.Clear();
            cboTrangThai.SelectedIndex = 0;
            maHoaDonDangChon = 0;   
        }

        //  NÚT: TẠO HÓA ĐƠN
        private void btnTaoHoaDon_Click(object? sender, EventArgs e)
        {
            maHoaDonDangChon = 0;

            DTO_HOADON hd = DocDuLieuTuForm();
            string ketQua = busHoaDon.TaoHoaDon(hd);
            ThongBao(ketQua, "Tạo hóa đơn");

            if (string.IsNullOrEmpty(ketQua))
            {
                LoadDanhSachHoaDon();
                XoaTrang();
            }
        }

        //  NÚT: CẬP NHẬT HÓA ĐƠN 

        private void btnCapNhatHoaDon_Click(object ?sender, EventArgs e)
        {
            if (maHoaDonDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách!",
                    "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_HOADON hd = DocDuLieuTuForm();
            string ketQua = busHoaDon.CapNhatHoaDon(hd);
            ThongBao(ketQua, "Cập nhật hóa đơn");

            if (string.IsNullOrEmpty(ketQua))
            {
                LoadDanhSachHoaDon();
                XoaTrang();
            }
        }

        //  NÚT: XÓA HÓA ĐƠN
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (maHoaDonDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách!",
                    "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa hóa đơn #{maHoaDonDangChon}?\n" +
                "Chỉ nên xóa hóa đơn chưa thanh toán.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string ketQua = busHoaDon.XoaHoaDon(maHoaDonDangChon);
            ThongBao(ketQua, "Xóa hóa đơn");

            if (string.IsNullOrEmpty(ketQua))
            {
                LoadDanhSachHoaDon();
                XoaTrang();
            }
        }

        //  NÚT: CẬP NHẬT TRẠNG THÁI

        private void btnCapNhatTrangThai_Click(object? sender, EventArgs e)
        {
            if (maHoaDonDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách!",
                    "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TrangThaiThanhToan trangThai = cboTrangThai.SelectedIndex == 1
                ? TrangThaiThanhToan.DaThanhToan
                : TrangThaiThanhToan.ChuaThanhToan;

            string ketQua = busHoaDon.CapNhatTrangThaiHoaDon(maHoaDonDangChon, trangThai);
            ThongBao(ketQua, "Cập nhật trạng thái");

            if (string.IsNullOrEmpty(ketQua))
            {
                LoadDanhSachHoaDon();
                XoaTrang();
            }
        }

        //  NÚT LABEL: DANH SÁCH HÓA ĐƠN 

        private void btnDanhSachHoaDon_Click(object ?sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
            XoaTrang();
        }

        private void dgvHoaDon_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

            string GetVal(string col) =>
                dgvHoaDon.Columns.Contains(col)
                    ? row.Cells[col].Value?.ToString() ?? ""
                    : "";

            // Lấy mã hóa đơn đang chọn
            if (!int.TryParse(GetVal("MAHOADON"), out maHoaDonDangChon))
                maHoaDonDangChon = 0;

            // Mã hợp đồng
            string maHD = GetVal("MAHOPDONG");
            if (!string.IsNullOrEmpty(maHD))
            {
                cboMaHopDong.SelectedValue = maHD;
                if (cboMaHopDong.SelectedValue == null)
                    cboMaHopDong.Text = maHD;
            }

            txtTienNuoc.Text = GetVal("TIENNUOC");
            txtTienDien.Text = GetVal("TIENDIEN");
            txtTienPhatSinh.Text = GetVal("TIENPHATSINH");
            txtTienThueNha.Text = GetVal("TIENTHUENHA");


            if (decimal.TryParse(GetVal("TONGTIEN"), out decimal tong))
                txtTongTien.Text = tong.ToString("N0") + " đ";
            else
                txtTongTien.Text = GetVal("TONGTIEN");

            string tt = GetVal("TRANGTHAITT");
            cboTrangThai.SelectedIndex = tt == "Đã thanh toán" ? 1 : 0;
        }


        private void TinhTongTien()
        {
            decimal.TryParse(txtTienNuoc.Text, out decimal nuoc);
            decimal.TryParse(txtTienDien.Text, out decimal dien);
            decimal.TryParse(txtTienPhatSinh.Text, out decimal ps);
            decimal.TryParse(txtTienThueNha.Text, out decimal tn);
            txtTongTien.Text = (nuoc + dien + ps +tn).ToString("N0") + " đ";
        }

        private void txtTienNuoc_TextChanged(object? sender, EventArgs e) => TinhTongTien();
        private void txtTienDien_TextChanged(object ?sender, EventArgs e) => TinhTongTien();
        private void txtTienPhatSinh_TextChanged(object?sender, EventArgs e) => TinhTongTien();
        private void txtTienThueNha_TextChanged(object? sender, EventArgs e) => TinhTongTien();
    }
}