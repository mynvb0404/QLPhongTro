namespace GUI_QuanLy
{
    partial class frmManageAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageAcc));
            dgvEmployee = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtSearch = new TextBox();
            txtName = new TextBox();
            txtUserName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            cboRole = new ComboBox();
            txtFirstName = new TextBox();
            txtPassword = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btEdit = new Button();
            btReset = new Button();
            btAdd = new Button();
            btDelete = new Button();
            lbTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(0, 260);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(881, 285);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellClick += dgvEmployee_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lbTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(881, 260);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(881, 214);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txtSearch, 1, 3);
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(txtUserName, 0, 2);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 1);
            tableLayoutPanel1.Controls.Add(txtPhoneNumber, 1, 0);
            tableLayoutPanel1.Controls.Add(cboRole, 0, 3);
            tableLayoutPanel1.Controls.Add(txtFirstName, 0, 0);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(582, 214);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtSearch.ForeColor = SystemColors.WindowFrame;
            txtSearch.Location = new Point(294, 162);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Thông tin tìm kiếm";
            txtSearch.Size = new Size(285, 34);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtName.ForeColor = SystemColors.WindowFrame;
            txtName.Location = new Point(3, 56);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Tên";
            txtName.Size = new Size(285, 34);
            txtName.TabIndex = 2;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtUserName.ForeColor = SystemColors.WindowFrame;
            txtUserName.Location = new Point(3, 109);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Tên đăng nhập";
            txtUserName.Size = new Size(285, 34);
            txtUserName.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtEmail.ForeColor = SystemColors.WindowFrame;
            txtEmail.Location = new Point(294, 56);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(285, 34);
            txtEmail.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPhoneNumber.ForeColor = SystemColors.WindowFrame;
            txtPhoneNumber.Location = new Point(294, 3);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Số điện thoại";
            txtPhoneNumber.Size = new Size(285, 34);
            txtPhoneNumber.TabIndex = 4;
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Nhân viên", "Quản lý", "Khách hàng" });
            cboRole.Location = new Point(3, 162);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(285, 36);
            cboRole.TabIndex = 3;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtFirstName.ForeColor = SystemColors.WindowFrame;
            txtFirstName.Location = new Point(3, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Họ";
            txtFirstName.Size = new Size(285, 34);
            txtFirstName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPassword.ForeColor = SystemColors.WindowFrame;
            txtPassword.Location = new Point(294, 109);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(285, 34);
            txtPassword.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btEdit, 0, 1);
            tableLayoutPanel2.Controls.Add(btReset, 1, 1);
            tableLayoutPanel2.Controls.Add(btAdd, 0, 0);
            tableLayoutPanel2.Controls.Add(btDelete, 1, 0);
            tableLayoutPanel2.Location = new Point(618, 56);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(237, 87);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // btEdit
            // 
            btEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btEdit.Location = new Point(3, 46);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(112, 38);
            btEdit.TabIndex = 8;
            btEdit.Text = "Sửa";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btReset
            // 
            btReset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btReset.Location = new Point(121, 46);
            btReset.Name = "btReset";
            btReset.Size = new Size(113, 38);
            btReset.TabIndex = 9;
            btReset.Text = "Reset";
            btReset.UseVisualStyleBackColor = true;
            btReset.Click += btReset_Click;
            // 
            // btAdd
            // 
            btAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btAdd.Location = new Point(3, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(112, 37);
            btAdd.TabIndex = 6;
            btAdd.Text = "Thêm";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btDelete
            // 
            btDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btDelete.Location = new Point(121, 3);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(113, 37);
            btDelete.TabIndex = 7;
            btDelete.Text = "Xóa";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // lbTitle
            // 
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbTitle.ForeColor = SystemColors.ButtonHighlight;
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(881, 46);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Quản lý tài khoản và thông tin";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmManageAcc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 545);
            Controls.Add(panel1);
            Controls.Add(dgvEmployee);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmManageAcc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thông tin và tài khoản";
            Load += frmManageAcc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmployee;
        private Panel panel1;
        private Label lbTitle;
        private Button btReset;
        private Button btEdit;
        private Button btDelete;
        private Button btAdd;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtSearch;
        private TextBox txtPassword;
        private TextBox txtName;
        private TextBox txtUserName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private ComboBox cboRole;
        private TextBox txtFirstName;
        private Panel panel2;
    }
}