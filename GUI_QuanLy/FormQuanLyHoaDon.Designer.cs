namespace GUI_QuanLy
{
    partial class FormQuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbHD = new GroupBox();
            btnCapNhatTrangThai = new Button();
            btnXoa = new Button();
            txtTienPhatSinh = new TextBox();
            btnCapNhatHoaDon = new Button();
            txtTienNuoc = new TextBox();
            btnTaoHoaDon = new Button();
            cboTrangThai = new ComboBox();
            txtTienDien = new TextBox();
            txtTongTien = new TextBox();
            cboNgayL = new ComboBox();
            cboMaHopDong = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lbTrangThai = new Label();
            lbNL = new Label();
            lbMaHD = new Label();
            dgvHoaDon = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            txtTienThueNha = new TextBox();
            gbHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // gbHD
            // 
            gbHD.Controls.Add(txtTienThueNha);
            gbHD.Controls.Add(label2);
            gbHD.Controls.Add(btnCapNhatTrangThai);
            gbHD.Controls.Add(btnXoa);
            gbHD.Controls.Add(txtTienPhatSinh);
            gbHD.Controls.Add(btnCapNhatHoaDon);
            gbHD.Controls.Add(txtTienNuoc);
            gbHD.Controls.Add(btnTaoHoaDon);
            gbHD.Controls.Add(cboTrangThai);
            gbHD.Controls.Add(txtTienDien);
            gbHD.Controls.Add(txtTongTien);
            gbHD.Controls.Add(cboNgayL);
            gbHD.Controls.Add(cboMaHopDong);
            gbHD.Controls.Add(label7);
            gbHD.Controls.Add(label6);
            gbHD.Controls.Add(label5);
            gbHD.Controls.Add(label4);
            gbHD.Controls.Add(lbTrangThai);
            gbHD.Controls.Add(lbNL);
            gbHD.Controls.Add(lbMaHD);
            gbHD.Location = new Point(12, 12);
            gbHD.Name = "gbHD";
            gbHD.Size = new Size(1633, 418);
            gbHD.TabIndex = 1;
            gbHD.TabStop = false;
            gbHD.Text = "Thông tin hóa đơn";
            // 
            // btnCapNhatTrangThai
            // 
            btnCapNhatTrangThai.Location = new Point(1026, 301);
            btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            btnCapNhatTrangThai.Size = new Size(204, 81);
            btnCapNhatTrangThai.TabIndex = 18;
            btnCapNhatTrangThai.Text = "Cập nhật trạng thái";
            btnCapNhatTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(705, 301);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(204, 81);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // txtTienPhatSinh
            // 
            txtTienPhatSinh.Location = new Point(1215, 130);
            txtTienPhatSinh.Name = "txtTienPhatSinh";
            txtTienPhatSinh.Size = new Size(385, 39);
            txtTienPhatSinh.TabIndex = 17;
            // 
            // btnCapNhatHoaDon
            // 
            btnCapNhatHoaDon.Location = new Point(398, 301);
            btnCapNhatHoaDon.Name = "btnCapNhatHoaDon";
            btnCapNhatHoaDon.Size = new Size(204, 81);
            btnCapNhatHoaDon.TabIndex = 9;
            btnCapNhatHoaDon.Text = "Cập nhật hóa đơn";
            btnCapNhatHoaDon.UseVisualStyleBackColor = true;
            // 
            // txtTienNuoc
            // 
            txtTienNuoc.Location = new Point(159, 123);
            txtTienNuoc.Name = "txtTienNuoc";
            txtTienNuoc.Size = new Size(323, 39);
            txtTienNuoc.TabIndex = 16;
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.Location = new Point(96, 301);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(204, 81);
            btnTaoHoaDon.TabIndex = 8;
            btnTaoHoaDon.Text = "Tạo hóa đơn";
            btnTaoHoaDon.UseVisualStyleBackColor = true;
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(1215, 51);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(310, 40);
            cboTrangThai.TabIndex = 15;
            // 
            // txtTienDien
            // 
            txtTienDien.Location = new Point(624, 123);
            txtTienDien.Name = "txtTienDien";
            txtTienDien.Size = new Size(383, 39);
            txtTienDien.TabIndex = 14;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(1091, 212);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(443, 39);
            txtTongTien.TabIndex = 10;
            // 
            // cboNgayL
            // 
            cboNgayL.FormattingEnabled = true;
            cboNgayL.Location = new Point(624, 54);
            cboNgayL.Name = "cboNgayL";
            cboNgayL.Size = new Size(310, 40);
            cboNgayL.TabIndex = 8;
            // 
            // cboMaHopDong
            // 
            cboMaHopDong.FormattingEnabled = true;
            cboMaHopDong.Location = new Point(192, 51);
            cboMaHopDong.Name = "cboMaHopDong";
            cboMaHopDong.Size = new Size(287, 40);
            cboMaHopDong.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(890, 215);
            label7.Name = "label7";
            label7.Size = new Size(117, 32);
            label7.TabIndex = 6;
            label7.Text = "Tổng tiền";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(488, 123);
            label6.Name = "label6";
            label6.Size = new Size(114, 32);
            label6.TabIndex = 5;
            label6.Text = "Tiền điện";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1013, 133);
            label5.Name = "label5";
            label5.Size = new Size(171, 32);
            label5.TabIndex = 4;
            label5.Text = "Tiền phát sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 126);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 3;
            label4.Text = "Tiền nước:";
            // 
            // lbTrangThai
            // 
            lbTrangThai.AutoSize = true;
            lbTrangThai.Location = new Point(1054, 52);
            lbTrangThai.Name = "lbTrangThai";
            lbTrangThai.Size = new Size(130, 32);
            lbTrangThai.TabIndex = 2;
            lbTrangThai.Text = "Trạng Thái:";
            // 
            // lbNL
            // 
            lbNL.AutoSize = true;
            lbNL.Location = new Point(493, 57);
            lbNL.Name = "lbNL";
            lbNL.Size = new Size(109, 32);
            lbNL.TabIndex = 1;
            lbNL.Text = "Ngày lập";
            // 
            // lbMaHD
            // 
            lbMaHD.AutoSize = true;
            lbMaHD.Location = new Point(21, 52);
            lbMaHD.Name = "lbMaHD";
            lbMaHD.Size = new Size(165, 32);
            lbMaHD.TabIndex = 0;
            lbMaHD.Text = "Mã hợp đồng:";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(12, 582);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 82;
            dgvHoaDon.Size = new Size(1633, 409);
            dgvHoaDon.TabIndex = 6;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(78, 457);
            label1.Name = "label1";
            label1.Size = new Size(347, 89);
            label1.TabIndex = 7;
            label1.Text = "DANH SÁCH HÓA ĐƠN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 212);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 19;
            label2.Text = "Tiền thuê nhà:";
            // 
            // txtTienThueNha
            // 
            txtTienThueNha.Location = new Point(211, 208);
            txtTienThueNha.Name = "txtTienThueNha";
            txtTienThueNha.Size = new Size(391, 39);
            txtTienThueNha.TabIndex = 20;
            // 
            // FormQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1657, 1003);
            Controls.Add(label1);
            Controls.Add(dgvHoaDon);
            Controls.Add(gbHD);
            Name = "FormQuanLyHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hóa đơn";
            Load += FormQuanLyHoaDoncs_Load;
            gbHD.ResumeLayout(false);
            gbHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbHD;
        private TextBox txtTienDien;
        private ComboBox cboTrangThai;      
        private TextBox txtTongTien;

        private ComboBox cboNgayL;
        private ComboBox cboMaHopDong;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lbTrangThai;
        private Label lbNL;
        private Label lbMaHD;

        private TextBox txtTienNuoc;
        private TextBox txtTienPhatSinh;
        private DataGridView dgvHoaDon;
        private Label label1;
        private Button btnTaoHoaDon;
        private Button btnCapNhatHoaDon;
        private Button btnXoa;
        private Button btnCapNhatTrangThai;
        private TextBox txtTienThueNha;
        private Label label2;
    }
}