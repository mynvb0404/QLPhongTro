namespace GUI_QuanLy
{
    partial class frmRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoom));
            dgvRoom = new DataGridView();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btAdd = new Button();
            btEdit = new Button();
            btDelete = new Button();
            btSearch = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            cboType = new ComboBox();
            cboStatus = new ComboBox();
            cboArea = new ComboBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtFuniture = new TextBox();
            txtS = new TextBox();
            txtPopulation = new TextBox();
            lbTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRoom
            // 
            dgvRoom.AllowUserToAddRows = false;
            dgvRoom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Location = new Point(0, 474);
            dgvRoom.Margin = new Padding(5, 5, 5, 5);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.RowHeadersWidth = 51;
            dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoom.Size = new Size(1428, 467);
            dgvRoom.TabIndex = 0;
            dgvRoom.CellClick += dgvRoom_CellClick;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(5, 5, 5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1428, 941);
            panel2.TabIndex = 15;
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
            tableLayoutPanel2.Location = new Point(949, 205);
            tableLayoutPanel2.Margin = new Padding(5, 5, 5, 5);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.Size = new Size(396, 131);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // btAdd
            // 
            btAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btAdd.Location = new Point(5, 5);
            btAdd.Margin = new Padding(5, 5, 5, 5);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(188, 53);
            btAdd.TabIndex = 9;
            btAdd.Text = "Thêm";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btEdit
            // 
            btEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btEdit.Location = new Point(5, 70);
            btEdit.Margin = new Padding(5, 5, 5, 5);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(188, 53);
            btEdit.TabIndex = 11;
            btEdit.Text = "Sửa";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btDelete.Location = new Point(203, 5);
            btDelete.Margin = new Padding(5, 5, 5, 5);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(188, 53);
            btDelete.TabIndex = 10;
            btDelete.Text = "Xóa";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btSearch
            // 
            btSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btSearch.Location = new Point(203, 70);
            btSearch.Margin = new Padding(5, 5, 5, 5);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(188, 53);
            btSearch.TabIndex = 12;
            btSearch.Text = "Tìm kiếm";
            btSearch.UseVisualStyleBackColor = true;
            btSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cboType, 1, 2);
            tableLayoutPanel1.Controls.Add(cboStatus, 1, 3);
            tableLayoutPanel1.Controls.Add(cboArea, 1, 1);
            tableLayoutPanel1.Controls.Add(txtName, 0, 0);
            tableLayoutPanel1.Controls.Add(txtPrice, 0, 1);
            tableLayoutPanel1.Controls.Add(txtFuniture, 0, 4);
            tableLayoutPanel1.Controls.Add(txtS, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPopulation, 0, 3);
            tableLayoutPanel1.Location = new Point(0, 96);
            tableLayoutPanel1.Margin = new Padding(5, 5, 5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(861, 368);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // cboType
            // 
            cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(435, 151);
            cboType.Margin = new Padding(5, 5, 5, 5);
            cboType.Name = "cboType";
            cboType.Size = new Size(421, 53);
            cboType.TabIndex = 8;
            // 
            // cboStatus
            // 
            cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(435, 224);
            cboStatus.Margin = new Padding(5, 5, 5, 5);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(421, 53);
            cboStatus.TabIndex = 7;
            // 
            // cboArea
            // 
            cboArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboArea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cboArea.FormattingEnabled = true;
            cboArea.Location = new Point(435, 78);
            cboArea.Margin = new Padding(5, 5, 5, 5);
            cboArea.Name = "cboArea";
            cboArea.Size = new Size(421, 53);
            cboArea.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtName.ForeColor = SystemColors.WindowFrame;
            txtName.Location = new Point(5, 5);
            txtName.Margin = new Padding(5, 5, 5, 5);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Tên phòng";
            txtName.Size = new Size(420, 50);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPrice.ForeColor = SystemColors.WindowFrame;
            txtPrice.Location = new Point(5, 78);
            txtPrice.Margin = new Padding(5, 5, 5, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Giá phòng";
            txtPrice.Size = new Size(420, 50);
            txtPrice.TabIndex = 2;
            // 
            // txtFuniture
            // 
            txtFuniture.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFuniture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtFuniture.ForeColor = SystemColors.WindowFrame;
            txtFuniture.Location = new Point(5, 297);
            txtFuniture.Margin = new Padding(5, 5, 5, 5);
            txtFuniture.Name = "txtFuniture";
            txtFuniture.PlaceholderText = "Nội thất";
            txtFuniture.Size = new Size(420, 50);
            txtFuniture.TabIndex = 5;
            // 
            // txtS
            // 
            txtS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtS.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtS.ForeColor = SystemColors.WindowFrame;
            txtS.Location = new Point(5, 151);
            txtS.Margin = new Padding(5, 5, 5, 5);
            txtS.Name = "txtS";
            txtS.PlaceholderText = "Diện tích (m2)";
            txtS.Size = new Size(420, 50);
            txtS.TabIndex = 3;
            // 
            // txtPopulation
            // 
            txtPopulation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPopulation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPopulation.ForeColor = SystemColors.WindowFrame;
            txtPopulation.Location = new Point(5, 224);
            txtPopulation.Margin = new Padding(5, 5, 5, 5);
            txtPopulation.Name = "txtPopulation";
            txtPopulation.PlaceholderText = "Số người";
            txtPopulation.Size = new Size(420, 50);
            txtPopulation.TabIndex = 4;
            // 
            // lbTitle
            // 
            lbTitle.BackColor = SystemColors.ActiveCaption;
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lbTitle.ForeColor = SystemColors.ButtonFace;
            lbTitle.Location = new Point(0, 0);
            lbTitle.Margin = new Padding(5, 0, 5, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(1428, 74);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Quản lý phòng";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmRoom
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1428, 941);
            Controls.Add(dgvRoom);
            Controls.Add(lbTitle);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            Name = "frmRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng";
            Load += frmRoom_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRoom;
        private TextBox txtName;
        private TextBox txtPrice;
        private ComboBox cboArea;
        private TextBox txtFuniture;
        private TextBox txtPopulation;
        private TextBox txtS;
        private ComboBox cboType;
        private ComboBox cboStatus;
        private Button btSearch;
        private Button btEdit;
        private Button btDelete;
        private Button btAdd;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lbTitle;
    }
}