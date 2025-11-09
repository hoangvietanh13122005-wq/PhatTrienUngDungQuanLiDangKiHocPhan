namespace UngdungQuanliDangkiHocphan
{
    partial class UC_QLHocKi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnThemHocKi = new System.Windows.Forms.Button();
            this.dgvHocKi = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.colMaHocKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnamhoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHocKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocKi)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Học kỳ";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(22, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(351, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Quản lý thông tin học kỳ và thời gian đăng ký tín chỉ";
            // 
            // btnThemHocKi
            // 
            this.btnThemHocKi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemHocKi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.btnThemHocKi.FlatAppearance.BorderSize = 0;
            this.btnThemHocKi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHocKi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemHocKi.ForeColor = System.Drawing.Color.White;
            this.btnThemHocKi.Location = new System.Drawing.Point(1236, 25);
            this.btnThemHocKi.Name = "btnThemHocKi";
            this.btnThemHocKi.Size = new System.Drawing.Size(180, 35);
            this.btnThemHocKi.TabIndex = 2;
            this.btnThemHocKi.Text = "+ Thêm học kỳ mới";
            this.btnThemHocKi.UseVisualStyleBackColor = false;
            this.btnThemHocKi.Click += new System.EventHandler(this.btnThemHocKi_Click);
            // 
            // dgvHocKi
            // 
            this.dgvHocKi.AllowUserToAddRows = false;
            this.dgvHocKi.AllowUserToDeleteRows = false;
            this.dgvHocKi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocKi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHocKi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocKi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHocKi.ColumnHeadersHeight = 40;
            this.dgvHocKi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHocKi,
            this.colnamhoc,
            this.colTenHocKi,
            this.colNgayBatDau,
            this.colNgayKetThuc,
            this.colTrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHocKi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHocKi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocKi.EnableHeadersVisualStyles = false;
            this.dgvHocKi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvHocKi.Location = new System.Drawing.Point(0, 80);
            this.dgvHocKi.Name = "dgvHocKi";
            this.dgvHocKi.RowHeadersVisible = false;
            this.dgvHocKi.RowHeadersWidth = 51;
            this.dgvHocKi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocKi.Size = new System.Drawing.Size(1428, 439);
            this.dgvHocKi.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSubtitle);
            this.panelTop.Controls.Add(this.btnThemHocKi);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1428, 80);
            this.panelTop.TabIndex = 1;
            // 
            // colMaHocKi
            // 
            this.colMaHocKi.HeaderText = "Mã học kì";
            this.colMaHocKi.MinimumWidth = 6;
            this.colMaHocKi.Name = "colMaHocKi";
            // 
            // colnamhoc
            // 
            this.colnamhoc.HeaderText = "Năm học";
            this.colnamhoc.MinimumWidth = 6;
            this.colnamhoc.Name = "colnamhoc";
            // 
            // colTenHocKi
            // 
            this.colTenHocKi.HeaderText = "Tên học kỳ";
            this.colTenHocKi.MinimumWidth = 6;
            this.colTenHocKi.Name = "colTenHocKi";
            // 
            // colNgayBatDau
            // 
            this.colNgayBatDau.HeaderText = "Ngày bắt đầu";
            this.colNgayBatDau.MinimumWidth = 6;
            this.colNgayBatDau.Name = "colNgayBatDau";
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.HeaderText = "Ngày kết thúc";
            this.colNgayKetThuc.MinimumWidth = 6;
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            // 
            // UC_QLHocKi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.dgvHocKi);
            this.Controls.Add(this.panelTop);
            this.Name = "UC_QLHocKi";
            this.Size = new System.Drawing.Size(1428, 519);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocKi)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnThemHocKi;
        private System.Windows.Forms.DataGridView dgvHocKi;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHocKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnamhoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHocKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
