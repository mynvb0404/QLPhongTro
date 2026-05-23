namespace Khách_Hàng
{
    partial class frmKhachHang
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtMaKH = new TextBox();
            txtHoKH = new TextBox();
            label3 = new Label();
            txtTenKH = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtSDT = new TextBox();
            label6 = new Label();
            txtCCCD = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            dtNgayThue = new DateTimePicker();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnTim = new Button();
            btnXem = new Button();
            dgvKhachHang = new DataGridView();
            MAKH = new DataGridViewTextBoxColumn();
            HOKH = new DataGridViewTextBoxColumn();
            TENKH = new DataGridViewTextBoxColumn();
            CCCC = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            NGAYBATDAUTHUE = new DataGridViewTextBoxColumn();
            TRANGTHAITHUE = new DataGridViewTextBoxColumn();
            MAPHONG = new DataGridViewTextBoxColumn();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            //SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(301, 48);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(508, 71);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Khách Thuê";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 198);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 40);
            label2.TabIndex = 1;
            label2.Text = "MaKH:";
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaKH.Location = new Point(203, 189);
            txtMaKH.Margin = new Padding(5, 5, 5, 5);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(266, 46);
            txtMaKH.TabIndex = 2;
            // 
            // txtHoKH
            // 
            txtHoKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoKH.Location = new Point(203, 248);
            txtHoKH.Margin = new Padding(5, 5, 5, 5);
            txtHoKH.Name = "txtHoKH";
            txtHoKH.Size = new Size(266, 46);
            txtHoKH.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(89, 258);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 40);
            label3.TabIndex = 3;
            label3.Text = "HoKH:";
            // 
            // txtTenKH
            // 
            txtTenKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenKH.Location = new Point(203, 307);
            txtTenKH.Margin = new Padding(5, 5, 5, 5);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(266, 46);
            txtTenKH.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(89, 317);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 40);
            label4.TabIndex = 5;
            label4.Text = "TenKH:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(86, 378);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(0, 40);
            label5.TabIndex = 7;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(203, 442);
            txtSDT.Margin = new Padding(5, 5, 5, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(266, 46);
            txtSDT.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(114, 445);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(72, 40);
            label6.TabIndex = 8;
            label6.Text = "SDT:";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCCCD.Location = new Point(203, 373);
            txtCCCD.Margin = new Padding(5, 5, 5, 5);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(266, 46);
            txtCCCD.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(89, 382);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(95, 40);
            label7.TabIndex = 10;
            label7.Text = "CCCD:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(504, 382);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(156, 40);
            label8.TabIndex = 12;
            label8.Text = "Ngày thuê:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(509, 454);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(154, 40);
            label9.TabIndex = 13;
            label9.Text = "Trạng Thái:";
            // 
            // dtNgayThue
            // 
            dtNgayThue.Format = DateTimePickerFormat.Short;
            dtNgayThue.Location = new Point(671, 382);
            dtNgayThue.Margin = new Padding(5, 5, 5, 5);
            dtNgayThue.Name = "dtNgayThue";
            dtNgayThue.Size = new Size(266, 39);
            dtNgayThue.TabIndex = 14;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Đang thuê", "Đã trả phòng" });
            cboTrangThai.Location = new Point(673, 448);
            cboTrangThai.Margin = new Padding(5, 5, 5, 5);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(266, 40);
            cboTrangThai.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(255, 224, 192);
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(578, 179);
            btnThem.Margin = new Padding(5, 5, 5, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(153, 78);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 224, 192);
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(786, 179);
            btnSua.Margin = new Padding(5, 5, 5, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(153, 78);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(255, 224, 192);
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(1016, 179);
            btnXoa.Margin = new Padding(5, 5, 5, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(153, 78);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(255, 224, 192);
            btnTim.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTim.Location = new Point(1016, 298);
            btnTim.Margin = new Padding(5, 5, 5, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(153, 78);
            btnTim.TabIndex = 19;
            btnTim.Text = "Tìm Kiếm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(255, 224, 192);
            btnXem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXem.Location = new Point(1219, 179);
            btnXem.Margin = new Padding(5, 5, 5, 5);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(153, 78);
            btnXem.TabIndex = 20;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { MAKH, HOKH, TENKH, CCCC, SDT, NGAYBATDAUTHUE, TRANGTHAITHUE, MAPHONG });
            dgvKhachHang.Location = new Point(2, 570);
            dgvKhachHang.Margin = new Padding(5, 5, 5, 5);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1700, 370);
            dgvKhachHang.TabIndex = 21;
            // 
            // MAKH
            // 
            MAKH.HeaderText = "Mã Khách Hàng";
            MAKH.MinimumWidth = 6;
            MAKH.Name = "MAKH";
            MAKH.Width = 125;
            // 
            // HOKH
            // 
            HOKH.HeaderText = "Họ Khách Hàng";
            HOKH.MinimumWidth = 6;
            HOKH.Name = "HOKH";
            HOKH.Width = 125;
            // 
            // TENKH
            // 
            TENKH.HeaderText = "Tên Khách";
            TENKH.MinimumWidth = 6;
            TENKH.Name = "TENKH";
            TENKH.Width = 125;
            // 
            // CCCC
            // 
            CCCC.HeaderText = "CCCD";
            CCCC.MinimumWidth = 6;
            CCCC.Name = "CCCC";
            CCCC.Width = 125;
            // 
            // SDT
            // 
            SDT.HeaderText = "SDT";
            SDT.MinimumWidth = 6;
            SDT.Name = "SDT";
            SDT.Width = 125;
            // 
            // NGAYBATDAUTHUE
            // 
            NGAYBATDAUTHUE.HeaderText = "Ngày Thuê";
            NGAYBATDAUTHUE.MinimumWidth = 6;
            NGAYBATDAUTHUE.Name = "NGAYBATDAUTHUE";
            NGAYBATDAUTHUE.Width = 125;
            // 
            // TRANGTHAITHUE
            // 
            TRANGTHAITHUE.HeaderText = "Trạng Thái Thuê";
            TRANGTHAITHUE.MinimumWidth = 6;
            TRANGTHAITHUE.Name = "TRANGTHAITHUE";
            TRANGTHAITHUE.Width = 125;
            // 
            // MAPHONG
            // 
            MAPHONG.HeaderText = "Phòng";
            MAPHONG.MinimumWidth = 6;
            MAPHONG.Name = "MAPHONG";
            MAPHONG.Width = 125;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(1178, 312);
            txtTimKiem.Margin = new Padding(5, 5, 5, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(266, 46);
            txtTimKiem.TabIndex = 22;
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1706, 950);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvKhachHang);
            Controls.Add(btnXem);
            Controls.Add(btnTim);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboTrangThai);
            Controls.Add(dtNgayThue);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtCCCD);
            Controls.Add(label7);
            Controls.Add(txtSDT);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtTenKH);
            Controls.Add(label4);
            Controls.Add(txtHoKH);
            Controls.Add(label3);
            Controls.Add(txtMaKH);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách Hàng";
            Load += frmKhachHang_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMaKH;
        private TextBox txtHoKH;
        private Label label3;
        private TextBox txtTenKH;
        private Label label4;
        private Label label5;
        private TextBox txtSDT;
        private Label label6;
        private TextBox txtCCCD;
        private Label label7;
        private Label label8;
        private Label label9;
        private DateTimePicker dtNgayThue;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTim;
        private Button btnXem;
        private DataGridView dgvKhachHang;
        private TextBox txtTimKiem;
        private DataGridViewTextBoxColumn MAKH;
        private DataGridViewTextBoxColumn HOKH;
        private DataGridViewTextBoxColumn TENKH;
        private DataGridViewTextBoxColumn CCCC;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn NGAYBATDAUTHUE;
        private DataGridViewTextBoxColumn TRANGTHAITHUE;
        private DataGridViewTextBoxColumn MAPHONG;
    }
}
