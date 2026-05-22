namespace GUI_QuanLy
{
    partial class FormQuanLyOGhep
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
            tabControl1 = new TabControl();
            Tab = new TabPage();
            groupBox1 = new GroupBox();
            txtGiaChia = new TextBox();
            cboTrangThai = new ComboBox();
            cboGioiTinh = new ComboBox();
            txtMoTa = new TextBox();
            numericUpDown1 = new NumericUpDown();
            cboMaKH = new ComboBox();
            cboMaPhong = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbMaKH = new Label();
            lbMaPhong = new Label();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            btnThemTin = new Button();
            btnSuaTin = new Button();
            btnXoaTin = new Button();
            btnCNTT = new Button();
            dgvDSTin = new DataGridView();
            ColumMt = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            tabControl1.SuspendLayout();
            Tab.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDSTin).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Tab);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(40, 35);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1508, 380);
            tabControl1.TabIndex = 0;
            // 
            // Tab
            // 
            Tab.Controls.Add(groupBox1);
            Tab.Location = new Point(8, 46);
            Tab.Name = "Tab";
            Tab.Padding = new Padding(3);
            Tab.Size = new Size(1492, 326);
            Tab.TabIndex = 0;
            Tab.Text = "Đăng và quản lý tin ở ghép";
            Tab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGiaChia);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(cboGioiTinh);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(cboMaKH);
            groupBox1.Controls.Add(cboMaPhong);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lbMaKH);
            groupBox1.Controls.Add(lbMaPhong);
            groupBox1.Location = new Point(26, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1423, 279);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đăng và quản lý tin ở ghép";
            // 
            // txtGiaChia
            // 
            txtGiaChia.Location = new Point(545, 123);
            txtGiaChia.Name = "txtGiaChia";
            txtGiaChia.Size = new Size(380, 39);
            txtGiaChia.TabIndex = 14;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(1093, 115);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(310, 40);
            cboTrangThai.TabIndex = 13;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(157, 126);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(257, 40);
            cboGioiTinh.TabIndex = 12;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(124, 222);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(1170, 39);
            txtMoTa.TabIndex = 10;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1172, 43);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(112, 39);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // cboMaKH
            // 
            cboMaKH.FormattingEnabled = true;
            cboMaKH.Location = new Point(615, 45);
            cboMaKH.Name = "cboMaKH";
            cboMaKH.Size = new Size(310, 40);
            cboMaKH.TabIndex = 8;
            // 
            // cboMaPhong
            // 
            cboMaPhong.FormattingEnabled = true;
            cboMaPhong.Location = new Point(157, 51);
            cboMaPhong.Name = "cboMaPhong";
            cboMaPhong.Size = new Size(262, 40);
            cboMaPhong.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 212);
            label7.Name = "label7";
            label7.Size = new Size(77, 32);
            label7.TabIndex = 6;
            label7.Text = "Mô tả";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(436, 126);
            label6.Name = "label6";
            label6.Size = new Size(103, 32);
            label6.TabIndex = 5;
            label6.Text = "Giá chia:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(951, 115);
            label5.Name = "label5";
            label5.Size = new Size(120, 32);
            label5.TabIndex = 4;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 126);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 3;
            label4.Text = "Giới tính:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(951, 52);
            label3.Name = "label3";
            label3.Size = new Size(159, 32);
            label3.TabIndex = 2;
            label3.Text = "Số người cần:";
            // 
            // lbMaKH
            // 
            lbMaKH.AutoSize = true;
            lbMaKH.Location = new Point(425, 57);
            lbMaKH.Name = "lbMaKH";
            lbMaKH.Size = new Size(184, 32);
            lbMaKH.TabIndex = 1;
            lbMaKH.Text = "Mã khách hàng:";
            // 
            // lbMaPhong
            // 
            lbMaPhong.AutoSize = true;
            lbMaPhong.Location = new Point(21, 52);
            lbMaPhong.Name = "lbMaPhong";
            lbMaPhong.Size = new Size(130, 32);
            lbMaPhong.TabIndex = 0;
            lbMaPhong.Text = "Mã phòng:";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1492, 326);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tìm kiếm";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1492, 326);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Gửi yêu cầu ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1492, 326);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Xử lý yêu cầu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(8, 46);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1492, 326);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "Danh sách ở ghép";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(8, 46);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1492, 326);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "Đánh giá";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnThemTin
            // 
            btnThemTin.Location = new Point(55, 457);
            btnThemTin.Name = "btnThemTin";
            btnThemTin.Size = new Size(150, 46);
            btnThemTin.TabIndex = 1;
            btnThemTin.Text = "Thêm tin";
            btnThemTin.UseVisualStyleBackColor = true;
            btnThemTin.Click += btnThemTin_Click;
            // 
            // btnSuaTin
            // 
            btnSuaTin.Location = new Point(247, 457);
            btnSuaTin.Name = "btnSuaTin";
            btnSuaTin.Size = new Size(150, 46);
            btnSuaTin.TabIndex = 2;
            btnSuaTin.Text = "Sửa tin";
            btnSuaTin.UseVisualStyleBackColor = true;
            // 
            // btnXoaTin
            // 
            btnXoaTin.Location = new Point(438, 457);
            btnXoaTin.Name = "btnXoaTin";
            btnXoaTin.Size = new Size(150, 46);
            btnXoaTin.TabIndex = 3;
            btnXoaTin.Text = "Xóa tin";
            btnXoaTin.UseVisualStyleBackColor = true;
            // 
            // btnCNTT
            // 
            btnCNTT.Location = new Point(632, 457);
            btnCNTT.Name = "btnCNTT";
            btnCNTT.Size = new Size(150, 46);
            btnCNTT.TabIndex = 4;
            btnCNTT.Text = "Cập nhật TT";
            btnCNTT.UseVisualStyleBackColor = true;
            // 
            // dgvDSTin
            // 
            dgvDSTin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSTin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSTin.Columns.AddRange(new DataGridViewColumn[] { ColumMt, Column1, Column2, Column3, Column4, Column5, Column6 });
            dgvDSTin.Location = new Point(11, 87);
            dgvDSTin.Name = "dgvDSTin";
            dgvDSTin.ReadOnly = true;
            dgvDSTin.RowHeadersWidth = 82;
            dgvDSTin.Size = new Size(1483, 235);
            dgvDSTin.TabIndex = 5;
            dgvDSTin.CellClick += dgvDSTin_CellClick;
            // 
            // ColumMt
            // 
            ColumMt.HeaderText = "Mã tin";
            ColumMt.MinimumWidth = 10;
            ColumMt.Name = "ColumMt";
            ColumMt.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Phòng ";
            Column1.MinimumWidth = 10;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Khách hàng";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Số người";
            Column3.MinimumWidth = 10;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Giới tính";
            Column4.MinimumWidth = 10;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Giá chia";
            Column5.MinimumWidth = 10;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Trạng thái";
            Column6.MinimumWidth = 10;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDSTin);
            panel1.Location = new Point(29, 436);
            panel1.Name = "panel1";
            panel1.Size = new Size(1519, 355);
            panel1.TabIndex = 6;
            // 
            // FormQuanLyOGhep
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1560, 803);
            Controls.Add(btnCNTT);
            Controls.Add(btnXoaTin);
            Controls.Add(btnSuaTin);
            Controls.Add(btnThemTin);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "FormQuanLyOGhep";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý ở ghép";
            Load += FormQuanLyOGhep_Load;
            tabControl1.ResumeLayout(false);
            Tab.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDSTin).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Tab;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lbMaKH;
        private Label lbMaPhong;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private NumericUpDown numericUpDown1;
        private ComboBox cboMaKH;
        private ComboBox cboMaPhong;
        private TextBox txtMoTa;
        private Button btnThemTin;
        private Button btnSuaTin;
        private Button btnXoaTin;
        private Button btnCNTT;
        private DataGridView dgvDSTin;
        private Panel panel1;
        private DataGridViewTextBoxColumn ColumMt;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private TextBox txtGiaChia;
        private ComboBox cboTrangThai;
        private ComboBox cboGioiTinh;
    }
}