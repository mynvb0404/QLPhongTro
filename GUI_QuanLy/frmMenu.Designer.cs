namespace GUI_QuanLy
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            pnSideBar = new Panel();
            panel3 = new Panel();
            lbEmail = new Label();
            lbFullName = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btLogout = new Button();
            label5 = new Label();
            btReport = new Button();
            btBill = new Button();
            btContract = new Button();
            bPost = new Button();
            btResident = new Button();
            btAppointment = new Button();
            btRoom = new Button();
            btArea = new Button();
            btAcc = new Button();
            label2 = new Label();
            label1 = new Label();
            pnMain = new Panel();
            pnSideBar.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnSideBar
            // 
            pnSideBar.Controls.Add(panel3);
            pnSideBar.Controls.Add(label3);
            pnSideBar.Controls.Add(panel1);
            pnSideBar.Controls.Add(btReport);
            pnSideBar.Controls.Add(btBill);
            pnSideBar.Controls.Add(btContract);
            pnSideBar.Controls.Add(bPost);
            pnSideBar.Controls.Add(btResident);
            pnSideBar.Controls.Add(btAppointment);
            pnSideBar.Controls.Add(btRoom);
            pnSideBar.Controls.Add(btArea);
            pnSideBar.Controls.Add(btAcc);
            pnSideBar.Controls.Add(label2);
            pnSideBar.Controls.Add(label1);
            pnSideBar.Dock = DockStyle.Left;
            pnSideBar.Location = new Point(0, 0);
            pnSideBar.Margin = new Padding(5);
            pnSideBar.Name = "pnSideBar";
            pnSideBar.Size = new Size(408, 877);
            pnSideBar.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lbEmail);
            panel3.Controls.Add(lbFullName);
            panel3.Location = new Point(0, 699);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(408, 112);
            panel3.TabIndex = 2;
            // 
            // lbEmail
            // 
            lbEmail.ForeColor = SystemColors.ControlDark;
            lbEmail.Location = new Point(20, 54);
            lbEmail.Margin = new Padding(5, 0, 5, 0);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(372, 48);
            lbEmail.TabIndex = 1;
            lbEmail.Text = "Email";
            // 
            // lbFullName
            // 
            lbFullName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lbFullName.Location = new Point(20, 6);
            lbFullName.Margin = new Padding(5, 0, 5, 0);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(384, 48);
            lbFullName.TabIndex = 0;
            lbFullName.Text = "Tên người dùng";
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(0, 699);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(406, 3);
            label3.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(0, 706);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 184);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btLogout);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 115);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(406, 69);
            panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.logout;
            pictureBox1.Location = new Point(104, 10);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btLogout
            // 
            btLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btLogout.FlatAppearance.BorderSize = 0;
            btLogout.FlatStyle = FlatStyle.Flat;
            btLogout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btLogout.ForeColor = Color.Red;
            btLogout.Location = new Point(153, 8);
            btLogout.Margin = new Padding(5);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(140, 50);
            btLogout.TabIndex = 4;
            btLogout.Text = "Đăng xuất";
            btLogout.TextAlign = ContentAlignment.MiddleRight;
            btLogout.UseVisualStyleBackColor = true;
            btLogout.Click += btLogout_Click;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(0, 123);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(406, 3);
            label5.TabIndex = 2;
            // 
            // btReport
            // 
            btReport.FlatAppearance.BorderSize = 0;
            btReport.FlatStyle = FlatStyle.Flat;
            btReport.Location = new Point(20, 619);
            btReport.Margin = new Padding(5);
            btReport.Name = "btReport";
            btReport.Size = new Size(377, 50);
            btReport.TabIndex = 8;
            btReport.Text = "Báo cáo thống kê";
            btReport.UseVisualStyleBackColor = true;
            // 
            // btBill
            // 
            btBill.FlatAppearance.BorderSize = 0;
            btBill.FlatStyle = FlatStyle.Flat;
            btBill.Location = new Point(20, 560);
            btBill.Margin = new Padding(5);
            btBill.Name = "btBill";
            btBill.Size = new Size(377, 50);
            btBill.TabIndex = 7;
            btBill.Text = "Hóa đơn và thanh toán";
            btBill.UseVisualStyleBackColor = true;
            // 
            // btContract
            // 
            btContract.FlatAppearance.BorderSize = 0;
            btContract.FlatStyle = FlatStyle.Flat;
            btContract.Location = new Point(20, 501);
            btContract.Margin = new Padding(5);
            btContract.Name = "btContract";
            btContract.Size = new Size(377, 50);
            btContract.TabIndex = 6;
            btContract.Text = "Quản lý hợp đồng";
            btContract.UseVisualStyleBackColor = true;
            btContract.Click += btContract_Click;
            // 
            // bPost
            // 
            bPost.FlatAppearance.BorderSize = 0;
            bPost.FlatStyle = FlatStyle.Flat;
            bPost.Location = new Point(20, 442);
            bPost.Margin = new Padding(5);
            bPost.Name = "bPost";
            bPost.Size = new Size(377, 50);
            bPost.TabIndex = 5;
            bPost.Text = "Tin ở ghép";
            bPost.UseVisualStyleBackColor = true;
            // 
            // btResident
            // 
            btResident.FlatAppearance.BorderSize = 0;
            btResident.FlatStyle = FlatStyle.Flat;
            btResident.Location = new Point(20, 382);
            btResident.Margin = new Padding(5);
            btResident.Name = "btResident";
            btResident.Size = new Size(377, 50);
            btResident.TabIndex = 4;
            btResident.Text = "Quản lý khách thuê";
            btResident.UseVisualStyleBackColor = true;
            btResident.Click += btResident_Click;
            // 
            // btAppointment
            // 
            btAppointment.FlatAppearance.BorderSize = 0;
            btAppointment.FlatStyle = FlatStyle.Flat;
            btAppointment.Location = new Point(20, 323);
            btAppointment.Margin = new Padding(5);
            btAppointment.Name = "btAppointment";
            btAppointment.Size = new Size(377, 50);
            btAppointment.TabIndex = 3;
            btAppointment.Text = "Quản lý lịch hẹn";
            btAppointment.UseVisualStyleBackColor = true;
            btAppointment.Click += btAppointment_Click;
            // 
            // btRoom
            // 
            btRoom.FlatAppearance.BorderSize = 0;
            btRoom.FlatStyle = FlatStyle.Flat;
            btRoom.Location = new Point(20, 264);
            btRoom.Margin = new Padding(5);
            btRoom.Name = "btRoom";
            btRoom.Size = new Size(377, 50);
            btRoom.TabIndex = 2;
            btRoom.Text = "Quản lý phòng";
            btRoom.UseVisualStyleBackColor = true;
            btRoom.Click += btRoom_Click;
            // 
            // btArea
            // 
            btArea.FlatAppearance.BorderSize = 0;
            btArea.FlatStyle = FlatStyle.Flat;
            btArea.Location = new Point(20, 205);
            btArea.Margin = new Padding(5);
            btArea.Name = "btArea";
            btArea.Size = new Size(377, 50);
            btArea.TabIndex = 1;
            btArea.Text = "Quản lý khu vực";
            btArea.UseVisualStyleBackColor = true;
            btArea.Click += btArea_Click;
            // 
            // btAcc
            // 
            btAcc.FlatAppearance.BorderSize = 0;
            btAcc.FlatStyle = FlatStyle.Flat;
            btAcc.ImageAlign = ContentAlignment.MiddleLeft;
            btAcc.Location = new Point(20, 146);
            btAcc.Margin = new Padding(5);
            btAcc.Name = "btAcc";
            btAcc.Size = new Size(377, 50);
            btAcc.TabIndex = 0;
            btAcc.Text = "Quản lý tài khoản";
            btAcc.UseVisualStyleBackColor = true;
            btAcc.Click += btAcc_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(5, 94);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(406, 3);
            label2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(406, 94);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG QUẢN LÝ PHÒNG TRỌ";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnMain
            // 
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(408, 0);
            pnMain.Margin = new Padding(5);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1545, 877);
            pnMain.TabIndex = 1;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1953, 877);
            Controls.Add(pnMain);
            Controls.Add(pnSideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "frmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            Load += frmMenu_Load;
            pnSideBar.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnSideBar;
        private Label label1;
        private Panel pnMain;
        private Button btBill;
        private Button btContract;
        private Button bPost;
        private Button btResident;
        private Button btAppointment;
        private Button btRoom;
        private Button btArea;
        private Button btAcc;
        private Label label2;
        private Button btReport;
        private Label label3;
        private Panel panel1;
        private Button btLogout;
        private Label label5;
        private Label lbEmail;
        private Label lbFullName;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel3;
    }
}