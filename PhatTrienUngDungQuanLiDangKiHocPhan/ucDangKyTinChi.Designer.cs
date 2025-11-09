using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    partial class ucDangKyTinChi
    {
        private System.ComponentModel.IContainer components = null;

        // --- KHAI BÁO CONTROL (Designer phải có) ---
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblProgram;
        private Guna.UI2.WinForms.Guna2ComboBox cboChuongTrinh;

        private Guna.UI2.WinForms.Guna2DataGridView dgvMonHoc;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLopHocPhan;

        private Guna.UI2.WinForms.Guna2Panel pnlThongTinDangKy;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTongTinChi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDaDangKy;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cboChuongTrinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvMonHoc = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvLopHocPhan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlThongTinDangKy = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDaDangKy = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameLHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongTinChi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.MaLHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoChoTrong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDangKy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHocPhan)).BeginInit();
            this.pnlThongTinDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblProgram);
            this.panelTop.Controls.Add(this.cboChuongTrinh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.FillColor = System.Drawing.Color.White;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20);
            this.panelTop.Size = new System.Drawing.Size(1839, 70);
            this.panelTop.TabIndex = 3;
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblProgram.Location = new System.Drawing.Point(10, 20);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(189, 23);
            this.lblProgram.TabIndex = 0;
            this.lblProgram.Text = "Chương trình đào tạo:";
            // 
            // cboChuongTrinh
            // 
            this.cboChuongTrinh.BackColor = System.Drawing.Color.Transparent;
            this.cboChuongTrinh.BorderRadius = 8;
            this.cboChuongTrinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboChuongTrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuongTrinh.FocusedColor = System.Drawing.Color.Empty;
            this.cboChuongTrinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboChuongTrinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboChuongTrinh.ItemHeight = 30;
            this.cboChuongTrinh.Location = new System.Drawing.Point(190, 15);
            this.cboChuongTrinh.Name = "cboChuongTrinh";
            this.cboChuongTrinh.Size = new System.Drawing.Size(300, 36);
            this.cboChuongTrinh.TabIndex = 1;
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMonHoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonHoc.ColumnHeadersHeight = 40;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHP,
            this.TenHP,
            this.STC,
            this.btnCol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.Location = new System.Drawing.Point(0, 70);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersVisible = false;
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.Size = new System.Drawing.Size(1519, 457);
            this.dgvMonHoc.TabIndex = 0;
            this.dgvMonHoc.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonHoc.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvMonHoc.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvMonHoc.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMonHoc.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMonHoc.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonHoc.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMonHoc.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMonHoc.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMonHoc.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonHoc.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvMonHoc.ThemeStyle.ReadOnly = false;
            this.dgvMonHoc.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonHoc.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMonHoc.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMonHoc.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMonHoc.ThemeStyle.RowsStyle.Height = 22;
            this.dgvMonHoc.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // MaHP
            // 
            this.MaHP.HeaderText = "Mã học phần";
            this.MaHP.MinimumWidth = 6;
            this.MaHP.Name = "MaHP";
            // 
            // TenHP
            // 
            this.TenHP.HeaderText = "Tên học phần";
            this.TenHP.MinimumWidth = 6;
            this.TenHP.Name = "TenHP";
            // 
            // STC
            // 
            this.STC.HeaderText = "Số tín chỉ";
            this.STC.MinimumWidth = 6;
            this.STC.Name = "STC";
            // 
            // btnCol
            // 
            this.btnCol.HeaderText = "";
            this.btnCol.MinimumWidth = 6;
            this.btnCol.Name = "btnCol";
            this.btnCol.Text = "Đăng ký";
            this.btnCol.UseColumnTextForButtonValue = true;
            // 
            // dgvLopHocPhan
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvLopHocPhan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLopHocPhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLopHocPhan.ColumnHeadersHeight = 35;
            this.dgvLopHocPhan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLHP,
            this.MaLH,
            this.TenGV,
            this.SoChoTrong,
            this.btnDangKy});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLopHocPhan.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLopHocPhan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLopHocPhan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHocPhan.Location = new System.Drawing.Point(0, 527);
            this.dgvLopHocPhan.Name = "dgvLopHocPhan";
            this.dgvLopHocPhan.RowHeadersVisible = false;
            this.dgvLopHocPhan.RowHeadersWidth = 51;
            this.dgvLopHocPhan.Size = new System.Drawing.Size(1519, 180);
            this.dgvLopHocPhan.TabIndex = 1;
            this.dgvLopHocPhan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHocPhan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLopHocPhan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLopHocPhan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLopHocPhan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLopHocPhan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHocPhan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLopHocPhan.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvLopHocPhan.ThemeStyle.ReadOnly = false;
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.Height = 22;
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLopHocPhan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlThongTinDangKy
            // 
            this.pnlThongTinDangKy.Controls.Add(this.dgvDaDangKy);
            this.pnlThongTinDangKy.Controls.Add(this.lblTongTinChi);
            this.pnlThongTinDangKy.Controls.Add(this.lblTitle);
            this.pnlThongTinDangKy.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThongTinDangKy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.pnlThongTinDangKy.Location = new System.Drawing.Point(1519, 70);
            this.pnlThongTinDangKy.Name = "pnlThongTinDangKy";
            this.pnlThongTinDangKy.Padding = new System.Windows.Forms.Padding(10);
            this.pnlThongTinDangKy.Size = new System.Drawing.Size(320, 637);
            this.pnlThongTinDangKy.TabIndex = 2;
            // 
            // dgvDaDangKy
            // 
            this.dgvDaDangKy.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvDaDangKy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDaDangKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDaDangKy.ColumnHeadersHeight = 35;
            this.dgvDaDangKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenMon,
            this.NameLHP});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDaDangKy.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDaDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaDangKy.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDaDangKy.Location = new System.Drawing.Point(10, 80);
            this.dgvDaDangKy.Name = "dgvDaDangKy";
            this.dgvDaDangKy.RowHeadersVisible = false;
            this.dgvDaDangKy.RowHeadersWidth = 51;
            this.dgvDaDangKy.Size = new System.Drawing.Size(300, 547);
            this.dgvDaDangKy.TabIndex = 0;
            this.dgvDaDangKy.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDaDangKy.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDaDangKy.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDaDangKy.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDaDangKy.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDaDangKy.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDaDangKy.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDaDangKy.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvDaDangKy.ThemeStyle.ReadOnly = false;
            this.dgvDaDangKy.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDaDangKy.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDaDangKy.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDaDangKy.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDaDangKy.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDaDangKy.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDaDangKy.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDaDangKy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDaDangKy_CellContentClick);
            // 
            // TenMon
            // 
            this.TenMon.HeaderText = "Môn học";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            // 
            // NameLHP
            // 
            this.NameLHP.HeaderText = "Lớp HP";
            this.NameLHP.MinimumWidth = 6;
            this.NameLHP.Name = "NameLHP";
            // 
            // lblTongTinChi
            // 
            this.lblTongTinChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTongTinChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongTinChi.Location = new System.Drawing.Point(10, 50);
            this.lblTongTinChi.Name = "lblTongTinChi";
            this.lblTongTinChi.Size = new System.Drawing.Size(300, 30);
            this.lblTongTinChi.TabIndex = 1;
            this.lblTongTinChi.Text = "Tổng số tín chỉ: 0";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "TỔNG HỢP ĐĂNG KÝ";
            // 
            // MaLHP
            // 
            this.MaLHP.HeaderText = "Mã lớp HP";
            this.MaLHP.MinimumWidth = 6;
            this.MaLHP.Name = "MaLHP";
            // 
            // MaLH
            // 
            this.MaLH.HeaderText = "Lịch học";
            this.MaLH.MinimumWidth = 6;
            this.MaLH.Name = "MaLH";
            // 
            // TenGV
            // 
            this.TenGV.HeaderText = "Giảng viên";
            this.TenGV.MinimumWidth = 6;
            this.TenGV.Name = "TenGV";
            // 
            // SoChoTrong
            // 
            this.SoChoTrong.HeaderText = "Số chỗ trống";
            this.SoChoTrong.MinimumWidth = 6;
            this.SoChoTrong.Name = "SoChoTrong";
            // 
            // btnDangKy
            // 
            this.btnDangKy.HeaderText = "";
            this.btnDangKy.MinimumWidth = 6;
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseColumnTextForButtonValue = true;
            // 
            // ucDangKyTinChi
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.dgvLopHocPhan);
            this.Controls.Add(this.pnlThongTinDangKy);
            this.Controls.Add(this.panelTop);
            this.Name = "ucDangKyTinChi";
            this.Size = new System.Drawing.Size(1839, 707);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHocPhan)).EndInit();
            this.pnlThongTinDangKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewTextBoxColumn MaHP;
        private DataGridViewTextBoxColumn TenHP;
        private DataGridViewTextBoxColumn STC;
        private DataGridViewButtonColumn btnCol;
        private DataGridViewTextBoxColumn TenMon;
        private DataGridViewTextBoxColumn NameLHP;
        private DataGridViewTextBoxColumn MaLHP;
        private DataGridViewTextBoxColumn MaLH;
        private DataGridViewTextBoxColumn TenGV;
        private DataGridViewTextBoxColumn SoChoTrong;
        private DataGridViewButtonColumn btnDangKy;
    }
}
