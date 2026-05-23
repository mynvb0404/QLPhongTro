namespace Hợp_Đồng
{
    partial class frmHopDong
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
            txtMaHD = new TextBox();
            label3 = new Label();
            txtMaKH = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dtNgayKy = new DateTimePicker();
            dtNgayKT = new DateTimePicker();
            label6 = new Label();
            cboTrangThai = new ComboBox();
            label7 = new Label();
            rtxtThongTin = new RichTextBox();
            label8 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnTim = new Button();
            btnXem = new Button();
            dgvHopDong = new DataGridView();
            MAHD = new DataGridViewTextBoxColumn();
            MAPHONG = new DataGridViewTextBoxColumn();
            MAKH = new DataGridViewTextBoxColumn();
            NGAYKY = new DataGridViewTextBoxColumn();
            NGAYKT = new DataGridViewTextBoxColumn();
            TRANGTHAI = new DataGridViewTextBoxColumn();
            THONGTINHD = new DataGridViewTextBoxColumn();
            txtTimKiem = new TextBox();
            txtMaPhong = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(328, 35);
            label1.Name = "label1";
            label1.Size = new Size(305, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Hợp Đồng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(75, 130);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 1;
            label2.Text = "Mã HD:";
            // 
            // txtMaHD
            // 
            txtMaHD.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaHD.Location = new Point(153, 124);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(182, 31);
            txtMaHD.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(75, 167);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 3;
            label3.Text = "Phòng:";
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaKH.Location = new Point(153, 198);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(182, 31);
            txtMaKH.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(75, 204);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 5;
            label4.Text = "Mã KH:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(75, 241);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 7;
            label5.Text = "Ngày ký:";
            // 
            // dtNgayKy
            // 
            dtNgayKy.Format = DateTimePickerFormat.Short;
            dtNgayKy.Location = new Point(153, 241);
            dtNgayKy.Name = "dtNgayKy";
            dtNgayKy.Size = new Size(182, 27);
            dtNgayKy.TabIndex = 10;
            // 
            // dtNgayKT
            // 
            dtNgayKT.Format = DateTimePickerFormat.Short;
            dtNgayKT.Location = new Point(153, 274);
            dtNgayKT.Name = "dtNgayKT";
            dtNgayKT.Size = new Size(182, 27);
            dtNgayKT.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 276);
            label6.Name = "label6";
            label6.Size = new Size(126, 25);
            label6.TabIndex = 11;
            label6.Text = "Ngày kết thúc:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Còn hiệu lực", "Hết hiệu lực" });
            cboTrangThai.Location = new Point(153, 307);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(182, 33);
            cboTrangThai.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(54, 315);
            label7.Name = "label7";
            label7.Size = new Size(93, 25);
            label7.TabIndex = 13;
            label7.Text = "Trạng thái:";
            // 
            // rtxtThongTin
            // 
            rtxtThongTin.Location = new Point(372, 159);
            rtxtThongTin.Name = "rtxtThongTin";
            rtxtThongTin.Size = new Size(553, 181);
            rtxtThongTin.TabIndex = 15;
            rtxtThongTin.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(372, 131);
            label8.Name = "label8";
            label8.Size = new Size(173, 25);
            label8.TabIndex = 16;
            label8.Text = "Thông tin hợp đồng";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(255, 224, 192);
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(153, 369);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 36);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 224, 192);
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(286, 369);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 36);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(255, 224, 192);
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(420, 369);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 36);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
         
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(255, 224, 192);
            btnTim.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTim.Location = new Point(698, 369);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 36);
            btnTim.TabIndex = 20;
            btnTim.Text = "Tìm Kiếm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(255, 224, 192);
            btnXem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXem.Location = new Point(556, 369);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(94, 36);
            btnXem.TabIndex = 21;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = false;
       
            // 
            // dgvHopDong
            // 
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Columns.AddRange(new DataGridViewColumn[] { MAHD, MAPHONG, MAKH, NGAYKY, NGAYKT, TRANGTHAI, THONGTINHD });
            dgvHopDong.Location = new Point(-1, 438);
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.RowHeadersWidth = 51;
            dgvHopDong.Size = new Size(998, 188);
            dgvHopDong.TabIndex = 22;
            dgvHopDong.CellClick += dgvHopDong_CellClick;
            // 
            // MAHD
            // 
            MAHD.HeaderText = "Mã HD";
            MAHD.MinimumWidth = 6;
            MAHD.Name = "MAHD";
            // 
            // MAPHONG
            // 
            MAPHONG.HeaderText = " Phòng";
            MAPHONG.MinimumWidth = 6;
            MAPHONG.Name = "MAPHONG";
            // 
            // MAKH
            // 
            MAKH.HeaderText = "Khách Hàng";
            MAKH.MinimumWidth = 6;
            MAKH.Name = "MAKH";
            // 
            // NGAYKY
            // 
            NGAYKY.HeaderText = "Ngày Ký HD";
            NGAYKY.MinimumWidth = 6;
            NGAYKY.Name = "NGAYKY";
            // 
            // NGAYKT
            // 
            NGAYKT.HeaderText = "Ngày Kết Thúc";
            NGAYKT.MinimumWidth = 6;
            NGAYKT.Name = "NGAYKT";
            // 
            // TRANGTHAI
            // 
            TRANGTHAI.HeaderText = "Trạng Thái";
            TRANGTHAI.MinimumWidth = 6;
            TRANGTHAI.Name = "TRANGTHAI";
            // 
            // THONGTINHD
            // 
            THONGTINHD.HeaderText = "Thông Tin";
            THONGTINHD.MinimumWidth = 6;
            THONGTINHD.Name = "THONGTINHD";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(803, 372);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(182, 31);
            txtTimKiem.TabIndex = 23;
            // 
            // txtMaPhong
            // 
            txtMaPhong.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaPhong.Location = new Point(153, 159);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new Size(182, 31);
            txtMaPhong.TabIndex = 24;
            // 
            // frmHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(997, 629);
            Controls.Add(txtMaPhong);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvHopDong);
            Controls.Add(btnXem);
            Controls.Add(btnTim);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label8);
            Controls.Add(rtxtThongTin);
            Controls.Add(cboTrangThai);
            Controls.Add(label7);
            Controls.Add(dtNgayKT);
            Controls.Add(label6);
            Controls.Add(dtNgayKy);
            Controls.Add(label5);
            Controls.Add(txtMaKH);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMaHD);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmHopDong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HopDong";
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMaHD;
        private Label label3;
        private TextBox txtMaKH;
        private Label label4;
        private Label label5;
        private DateTimePicker dtNgayKy;
        private DateTimePicker dtNgayKT;
        private Label label6;
        private ComboBox cboTrangThai;
        private Label label7;
        private RichTextBox rtxtThongTin;
        private Label label8;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTim;
        private Button btnXem;
        private DataGridView dgvHopDong;
        private TextBox txtTimKiem;
        private DataGridViewTextBoxColumn MAHD;
        private DataGridViewTextBoxColumn MAPHONG;
        private DataGridViewTextBoxColumn MAKH;
        private DataGridViewTextBoxColumn NGAYKY;
        private DataGridViewTextBoxColumn NGAYKT;
        private DataGridViewTextBoxColumn TRANGTHAI;
        private DataGridViewTextBoxColumn THONGTINHD;
        private TextBox txtMaPhong;
    }
}
