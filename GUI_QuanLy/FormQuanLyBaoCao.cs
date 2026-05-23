using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DAL_QuanLy;

namespace GUI_QuanLy
{
    public partial class FormQuanLyBaoCao : Form
    {
        private readonly DBConnect _db = new DBConnect();

        public FormQuanLyBaoCao()
        {
            InitializeComponent();
        }

        // Form Load
        private void FormQuanLyBaoCao_Load(object sender, EventArgs e)
        {
            string[] loaiList = new[]
            {
                "Thống kê phòng",
                "Thống kê doanh thu",
                "Thống kê lịch hẹn"
            };
            cmbLoaiThongKe.Items.AddRange(loaiList);
            cbLoaiBaoCao.Items.AddRange(loaiList);

            btnTKe.Click += btnTKe_Click;
            btnLuuBC.Click += btnLuuBC_Click;

            LoadThongKe();
            LoadDanhSachBaoCao(null);
        }

        private void LoadThongKe()
        {
            try
            {
                // Tổng số phòng
                object tongPhong = _db.ExecuteScalar("SELECT COUNT(*) FROM PHONG");
                lblTongSoPhong.Text = tongPhong?.ToString() ?? "0";

                // Tổng doanh thu
                string sqlDT = @"
                    SELECT ISNULL(SUM(TIENNUOC + TIENDIEN + TIENPHATSINH + TIENTHUENHA), 0)
                    FROM   HOADON
                    WHERE  TRANGTHAITT = @TrangThai";

                SqlParameter[] paramDT = {
                    new SqlParameter("@TrangThai", "Đã thanh toán")
                };
                object tongDT = _db.ExecuteScalar(sqlDT, paramDT);
                decimal doanhThu = tongDT != null ? Convert.ToDecimal(tongDT) : 0;
                lblTongDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";

                // Tổng lịch hẹn
                object tongLH = _db.ExecuteScalar("SELECT COUNT(*) FROM LICHHEN");
                lblTongLichHen.Text = tongLH?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachBaoCao(string loai)
        {
            try
            {
                string sql = @"
                    SELECT
                        b.MABC                                   AS [Mã BC],
                        nv.HONV + ' ' + nv.TENNV                 AS [Nhân viên],
                        b.LOAIBC                                 AS [Loại],
                        b.NOIDUNGBC                              AS [Nội dung],
                        FORMAT(b.THOIGIANBC, 'dd/MM/yyyy HH:mm') AS [Ngày lập]
                    FROM  BAOCAO   b
                    JOIN  NHANVIEN nv ON b.MANV = nv.MANV
                    WHERE (@Loai IS NULL OR b.LOAIBC = @Loai)
                    ORDER BY b.THOIGIANBC DESC";

                SqlParameter[] parms = {
                    new SqlParameter("@Loai",
                        string.IsNullOrEmpty(loai) ? (object)DBNull.Value : loai)
                };

                DataTable dt = _db.ExecuteQuery(sql, parms);

                dgvBaoCao.AutoGenerateColumns = false;
                dataGridViewTextBoxColumn1.DataPropertyName = "Mã BC";
                dataGridViewTextBoxColumn2.DataPropertyName = "Nhân viên";
                dataGridViewTextBoxColumn3.DataPropertyName = "Loại";
                dataGridViewTextBoxColumn4.DataPropertyName = "Nội dung";
                dataGridViewTextBoxColumn5.DataPropertyName = "Ngày lập";

                dgvBaoCao.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Nút "Xem thống kê"
        private void btnTKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
            string loai = cmbLoaiThongKe.SelectedItem?.ToString();
            LoadDanhSachBaoCao(loai);
        }


        // Nút "Lưu báo cáo"
        private void btnLuuBC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã NV phải là số nguyên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (cbLoaiBaoCao.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại thống kê.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoaiBaoCao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung báo cáo.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }

            try
            {
                string sql = @"
                    INSERT INTO BAOCAO (MANV, LOAIBC, NOIDUNGBC)
                    VALUES (@MaNV, @LoaiBC, @NoiDung)";

                SqlParameter[] parms = {
                    new SqlParameter("@MaNV",    maNV),
                    new SqlParameter("@LoaiBC",  cbLoaiBaoCao.SelectedItem.ToString()),
                    new SqlParameter("@NoiDung", txtNoiDung.Text.Trim())
                };

                _db.ExecuteNonQuery(sql, parms);

                MessageBox.Show("Lưu báo cáo thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaNV.Clear();
                txtNoiDung.Clear();
                cbLoaiBaoCao.SelectedIndex = -1;
                cmbLoaiThongKe.SelectedIndex = -1;

                LoadThongKe();
                LoadDanhSachBaoCao(null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Mã NV không tồn tại trong hệ thống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}