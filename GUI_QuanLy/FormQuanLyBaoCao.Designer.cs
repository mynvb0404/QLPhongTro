namespace GUI_QuanLy
{
    partial class FormQuanLyBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbBC = new GroupBox();
            btnTKe = new Button();
            cmbLoaiThongKe = new ComboBox();
            lbTKe = new Label();
            pnlPhong = new Panel();
            lblTongSoPhong = new Label();
            label1 = new Label();
            pnlDThu = new Panel();
            lblTongDoanhThu = new Label();
            label2 = new Label();
            pnlLichHen = new Panel();
            lblTongLichHen = new Label();
            label3 = new Label();
            gbLapBC = new GroupBox();
            txtMaNV = new TextBox();
            btnLuuBC = new Button();
            txtNoiDung = new TextBox();
            label6 = new Label();
            label5 = new Label();
            cbLoaiBaoCao = new ComboBox();
            label4 = new Label();
            dgvBaoCao = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            gbBC.SuspendLayout();
            pnlPhong.SuspendLayout();
            pnlDThu.SuspendLayout();
            pnlLichHen.SuspendLayout();
            gbLapBC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // gbBC
            // 
            gbBC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbBC.Controls.Add(btnTKe);
            gbBC.Controls.Add(cmbLoaiThongKe);
            gbBC.Controls.Add(lbTKe);
            gbBC.Location = new Point(7, 8);
            gbBC.Margin = new Padding(2, 2, 2, 2);
            gbBC.Name = "gbBC";
            gbBC.Padding = new Padding(2, 2, 2, 2);
            gbBC.Size = new Size(793, 27);
            gbBC.TabIndex = 2;
            gbBC.TabStop = false;
            gbBC.Text = "Thống kê";
            // 
            // btnTKe
            // 
            btnTKe.Location = new Point(489, 32);
            btnTKe.Margin = new Padding(2, 2, 2, 2);
            btnTKe.Name = "btnTKe";
            btnTKe.Size = new Size(154, 51);
            btnTKe.TabIndex = 8;
            btnTKe.Text = "Xem thống kê";
            btnTKe.UseVisualStyleBackColor = true;
            // 
            // cmbLoaiThongKe
            // 
            cmbLoaiThongKe.FormattingEnabled = true;
            cmbLoaiThongKe.Location = new Point(142, 32);
            cmbLoaiThongKe.Margin = new Padding(2, 2, 2, 2);
            cmbLoaiThongKe.Name = "cmbLoaiThongKe";
            cmbLoaiThongKe.Size = new Size(218, 28);
            cmbLoaiThongKe.TabIndex = 7;
            // 
            // lbTKe
            // 
            lbTKe.AutoSize = true;
            lbTKe.Location = new Point(13, 32);
            lbTKe.Margin = new Padding(2, 0, 2, 0);
            lbTKe.Name = "lbTKe";
            lbTKe.Size = new Size(102, 20);
            lbTKe.TabIndex = 0;
            lbTKe.Text = "Loại thống kê:";
            // 
            // pnlPhong
            // 
            pnlPhong.Controls.Add(lblTongSoPhong);
            pnlPhong.Controls.Add(label1);
            pnlPhong.Location = new Point(7, 128);
            pnlPhong.Margin = new Padding(2, 2, 2, 2);
            pnlPhong.Name = "pnlPhong";
            pnlPhong.Size = new Size(259, 167);
            pnlPhong.TabIndex = 3;
            // 
            // lblTongSoPhong
            // 
            lblTongSoPhong.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongSoPhong.Location = new Point(50, 87);
            lblTongSoPhong.Margin = new Padding(2, 0, 2, 0);
            lblTongSoPhong.Name = "lblTongSoPhong";
            lblTongSoPhong.Size = new Size(163, 52);
            lblTongSoPhong.TabIndex = 1;
            lblTongSoPhong.Text = "20";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(21, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(218, 70);
            label1.TabIndex = 0;
            label1.Text = "Tổng số phòng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDThu
            // 
            pnlDThu.Controls.Add(lblTongDoanhThu);
            pnlDThu.Controls.Add(label2);
            pnlDThu.Location = new Point(288, 128);
            pnlDThu.Margin = new Padding(2, 2, 2, 2);
            pnlDThu.Name = "pnlDThu";
            pnlDThu.Size = new Size(246, 167);
            pnlDThu.TabIndex = 4;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongDoanhThu.Location = new Point(14, 90);
            lblTongDoanhThu.Margin = new Padding(2, 0, 2, 0);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(221, 52);
            lblTongDoanhThu.TabIndex = 1;
            lblTongDoanhThu.Text = "label4";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(14, 8);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(221, 92);
            label2.TabIndex = 0;
            label2.Text = "Tổng doanh thu";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLichHen
            // 
            pnlLichHen.Controls.Add(lblTongLichHen);
            pnlLichHen.Controls.Add(label3);
            pnlLichHen.Location = new Point(554, 128);
            pnlLichHen.Margin = new Padding(2, 2, 2, 2);
            pnlLichHen.Name = "pnlLichHen";
            pnlLichHen.Size = new Size(246, 167);
            pnlLichHen.TabIndex = 5;
            // 
            // lblTongLichHen
            // 
            lblTongLichHen.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongLichHen.Location = new Point(41, 87);
            lblTongLichHen.Margin = new Padding(2, 0, 2, 0);
            lblTongLichHen.Name = "lblTongLichHen";
            lblTongLichHen.Size = new Size(163, 52);
            lblTongLichHen.TabIndex = 1;
            lblTongLichHen.Text = "label4";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(14, 8);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(218, 70);
            label3.TabIndex = 0;
            label3.Text = "Tổng lịch hẹn";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbLapBC
            // 
            gbLapBC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLapBC.Controls.Add(txtMaNV);
            gbLapBC.Controls.Add(btnLuuBC);
            gbLapBC.Controls.Add(txtNoiDung);
            gbLapBC.Controls.Add(label6);
            gbLapBC.Controls.Add(label5);
            gbLapBC.Controls.Add(cbLoaiBaoCao);
            gbLapBC.Controls.Add(label4);
            gbLapBC.Location = new Point(7, 306);
            gbLapBC.Margin = new Padding(2, 2, 2, 2);
            gbLapBC.Name = "gbLapBC";
            gbLapBC.Padding = new Padding(2, 2, 2, 2);
            gbLapBC.Size = new Size(793, 89);
            gbLapBC.TabIndex = 6;
            gbLapBC.TabStop = false;
            gbLapBC.Text = "Báo cáo ";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(90, 34);
            txtMaNV.Margin = new Padding(2, 2, 2, 2);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(360, 27);
            txtMaNV.TabIndex = 13;
            // 
            // btnLuuBC
            // 
            btnLuuBC.Location = new Point(59, 106);
            btnLuuBC.Margin = new Padding(2, 2, 2, 2);
            btnLuuBC.Name = "btnLuuBC";
            btnLuuBC.Size = new Size(154, 51);
            btnLuuBC.TabIndex = 12;
            btnLuuBC.Text = "Lưu báo cáo";
            btnLuuBC.UseVisualStyleBackColor = true;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(143, 69);
            txtNoiDung.Margin = new Padding(2, 2, 2, 2);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(360, 27);
            txtNoiDung.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 69);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 10;
            label6.Text = "Nội dung báo cáo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 36);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 9;
            label5.Text = "Mã NV";
            // 
            // cbLoaiBaoCao
            // 
            cbLoaiBaoCao.FormattingEnabled = true;
            cbLoaiBaoCao.Location = new Point(521, 68);
            cbLoaiBaoCao.Margin = new Padding(2, 2, 2, 2);
            cbLoaiBaoCao.Name = "cbLoaiBaoCao";
            cbLoaiBaoCao.Size = new Size(218, 28);
            cbLoaiBaoCao.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(521, 31);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 0;
            label4.Text = "Loại thống kê :";
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvBaoCao.Location = new Point(7, 480);
            dgvBaoCao.Margin = new Padding(2, 2, 2, 2);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersWidth = 82;
            dgvBaoCao.Size = new Size(793, 232);
            dgvBaoCao.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã BC";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nhân viên";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Loại";
            dataGridViewTextBoxColumn3.MinimumWidth = 10;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Nội dung";
            dataGridViewTextBoxColumn4.MinimumWidth = 10;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Ngày lập";
            dataGridViewTextBoxColumn5.MinimumWidth = 10;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // FormQuanLyBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(817, 578);
            Controls.Add(dgvBaoCao);
            Controls.Add(gbLapBC);
            Controls.Add(pnlLichHen);
            Controls.Add(pnlDThu);
            Controls.Add(pnlPhong);
            Controls.Add(gbBC);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormQuanLyBaoCao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý báo cáo";
            Load += FormQuanLyBaoCao_Load;
            gbBC.ResumeLayout(false);
            gbBC.PerformLayout();
            pnlPhong.ResumeLayout(false);
            pnlDThu.ResumeLayout(false);
            pnlLichHen.ResumeLayout(false);
            gbLapBC.ResumeLayout(false);
            gbLapBC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBC;
        private Button btnTKe;
        private ComboBox cmbLoaiThongKe;
        private Label lbTKe;
        private Panel pnlPhong;
        private Label lblTongSoPhong;
        private Label label1;
        private Panel pnlDThu;
        private Label label2;
        private Panel pnlLichHen;
        private Label label3;
        private Label lblTongDoanhThu;
        private Label lblTongLichHen;
        private GroupBox gbLapBC;
        private ComboBox cbLoaiBaoCao;
        private Label label4;
        private Button btnLuuBC;
        private TextBox txtNoiDung;
        private Label label6;
        private Label label5;
        private DataGridView dgvBaoCao;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private TextBox txtMaNV;
    }
}