using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    partial class UC_QLSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cboTimTheo;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTimTheo;
        private System.Windows.Forms.Label lblTuKhoa;

        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTimTheo = new System.Windows.Forms.Label();
            this.cboTimTheo = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelTop.Controls.Add(this.lblTimTheo);
            this.panelTop.Controls.Add(this.cboTimTheo);
            this.panelTop.Controls.Add(this.lblTuKhoa);
            this.panelTop.Controls.Add(this.txtTuKhoa);
            this.panelTop.Controls.Add(this.btnTimKiem);
            this.panelTop.Controls.Add(this.btnLamMoi);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 50);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1113, 70);
            this.panelTop.TabIndex = 1;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lblTimTheo
            // 
            this.lblTimTheo.Location = new System.Drawing.Point(21, 28);
            this.lblTimTheo.Name = "lblTimTheo";
            this.lblTimTheo.Size = new System.Drawing.Size(125, 23);
            this.lblTimTheo.TabIndex = 0;
            this.lblTimTheo.Text = "Tìm theo";
            this.lblTimTheo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTimTheo
            // 
            this.cboTimTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTheo.Items.AddRange(new object[] {
            "Mã sinh viên",
            "Tên sinh viên",
            "Mã học phần",
            "Tên học phần"});
            this.cboTimTheo.Location = new System.Drawing.Point(152, 27);
            this.cboTimTheo.Name = "cboTimTheo";
            this.cboTimTheo.Size = new System.Drawing.Size(150, 24);
            this.cboTimTheo.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Location = new System.Drawing.Point(308, 27);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(83, 23);
            this.lblTuKhoa.TabIndex = 2;
            this.lblTuKhoa.Text = "Từ khóa";
            this.lblTuKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(397, 28);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(200, 22);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(603, 23);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.BtnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(699, 23);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click);
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.AllowUserToAddRows = false;
            this.dgvDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangKy.BackgroundColor = System.Drawing.Color.White;
            this.dgvDangKy.ColumnHeadersHeight = 29;
            this.dgvDangKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSV,
            this.colTenSV,
            this.colMaHP,
            this.colTenHP,
            this.colNgayDangKy,
            this.colTrangThai});
            this.dgvDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDangKy.Location = new System.Drawing.Point(0, 120);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.ReadOnly = true;
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKy.Size = new System.Drawing.Size(1113, 446);
            this.dgvDangKy.TabIndex = 2;
            // 
            // colMaSV
            // 
            this.colMaSV.HeaderText = "Mã sinh viên";
            this.colMaSV.MinimumWidth = 6;
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.ReadOnly = true;
            // 
            // colTenSV
            // 
            this.colTenSV.HeaderText = "Tên sinh viên";
            this.colTenSV.MinimumWidth = 6;
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.ReadOnly = true;
            // 
            // colMaHP
            // 
            this.colMaHP.HeaderText = "Mã học phần";
            this.colMaHP.MinimumWidth = 6;
            this.colMaHP.Name = "colMaHP";
            this.colMaHP.ReadOnly = true;
            // 
            // colTenHP
            // 
            this.colTenHP.HeaderText = "Tên học phần";
            this.colTenHP.MinimumWidth = 6;
            this.colTenHP.Name = "colTenHP";
            this.colTenHP.ReadOnly = true;
            // 
            // colNgayDangKy
            // 
            this.colNgayDangKy.HeaderText = "Ngày đăng ký";
            this.colNgayDangKy.MinimumWidth = 6;
            this.colNgayDangKy.Name = "colNgayDangKy";
            this.colNgayDangKy.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1113, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÍ SINH VIÊN";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_QLSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblHeader);
            this.Name = "UC_QLSinhVien";
            this.Size = new System.Drawing.Size(1113, 566);
            this.Load += new System.EventHandler(this.UC_QLSinhVien_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
