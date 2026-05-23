namespace GUI_QuanLy
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panel1 = new Panel();
            lbPass = new Label();
            lbUserName = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            lbWarning = new Label();
            btLogin = new Button();
            cboRole = new ComboBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lbTitle = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lbPass);
            panel1.Controls.Add(lbUserName);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btLogin);
            panel1.Controls.Add(cboRole);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lbTitle);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(288, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 562);
            panel1.TabIndex = 0;
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.Location = new Point(41, 239);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(70, 20);
            lbPass.TabIndex = 13;
            lbPass.Text = "Mật khẩu";
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Location = new Point(40, 169);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(50, 20);
            lbUserName.TabIndex = 12;
            lbUserName.Text = "label2";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.Image = GUI_QuanLy.Properties.Resources._lock;
            pictureBox2.Location = new Point(434, 262);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(434, 192);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lbWarning);
            panel2.Location = new Point(0, 375);
            panel2.Name = "panel2";
            panel2.Size = new Size(501, 187);
            panel2.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(24, 42);
            label1.Name = "label1";
            label1.Size = new Size(456, 41);
            label1.TabIndex = 9;
            label1.Text = "Liên hệ với quản lý chi nhánh của bạn để yêu cầu cấp lại mật khẩu";
            // 
            // lbWarning
            // 
            lbWarning.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbWarning.AutoSize = true;
            lbWarning.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbWarning.ForeColor = SystemColors.ButtonHighlight;
            lbWarning.Location = new Point(85, 11);
            lbWarning.Name = "lbWarning";
            lbWarning.Size = new Size(306, 31);
            lbWarning.TabIndex = 8;
            lbWarning.Text = "Trường hợp quên mật khẩu\r\n";
            // 
            // btLogin
            // 
            btLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btLogin.BackColor = SystemColors.Highlight;
            btLogin.FlatAppearance.BorderSize = 0;
            btLogin.FlatStyle = FlatStyle.Flat;
            btLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btLogin.ForeColor = SystemColors.ButtonFace;
            btLogin.Location = new Point(41, 313);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(420, 42);
            btLogin.TabIndex = 3;
            btLogin.Text = "Đăng nhập";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += btLogin_Click;
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Nhân viên", "Khách thuê" });
            cboRole.Location = new Point(40, 116);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(420, 36);
            cboRole.TabIndex = 0;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPassword.ForeColor = SystemColors.GrayText;
            txtPassword.Location = new Point(40, 262);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            txtPassword.Size = new Size(420, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtUsername.ForeColor = SystemColors.GrayText;
            txtUsername.Location = new Point(41, 192);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(420, 27);
            txtUsername.TabIndex = 1;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbTitle.ForeColor = Color.White;
            lbTitle.Location = new Point(3, 33);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(492, 62);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Đăng nhập tài khoản";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1041, 564);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbTitle;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private ComboBox cboRole;
        private Button btLogin;
        private Panel panel2;
        private Label lbWarning;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lbPass;
        private Label lbUserName;
    }
}
