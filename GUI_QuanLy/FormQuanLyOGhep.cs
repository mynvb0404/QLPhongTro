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

    public partial class FormQuanLyOGhep : Form
    {
        BUS_TINOGHEP busTin = new BUS_TINOGHEP();
        public FormQuanLyOGhep()
        {
            InitializeComponent();
        }

        private void FormQuanLyOGhep_Load(object sender, EventArgs e)
        {
            LoadDuLieuVaoComboBox();
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nu" }); // Khớp hoàn toàn với Enum GioiTinh của bạn
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            HienThiDanhSachTin(0);
        }

        private void LoadDuLieuVaoComboBox()
        {
            try
            {
                // --- NẠP DỮ LIỆU PHÒNG ---
                // Khởi tạo lớp xử lý Phòng (đảm bảo tầng BUS của bạn đã có lớp BUS_Phong)
                BUS_Phong busPhong = new BUS_Phong();
                DataTable dtPhong = busPhong.LayDanhSachPhong();

                if (dtPhong != null && dtPhong.Rows.Count > 0)
                {
                    // Tạo cột hiển thị gộp: "MAPHONG – TENPHONG" giống ảnh mẫu
                    dtPhong.Columns.Add("HienThiPhong", typeof(string), "MAPHONG + ' – ' + TENPHONG");

                    cboMaPhong.DataSource = dtPhong;
                    cboMaPhong.DisplayMember = "HienThiPhong"; // Chữ hiển thị ra
                    cboMaPhong.ValueMember = "MAPHONG";        // Giá trị số nguyên ẩn bên dưới
                }

                // --- NẠP DỮ LIỆU KHÁCH THUÊ ---
                BUS_KhachThue busKhach = new BUS_KhachThue();
                DataTable dtKhach = busKhach.LayDanhSachKhachThue();

                if (dtKhach != null && dtKhach.Rows.Count > 0)
                {
                    // Tạo cột hiển thị gộp: "MAKH – HOKH TENKH" giống ảnh mẫu
                    dtKhach.Columns.Add("HienThiKhach", typeof(string), "MAKH + ' – ' + HOKH + ' ' + TENKH");

                    cboMaKH.DataSource = dtKhach;
                    cboMaKH.DisplayMember = "HienThiKhach";
                    cboMaKH.ValueMember = "MAKH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu ComboBox: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //private void HienThiDanhSachTin()
        //{
        //    try
        //    {
        //        // Giả sử lấy mã phòng từ ComboBox cboMaPhong (đang chọn trên giao diện)
        //        // Nếu cboMaPhong chứa Object/DataRow, bạn cần ép kiểu phù hợp. Ở đây ví dụ lấy từ Text/Value:
        //        if (int.TryParse(cboMaPhong.Text, out int maPhong))
        //        {
        //            DataTable dt = busTin.LayDanhSachTinTheoPhong(maPhong); // Truyền maPhong vào đây
        //            dgvDSTin.DataSource = dt;
        //            dgvDSTin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //        }
        //        else
        //        {
        //            // Nếu chưa chọn phòng, truyền đại diện 1 mã hoặc load trống
        //            DataTable dt = busTin.LayDanhSachTinTheoPhong(0);
        //            dgvDSTin.DataSource = dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void HienThiDanhSachTin(int maPhongTarget)
        {
            try
            {
                // Lấy dữ liệu từ lớp BUS đã xử lý cấu trúc mới
                DataTable dt = busTin.LayDanhSachTinTheoPhong(maPhongTarget);
                dgvDSTin.DataSource = dt;

                // Ẩn bớt các cột phục vụ kỹ thuật click, không cần hiển thị lên lưới cho người dùng xem
                if (dgvDSTin.Columns.Contains("MoTa")) dgvDSTin.Columns["MoTa"].Visible = false;
                if (dgvDSTin.Columns.Contains("MaPhongRaw")) dgvDSTin.Columns["MaPhongRaw"].Visible = false;
                if (dgvDSTin.Columns.Contains("MaKHRaw")) dgvDSTin.Columns["MaKHRaw"].Visible = false;

                // Định dạng DataGridView trực quan và chuyên nghiệp
                dgvDSTin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDSTin.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Click chọn cả dòng
                dgvDSTin.AllowUserToAddRows = false; // Tắt dòng trống thừa ở cuối bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i = e.RowIndex;
            //if (i >= 0)
            //{
            //    // Đưa dữ liệu từ dòng đang chọn lên các Controls phía trên
            //    // Lưu ý: Tên trong ngoặc ["..."] phải khớp với tên cột trong SQL của bạn
            //    cboMaPhong.Text = dgvDSTin.Rows[i].Cells["MaPhong"].Value.ToString();
            //    cboMaKH.Text = dgvDSTin.Rows[i].Cells["MaKH"].Value.ToString();
            //    numericUpDown1.Value = Convert.ToDecimal(dgvDSTin.Rows[i].Cells["SoNguoi"].Value);
            //    txtGiaChia.Text = dgvDSTin.Rows[i].Cells["GiaChia"].Value.ToString();
            //    cboTrangThai.Text = dgvDSTin.Rows[i].Cells["TrangThai"].Value.ToString();
            //    txtMoTa.Text = dgvDSTin.Rows[i].Cells["MoTa"].Value.ToString();
            //}

            int i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow row = dgvDSTin.Rows[i];

                // SỬA CHUẨN XÁC: Chọn đúng ValueMember ẩn trong ComboBox dựa theo cột ẩn từ SQL
                if (row.Cells["MaPhongRaw"].Value != DBNull.Value)
                    cboMaPhong.SelectedValue = Convert.ToInt32(row.Cells["MaPhongRaw"].Value);

                if (row.Cells["MaKHRaw"].Value != DBNull.Value)
                    cboMaKH.SelectedValue = Convert.ToInt32(row.Cells["MaKHRaw"].Value);

                // Gán dữ liệu lên numericUpDown và các TextBox còn lại
                numericUpDown1.Value = Convert.ToDecimal(row.Cells["Số người"].Value ?? 0);
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                // Định dạng hiển thị tiền tệ cho đẹp mắt
                if (row.Cells["Giá chia"].Value != DBNull.Value)
                {
                    decimal giaChia = Convert.ToDecimal(row.Cells["Giá chia"].Value);
                    txtGiaChia.Text = giaChia.ToString("N0"); // Hiện thị kiểu phân cách dấu phẩy: 2,500,000
                }

                // Gán text cho Giới tính và Trạng thái thông thường
                cboGioiTinh.Text = row.Cells["Giới tính"].Value?.ToString() ?? "";
                cboTrangThai.Text = row.Cells["Trạng thái"].Value?.ToString() ?? "";
            }
        }

        private void btnThemTin_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra dữ liệu đầu vào cơ bản trước khi xử lý
                if (cboMaPhong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần đăng tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboMaKH.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng đăng tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtGiaChia.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá chia sẻ phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Khởi tạo đối tượng DTO và gán dữ liệu từ giao diện
                DTO_TINOGHEP tinMoi = new DTO_TINOGHEP();
                tinMoi.MAPHONG = Convert.ToInt32(cboMaPhong.SelectedValue);
                tinMoi.MAKH = Convert.ToInt32(cboMaKH.SelectedValue);
                tinMoi.SONGUOICAN = (int)numericUpDown1.Value;
                tinMoi.GIACHIA = decimal.Parse(txtGiaChia.Text.Replace(",", "")); // Loại bỏ dấu phẩy phân cách nếu có
                tinMoi.MOTA = txtMoTa.Text;

                // Gán Enum Giới tính dựa trên ComboBox
                tinMoi.GIOITINH = cboGioiTinh.Text == "Nam" ? GioiTinh.Nam : GioiTinh.Nu;

                // 3. Gọi tầng BUS để thực thi xử lý nghiệp vụ và ghi xuống SQL
                string ketQua = busTin.ThemTinOGhep(tinMoi);

                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Đăng tin ở ghép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại bảng dữ liệu sau khi thêm thành công để cập nhật lưới hiển thị
                    HienThiDanhSachTin(0);

                    // Xóa trống nội dung ô mô tả để chuẩn bị cho lượt nhập tiếp theo
                    txtMoTa.Text = "";
                }
                else
                {
                    MessageBox.Show(ketQua, "Yêu cầu nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi thêm dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
