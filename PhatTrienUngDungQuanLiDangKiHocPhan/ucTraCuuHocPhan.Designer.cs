namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    partial class ucTraCuuHocPhan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTraCuuMonHoc = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvMonHoc = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlHeaderTCHP = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTCMH = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtThongTinMonHoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboLoaiTraCuu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLoaiTraCuu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.MaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietLyThuyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietThucHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTraCuuMonHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.pnlHeaderTCHP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTraCuuMonHoc
            // 
            this.pnlTraCuuMonHoc.Controls.Add(this.dgvMonHoc);
            this.pnlTraCuuMonHoc.Controls.Add(this.pnlHeaderTCHP);
            this.pnlTraCuuMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTraCuuMonHoc.FillColor = System.Drawing.Color.White;
            this.pnlTraCuuMonHoc.Location = new System.Drawing.Point(0, 0);
            this.pnlTraCuuMonHoc.Name = "pnlTraCuuMonHoc";
            this.pnlTraCuuMonHoc.Size = new System.Drawing.Size(721, 440);
            this.pnlTraCuuMonHoc.TabIndex = 0;
            // 
            // dgvMonHoc
            // 
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
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMH,
            this.TenMH,
            this.SoTinChi,
            this.SoTietLyThuyet,
            this.SoTietThucHanh});
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
            this.dgvMonHoc.Location = new System.Drawing.Point(0, 118);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersVisible = false;
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.RowTemplate.Height = 24;
            this.dgvMonHoc.Size = new System.Drawing.Size(721, 322);
            this.dgvMonHoc.TabIndex = 8;
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
            this.dgvMonHoc.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMonHoc.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvMonHoc.ThemeStyle.ReadOnly = false;
            this.dgvMonHoc.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMonHoc.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMonHoc.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMonHoc.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMonHoc.ThemeStyle.RowsStyle.Height = 24;
            this.dgvMonHoc.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMonHoc.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlHeaderTCHP
            // 
            this.pnlHeaderTCHP.Controls.Add(this.lblTCMH);
            this.pnlHeaderTCHP.Controls.Add(this.btnTimKiem);
            this.pnlHeaderTCHP.Controls.Add(this.txtThongTinMonHoc);
            this.pnlHeaderTCHP.Controls.Add(this.cboLoaiTraCuu);
            this.pnlHeaderTCHP.Controls.Add(this.lblLoaiTraCuu);
            this.pnlHeaderTCHP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderTCHP.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderTCHP.Name = "pnlHeaderTCHP";
            this.pnlHeaderTCHP.Size = new System.Drawing.Size(721, 118);
            this.pnlHeaderTCHP.TabIndex = 7;
            // 
            // lblTCMH
            // 
            this.lblTCMH.AutoSize = false;
            this.lblTCMH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.lblTCMH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTCMH.ForeColor = System.Drawing.Color.White;
            this.lblTCMH.Location = new System.Drawing.Point(3, 3);
            this.lblTCMH.Name = "lblTCMH";
            this.lblTCMH.Size = new System.Drawing.Size(417, 55);
            this.lblTCMH.TabIndex = 0;
            this.lblTCMH.Text = "TRA CỨU MÔN HỌC";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BorderColor = System.Drawing.Color.DimGray;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderThickness = 1;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.btnTimKiem.Location = new System.Drawing.Point(554, 65);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(154, 45);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm Kiếm";
            // 
            // txtThongTinMonHoc
            // 
            this.txtThongTinMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.txtThongTinMonHoc.BorderColor = System.Drawing.Color.DimGray;
            this.txtThongTinMonHoc.BorderRadius = 10;
            this.txtThongTinMonHoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThongTinMonHoc.DefaultText = "";
            this.txtThongTinMonHoc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtThongTinMonHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtThongTinMonHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThongTinMonHoc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThongTinMonHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThongTinMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThongTinMonHoc.ForeColor = System.Drawing.Color.Black;
            this.txtThongTinMonHoc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThongTinMonHoc.Location = new System.Drawing.Point(229, 65);
            this.txtThongTinMonHoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtThongTinMonHoc.Name = "txtThongTinMonHoc";
            this.txtThongTinMonHoc.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtThongTinMonHoc.PlaceholderText = "Nhập thông tin môn học";
            this.txtThongTinMonHoc.SelectedText = "";
            this.txtThongTinMonHoc.Size = new System.Drawing.Size(319, 45);
            this.txtThongTinMonHoc.TabIndex = 3;
            this.txtThongTinMonHoc.Tag = "";
            // 
            // cboLoaiTraCuu
            // 
            this.cboLoaiTraCuu.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiTraCuu.BorderColor = System.Drawing.Color.DimGray;
            this.cboLoaiTraCuu.BorderRadius = 10;
            this.cboLoaiTraCuu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiTraCuu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTraCuu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiTraCuu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiTraCuu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiTraCuu.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiTraCuu.ItemHeight = 30;
            this.cboLoaiTraCuu.Items.AddRange(new object[] {
            "Mã học phần",
            "Tên học phần"});
            this.cboLoaiTraCuu.Location = new System.Drawing.Point(3, 65);
            this.cboLoaiTraCuu.Name = "cboLoaiTraCuu";
            this.cboLoaiTraCuu.Size = new System.Drawing.Size(220, 36);
            this.cboLoaiTraCuu.TabIndex = 1;
            this.cboLoaiTraCuu.Tag = "";
            this.cboLoaiTraCuu.SelectedIndexChanged += new System.EventHandler(this.cboLoaiTraCuu_SelectedIndexChanged);
            // 
            // lblLoaiTraCuu
            // 
            this.lblLoaiTraCuu.AutoSize = false;
            this.lblLoaiTraCuu.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaiTraCuu.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiTraCuu.Location = new System.Drawing.Point(12, 48);
            this.lblLoaiTraCuu.Name = "lblLoaiTraCuu";
            this.lblLoaiTraCuu.Size = new System.Drawing.Size(133, 20);
            this.lblLoaiTraCuu.TabIndex = 2;
            this.lblLoaiTraCuu.Text = "Loại tra cứu";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // MaMH
            // 
            this.MaMH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Mã HP";
            this.MaMH.MinimumWidth = 6;
            this.MaMH.Name = "MaMH";
            this.MaMH.Width = 53;
            // 
            // TenMH
            // 
            this.TenMH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenMH.DataPropertyName = "TenMH";
            this.TenMH.HeaderText = "Tên HP";
            this.TenMH.MinimumWidth = 6;
            this.TenMH.Name = "TenMH";
            this.TenMH.Width = 74;
            // 
            // SoTinChi
            // 
            this.SoTinChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoTinChi.DataPropertyName = "SoTinChi";
            this.SoTinChi.HeaderText = "STC";
            this.SoTinChi.MinimumWidth = 6;
            this.SoTinChi.Name = "SoTinChi";
            this.SoTinChi.Width = 61;
            // 
            // SoTietLyThuyet
            // 
            this.SoTietLyThuyet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoTietLyThuyet.DataPropertyName = "SoTietLyThuyet";
            this.SoTietLyThuyet.HeaderText = "Số tiết lý thuyết";
            this.SoTietLyThuyet.MinimumWidth = 6;
            this.SoTietLyThuyet.Name = "SoTietLyThuyet";
            this.SoTietLyThuyet.Width = 112;
            // 
            // SoTietThucHanh
            // 
            this.SoTietThucHanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoTietThucHanh.DataPropertyName = "SoTietThucHanh";
            this.SoTietThucHanh.HeaderText = "Số tiết thực hành";
            this.SoTietThucHanh.MinimumWidth = 6;
            this.SoTietThucHanh.Name = "SoTietThucHanh";
            this.SoTietThucHanh.Width = 93;
            // 
            // ucTraCuuHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTraCuuMonHoc);
            this.Name = "ucTraCuuHocPhan";
            this.Size = new System.Drawing.Size(721, 440);
            this.pnlTraCuuMonHoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.pnlHeaderTCHP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTraCuuMonHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTCMH;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiTraCuu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLoaiTraCuu;
        private Guna.UI2.WinForms.Guna2TextBox txtThongTinMonHoc;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderTCHP;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietLyThuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietThucHanh;
    }
}
