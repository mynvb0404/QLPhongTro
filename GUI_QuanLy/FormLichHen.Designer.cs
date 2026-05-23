namespace Lịch_Hẹn
{
    partial class frmLichHen
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
            txtTenKhach = new TextBox();
            label2 = new Label();
            txtMaNV = new TextBox();
            label3 = new Label();
            txtMaKH = new TextBox();
            txtNoiDung = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cboPhong = new ComboBox();
            cboTrangThai = new ComboBox();
            dtpThoiGianHen = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnXem = new Button();
            dgvLichHen = new DataGridView();
            TENKH = new DataGridViewTextBoxColumn();
            MAPHONG = new DataGridViewTextBoxColumn();
            MALH = new DataGridViewTextBoxColumn();
            THOIGIANHEN = new DataGridViewTextBoxColumn();
            TRANGTHAIHEN = new DataGridViewTextBoxColumn();
            NOIDUNGHEN = new DataGridViewTextBoxColumn();
            label6 = new Label();
            txtMaLH = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvLichHen).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(520, 90);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(447, 61);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Lịch Hẹn";
            // 
            // txtTenKhach
            // 
            txtTenKhach.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenKhach.Location = new Point(216, 238);
            txtTenKhach.Margin = new Padding(5, 5, 5, 5);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(344, 46);
            txtTenKhach.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(57, 243);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(145, 40);
            label2.TabIndex = 2;
            label2.Text = "Tên Khách";
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaNV.Location = new Point(216, 298);
            txtMaNV.Margin = new Padding(5, 5, 5, 5);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(344, 46);
            txtMaNV.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(60, 298);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 40);
            label3.TabIndex = 4;
            label3.Text = "MaNV";
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaKH.Location = new Point(216, 357);
            txtMaKH.Margin = new Padding(5, 5, 5, 5);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(344, 46);
            txtMaKH.TabIndex = 5;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNoiDung.Location = new Point(216, 416);
            txtNoiDung.Margin = new Padding(5, 5, 5, 5);
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(344, 41);
            txtNoiDung.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(60, 357);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 40);
            label4.TabIndex = 7;
            label4.Text = "MaKH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 421);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(140, 40);
            label5.TabIndex = 8;
            label5.Text = "Nội Dung";
            // 
            // cboPhong
            // 
            cboPhong.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPhong.FormattingEnabled = true;
            cboPhong.Items.AddRange(new object[] { "#1", "#2", "#3" });
            cboPhong.Location = new Point(611, 285);
            cboPhong.Margin = new Padding(5, 5, 5, 5);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(329, 48);
            cboPhong.TabIndex = 9;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Đã đặt", "Đã hủy", "Hoàn thành" });
            cboTrangThai.Location = new Point(609, 347);
            cboTrangThai.Margin = new Padding(5, 5, 5, 5);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(331, 48);
            cboTrangThai.TabIndex = 10;
            // 
            // dtpThoiGianHen
            // 
            dtpThoiGianHen.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiGianHen.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpThoiGianHen.Format = DateTimePickerFormat.Custom;
            dtpThoiGianHen.Location = new Point(609, 410);
            dtpThoiGianHen.Margin = new Padding(5, 5, 5, 5);
            dtpThoiGianHen.Name = "dtpThoiGianHen";
            dtpThoiGianHen.Size = new Size(331, 46);
            dtpThoiGianHen.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(255, 224, 192);
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(1056, 152);
            btnThem.Margin = new Padding(5, 5, 5, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(223, 93);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm lịch hẹn";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 224, 192);
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(1318, 152);
            btnSua.Margin = new Padding(5, 5, 5, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(223, 93);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa lịch hẹn";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(255, 224, 192);
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(1056, 285);
            btnXoa.Margin = new Padding(5, 5, 5, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(223, 93);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Hủy lịch hẹn";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(255, 224, 192);
            btnXem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXem.Location = new Point(1318, 285);
            btnXem.Margin = new Padding(5, 5, 5, 5);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(223, 93);
            btnXem.TabIndex = 15;
            btnXem.Text = "Xem lịch hẹn";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // dgvLichHen
            // 
            dgvLichHen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichHen.BackgroundColor = SystemColors.ActiveBorder;
            dgvLichHen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichHen.Columns.AddRange(new DataGridViewColumn[] { TENKH, MAPHONG, MALH, THOIGIANHEN, TRANGTHAIHEN, NOIDUNGHEN });
            dgvLichHen.Location = new Point(20, 491);
            dgvLichHen.Margin = new Padding(5, 5, 5, 5);
            dgvLichHen.Name = "dgvLichHen";
            dgvLichHen.RowHeadersWidth = 51;
            dgvLichHen.Size = new Size(1584, 365);
            dgvLichHen.TabIndex = 16;
            dgvLichHen.CellContentClick += dgvLichHen_CellContentClick;
            // 
            // TENKH
            // 
            TENKH.HeaderText = "Khách Hàng";
            TENKH.MinimumWidth = 6;
            TENKH.Name = "TENKH";
            // 
            // MAPHONG
            // 
            MAPHONG.HeaderText = "Phòng";
            MAPHONG.MinimumWidth = 6;
            MAPHONG.Name = "MAPHONG";
            // 
            // MALH
            // 
            MALH.HeaderText = "Mã Lịch Hẹn";
            MALH.MinimumWidth = 6;
            MALH.Name = "MALH";
            // 
            // THOIGIANHEN
            // 
            THOIGIANHEN.HeaderText = "Thời Gian Hẹn";
            THOIGIANHEN.MinimumWidth = 6;
            THOIGIANHEN.Name = "THOIGIANHEN";
            // 
            // TRANGTHAIHEN
            // 
            TRANGTHAIHEN.HeaderText = "Trạng Thái Hẹn";
            TRANGTHAIHEN.MinimumWidth = 6;
            TRANGTHAIHEN.Name = "TRANGTHAIHEN";
            // 
            // NOIDUNGHEN
            // 
            NOIDUNGHEN.HeaderText = "Nội Dung Hẹn";
            NOIDUNGHEN.MinimumWidth = 6;
            NOIDUNGHEN.Name = "NOIDUNGHEN";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(62, 179);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(93, 40);
            label6.TabIndex = 17;
            label6.Text = "MaLH";
            // 
            // txtMaLH
            // 
            txtMaLH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaLH.Location = new Point(216, 179);
            txtMaLH.Margin = new Padding(5, 5, 5, 5);
            txtMaLH.Name = "txtMaLH";
            txtMaLH.Size = new Size(344, 46);
            txtMaLH.TabIndex = 18;
            // 
            // frmLichHen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1623, 859);
            Controls.Add(txtMaLH);
            Controls.Add(label6);
            Controls.Add(dgvLichHen);
            Controls.Add(btnXem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dtpThoiGianHen);
            Controls.Add(cboTrangThai);
            Controls.Add(cboPhong);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtNoiDung);
            Controls.Add(txtMaKH);
            Controls.Add(label3);
            Controls.Add(txtMaNV);
            Controls.Add(label2);
            Controls.Add(txtTenKhach);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmLichHen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Lịch Hẹn";
            Load += frmLichHen_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvLichHen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenKhach;
        private Label label2;
        private TextBox txtMaNV;
        private Label label3;
        private TextBox txtMaKH;
        private TextBox txtNoiDung;
        private Label label4;
        private Label label5;
        private ComboBox cboPhong;
        private ComboBox cboTrangThai;
        private DateTimePicker dtpThoiGianHen;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnXem;
        private DataGridView dgvLichHen;
        private Label label6;
        private TextBox txtMaLH;
        private DataGridViewTextBoxColumn TENKH;
        private DataGridViewTextBoxColumn MAPHONG;
        private DataGridViewTextBoxColumn MALH;
        private DataGridViewTextBoxColumn THOIGIANHEN;
        private DataGridViewTextBoxColumn TRANGTHAIHEN;
        private DataGridViewTextBoxColumn NOIDUNGHEN;
    }
}
