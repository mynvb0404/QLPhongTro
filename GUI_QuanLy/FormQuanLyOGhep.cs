using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class FormQuanLyOGhep : Form
    {
        private BUS_TINOGHEP busTinOGhep = new BUS_TINOGHEP();
        private int _maTinDangChon = -1;

        public FormQuanLyOGhep()
        {
            InitializeComponent();

            // Đăng ký event thủ công 
            btnThemTin.Click += btnThemTin_Click;
            btnSuaTin.Click += btnSuaTin_Click;
            btnXoaTin.Click += btnXoaTin_Click;
            btnCNTT.Click += btnCNTT_Click;
            btnTK.Click += btnTK_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        private readonly List<(int Ma, string Ten)> _danhSachPhong = new()
        {
            (1, "Phòng 101 - KV001"),
            (2, "Phòng 102 - KV001"),
            (3, "Phòng 201 - KV002"),
            (4, "Phòng 301 - KV003"),
        };

        private readonly List<(int Ma, string Ten)> _danhSachKH = new()
        {
            (1, "Phạm Minh Tuấn"),
            (2, "Lê Thị Mai"),
            (3, "Hoàng Văn Đông"),
        };

        // LOAD FORM
        private void FormQuanLyOGhep_Load(object? sender, EventArgs e)
        {
            KhoiTaoCboPhong();
            KhoiTaoCboKhachHang();
            KhoiTaoCboGioiTinh();
            KhoiTaoCboTrangThai();
            KhoiTaoCboTKGioiTinh();
            KhoiTaoCboTKPhong();

            TaiDuLieuLenGrid(0);
        }


        private void KhoiTaoCboPhong()
        {
            cboMaPhong.Items.Clear();
            cboMaPhong.Items.Add("-- Chọn phòng --");
            foreach (var p in _danhSachPhong)
                cboMaPhong.Items.Add($"{p.Ma} - {p.Ten}");
            cboMaPhong.SelectedIndex = 0;
        }

        private void KhoiTaoCboKhachHang()
        {
            cboMaKH.Items.Clear();
            cboMaKH.Items.Add("-- Chọn khách hàng --");
            foreach (var k in _danhSachKH)
                cboMaKH.Items.Add($"{k.Ma} - {k.Ten}");
            cboMaKH.SelectedIndex = 0;
        }

        private void KhoiTaoCboGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0;
        }

        private void KhoiTaoCboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang tìm");
            cboTrangThai.Items.Add("Đã đủ người");
            cboTrangThai.Items.Add("Đã đóng");
            cboTrangThai.SelectedIndex = 0;
        }

        private void KhoiTaoCboTKGioiTinh()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("-- Tất cả --");
            comboBox4.Items.Add("Nam");
            comboBox4.Items.Add("Nữ");
            comboBox4.SelectedIndex = 0;
        }

        private void KhoiTaoCboTKPhong()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("-- Tất cả --");
            foreach (var p in _danhSachPhong)
                comboBox3.Items.Add($"{p.Ma} - {p.Ten}");
            comboBox3.SelectedIndex = 0;
        }

        private int LayMaTuComboBox(ComboBox cbo)
        {
            if (cbo.SelectedIndex <= 0) return -1;
            string item = cbo.SelectedItem?.ToString() ?? "";
            string[] parts = item.Split('-');
            if (int.TryParse(parts[0].Trim(), out int ma)) return ma;
            return -1;
        }

        private void TaiDuLieuLenGrid(int maPhong)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;

                DataTable dt = busTinOGhep.LayDanhSachTinTheoPhong(maPhong);
                dataGridView1.DataSource = dt;


                HideColumnIfExists("MOTA");
                HideColumnIfExists("MaPhongRaw");
                HideColumnIfExists("MaKHRaw");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideColumnIfExists(string colName)
        {
            if (dataGridView1.Columns.Contains(colName))
                dataGridView1.Columns[colName].Visible = false;
        }


        private DTO_TINOGHEP? DocDuLieuTuForm()
        {
            int maPhong = LayMaTuComboBox(cboMaPhong);
            if (maPhong <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int maKH = LayMaTuComboBox(cboMaKH);
            if (maKH <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int soNguoi = (int)numericUpDown1.Value;
            if (soNguoi <= 0)
            {
                MessageBox.Show("Số người cần phải lớn hơn 0!", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            GioiTinh gt = (cboGioiTinh.SelectedItem?.ToString() == "Nam")
                          ? GioiTinh.Nam : GioiTinh.Nu;

            if (!decimal.TryParse(txtGiaChia.Text.Trim(), out decimal giaChia) || giaChia <= 0)
            {
                MessageBox.Show("Giá chia không hợp lệ! Vui lòng nhập số lớn hơn 0.",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string moTa = txtMoTa.Text.Trim();
            TrangThaiTinOGhep tt = ChuyenDoiTrangThai(cboTrangThai.SelectedItem?.ToString());

            return new DTO_TINOGHEP(
                matinog: _maTinDangChon > 0 ? _maTinDangChon : 0,
                maphong: maPhong,
                makh: maKH,
                songuoican: soNguoi,
                gioitinh: gt,
                giachia: giaChia,
                mota: moTa,
                trangthaitin: tt
            );
        }

        private TrangThaiTinOGhep ChuyenDoiTrangThai(string? str)
        {
            return str switch
            {
                "Đã đủ người" => TrangThaiTinOGhep.DaDuNguoi,
                "Đã đóng" => TrangThaiTinOGhep.DaDong,
                _ => TrangThaiTinOGhep.DangTim
            };
        }

        private void ChonComboBoxTheoMa(ComboBox cbo, int ma)
        {
            for (int i = 1; i < cbo.Items.Count; i++)
            {
                string item = cbo.Items[i]?.ToString() ?? "";
                if (item.StartsWith(ma + " -"))
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
        }

        private void XoaForm()
        {
            cboMaPhong.SelectedIndex = 0;
            cboMaKH.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            cboGioiTinh.SelectedIndex = 0;
            txtGiaChia.Clear();
            txtMoTa.Clear();
            cboTrangThai.SelectedIndex = 0;
            _maTinDangChon = -1;   
        }


        private void btnThemTin_Click(object? sender, EventArgs e)
        {
            _maTinDangChon = -1;

            DTO_TINOGHEP? dto = DocDuLieuTuForm();
            if (dto == null) return;

            dto.TRANGTHAITIN = TrangThaiTinOGhep.DangTim;

            string ketQua = "";
            try
            {
                ketQua = busTinOGhep.ThemTinOGhep(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\nInner: " + ex.InnerException?.Message,
                                "Chi tiết lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Đăng tin thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaForm();

                TaiDuLieuLenGrid(0);
            }
            else
            {
                MessageBox.Show("Lỗi: " + ketQua, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BUTTON: SỬA TIN
        private void btnSuaTin_Click(object? sender, EventArgs e)
        {
            if (_maTinDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một tin từ danh sách để sửa!",
                                "Chưa chọn tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_TINOGHEP? dto = DocDuLieuTuForm();
            if (dto == null) return;

            string ketQua = "";
            try
            {
                ketQua = busTinOGhep.SuaTinOGhep(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Chi tiết lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật tin thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaForm();
                TaiDuLieuLenGrid(0);
            }
            else
            {
                MessageBox.Show("Lỗi: " + ketQua, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BUTTON: XÓA TIN 
        private void btnXoaTin_Click(object? sender, EventArgs e)
        {
            if (_maTinDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một tin từ danh sách để xóa!",
                                "Chưa chọn tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn đóng tin mã {_maTinDangChon}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string ketQua = "";
            try
            {
                ketQua = busTinOGhep.CapNhatTrangThaiTin(
                    _maTinDangChon, TrangThaiTinOGhep.DaDong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Chi tiết lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Đã đóng tin thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaForm();
                TaiDuLieuLenGrid(0);
            }
            else
            {
                MessageBox.Show("Lỗi: " + ketQua, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BUTTON: CẬP NHẬT TRẠNG THÁI
        private void btnCNTT_Click(object? sender, EventArgs e)
        {
            if (_maTinDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một tin từ danh sách!",
                                "Chưa chọn tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TrangThaiTinOGhep tt = ChuyenDoiTrangThai(cboTrangThai.SelectedItem?.ToString());

            string ketQua = "";
            try
            {
                ketQua = busTinOGhep.CapNhatTrangThaiTin(_maTinDangChon, tt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Chi tiết lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDuLieuLenGrid(0);
            }
            else
            {
                MessageBox.Show("Lỗi: " + ketQua, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BUTTON: TÌM KIẾM
        private void btnTK_Click(object? sender, EventArgs e)
        {
            int maPhong = 0;
            if (comboBox3.SelectedIndex > 0)
            {
                string item = comboBox3.SelectedItem?.ToString() ?? "";
                string[] parts = item.Split('-');
                int.TryParse(parts[0].Trim(), out maPhong);
            }

            string gioiTinh = comboBox4.SelectedIndex > 0
                              ? comboBox4.SelectedItem?.ToString() ?? "" : "";

            decimal giaMax = 0;
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                if (!decimal.TryParse(textBox3.Text.Trim(), out giaMax))
                {
                    MessageBox.Show("Giá chia tìm kiếm không hợp lệ!",
                                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int soNguoi = (int)numericUpDown3.Value;

            try
            {

                DataTable dt = busTinOGhep.TimKiemTinOGhep(maPhong, gioiTinh, giaMax, soNguoi);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;

                HideColumnIfExists("MOTA");
                HideColumnIfExists("MaPhongRaw");
                HideColumnIfExists("MaKHRaw");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            object? maTinObj = null;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.DataPropertyName == "MATINOG")
                {
                    maTinObj = row.Cells[col.Index].Value;
                    break;
                }
            }

            if (!int.TryParse(maTinObj?.ToString(), out int maTin)) return;
            _maTinDangChon = maTin;

            string GetCellValue(string dataPropName)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    if (col.DataPropertyName == dataPropName)
                        return row.Cells[col.Index].Value?.ToString() ?? "";
                return "";
            }

            string maPhongStr = GetCellValue("MAPHONG");
            if (int.TryParse(maPhongStr, out int maPhong))
                ChonComboBoxTheoMa(cboMaPhong, maPhong);

            string maKHStr = GetCellValue("MAKH");
            if (int.TryParse(maKHStr, out int maKH))
                ChonComboBoxTheoMa(cboMaKH, maKH);

            string soNguoiStr = GetCellValue("SONGUOICAN");
            if (int.TryParse(soNguoiStr, out int soNguoi))
                numericUpDown1.Value = Math.Max(numericUpDown1.Minimum,
                                       Math.Min(numericUpDown1.Maximum, soNguoi));

            string gt = GetCellValue("GIOITINH");
            int idxGT = cboGioiTinh.FindStringExact(gt);
            if (idxGT >= 0) cboGioiTinh.SelectedIndex = idxGT;


            txtGiaChia.Text = GetCellValue("GIACHIA");

            txtMoTa.Text = GetCellValue("MOTA");


            string tt = GetCellValue("TRANGTHAITIN");
            int idxTT = cboTrangThai.FindStringExact(tt);
            if (idxTT >= 0) cboTrangThai.SelectedIndex = idxTT;
        }

        private void numericUpDown1_ValueChanged(object? sender, EventArgs e) { }
    }
}