namespace GUI_QuanLy
{
    partial class frmArea
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
            tableLayoutPanel2 = new TableLayoutPanel();
            btAdd = new Button();
            btEdit = new Button();
            btDelete = new Button();
            btSearch = new Button();
            dgvArea = new DataGridView();
            panel2 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtEmp = new TextBox();
            txtAddress = new TextBox();
            txtMa = new TextBox();
            txtName = new TextBox();
            lbTitle = new Label();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArea).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btAdd, 0, 0);
            tableLayoutPanel2.Controls.Add(btEdit, 0, 1);
            tableLayoutPanel2.Controls.Add(btDelete, 1, 0);
            tableLayoutPanel2.Controls.Add(btSearch, 1, 1);
            tableLayoutPanel2.Location = new Point(1245, 128);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(244, 82);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // btAdd
            // 
            btAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btAdd.Location = new Point(3, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(116, 33);
            btAdd.TabIndex = 9;
            btAdd.Text = "Thêm";
            btAdd.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            btEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btEdit.Location = new Point(3, 44);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(116, 33);
            btEdit.TabIndex = 11;
            btEdit.Text = "Sửa";
            btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btDelete.Location = new Point(125, 3);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(116, 33);
            btDelete.TabIndex = 10;
            btDelete.Text = "Xóa";
            btDelete.UseVisualStyleBackColor = true;
            // 
            // btSearch
            // 
            btSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btSearch.Location = new Point(125, 44);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(116, 33);
            btSearch.TabIndex = 12;
            btSearch.Text = "Tìm kiếm";
            btSearch.UseVisualStyleBackColor = true;
            // 
            // dgvArea
            // 
            dgvArea.AllowUserToAddRows = false;
            dgvArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArea.Location = new Point(0, 255);
            dgvArea.Name = "dgvArea";
            dgvArea.RowHeadersWidth = 51;
            dgvArea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArea.Size = new Size(861, 287);
            dgvArea.TabIndex = 16;
            dgvArea.CellClick += dgvArea_CellClick;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(tableLayoutPanel3);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(dgvArea);
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 542);
            panel2.TabIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(button1, 0, 0);
            tableLayoutPanel3.Controls.Add(button2, 0, 1);
            tableLayoutPanel3.Controls.Add(button3, 1, 0);
            tableLayoutPanel3.Controls.Add(button4, 1, 1);
            tableLayoutPanel3.Location = new Point(614, 85);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(244, 82);
            tableLayoutPanel3.TabIndex = 18;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(116, 33);
            button1.TabIndex = 9;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btAdd_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button2.Location = new Point(3, 44);
            button2.Name = "button2";
            button2.Size = new Size(116, 33);
            button2.TabIndex = 11;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btEdit_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(125, 3);
            button3.Name = "button3";
            button3.Size = new Size(116, 33);
            button3.TabIndex = 10;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btDelete_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button4.Location = new Point(125, 44);
            button4.Name = "button4";
            button4.Size = new Size(116, 33);
            button4.TabIndex = 12;
            button4.Text = "Tìm kiếm";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btSearch_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txtEmp, 1, 1);
            tableLayoutPanel1.Controls.Add(txtAddress, 0, 1);
            tableLayoutPanel1.Controls.Add(txtMa, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 1, 0);
            tableLayoutPanel1.Location = new Point(3, 68);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(472, 125);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // txtEmp
            // 
            txtEmp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtEmp.Location = new Point(239, 65);
            txtEmp.Name = "txtEmp";
            txtEmp.PlaceholderText = "Mã nhân viên quản lý";
            txtEmp.Size = new Size(230, 34);
            txtEmp.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtAddress.Location = new Point(3, 65);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Địa Chỉ";
            txtAddress.Size = new Size(230, 34);
            txtAddress.TabIndex = 2;
            // 
            // txtMa
            // 
            txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtMa.Location = new Point(3, 3);
            txtMa.Name = "txtMa";
            txtMa.PlaceholderText = "Mã khu vực";
            txtMa.Size = new Size(230, 34);
            txtMa.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtName.Location = new Point(239, 3);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Tên khu vực";
            txtName.Size = new Size(230, 34);
            txtName.TabIndex = 1;
            // 
            // lbTitle
            // 
            lbTitle.BackColor = SystemColors.ActiveCaption;
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbTitle.ForeColor = SystemColors.ButtonFace;
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(861, 46);
            lbTitle.TabIndex = 17;
            lbTitle.Text = "Quản lý khu vực";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmArea
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 588);
            Controls.Add(panel2);
            Controls.Add(lbTitle);
            Name = "frmArea";
            Text = "frmArea";
            Load += frmArea_Load;
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArea).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private Button btAdd;
        private Button btEdit;
        private Button btDelete;
        private Button btSearch;
        private DataGridView dgvArea;
        private Panel panel2;
        private Label lbTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtEmp;
        private TextBox txtAddress;
        private TextBox txtMa;
        private TextBox txtName;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}