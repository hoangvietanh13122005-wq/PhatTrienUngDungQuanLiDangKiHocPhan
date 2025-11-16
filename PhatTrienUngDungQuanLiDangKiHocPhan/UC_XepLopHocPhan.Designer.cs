namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    partial class UC_XepLopHocPhan
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.tblLich = new System.Windows.Forms.TableLayoutPanel();
            this.dgvThoiKhoaBieu = new System.Windows.Forms.DataGridView();
            this.legendPanel = new System.Windows.Forms.Panel();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblCa = new System.Windows.Forms.Label();
            this.txtCa = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblSiSo = new System.Windows.Forms.Label();
            this.txtSiSo = new System.Windows.Forms.TextBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.lblTenHP = new System.Windows.Forms.Label();
            this.txtTenHP = new System.Windows.Forms.TextBox();
            this.lblMaLHP = new System.Windows.Forms.Label();
            this.txtMaLHP = new System.Windows.Forms.TextBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.tblLich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainLayout.Controls.Add(this.leftPanel, 0, 0);
            this.mainLayout.Controls.Add(this.infoPanel, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1000, 600);
            this.mainLayout.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.tblLich);
            this.leftPanel.Controls.Add(this.legendPanel);
            this.leftPanel.Controls.Add(this.dtpNgay);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(644, 594);
            this.leftPanel.TabIndex = 0;
            // 
            // tblLich
            // 
            this.tblLich.AutoScroll = true;
            this.tblLich.BackColor = System.Drawing.Color.White;
            this.tblLich.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblLich.ColumnCount = 1;
            this.tblLich.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLich.Controls.Add(this.dgvThoiKhoaBieu, 0, 0);
            this.tblLich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLich.Location = new System.Drawing.Point(0, 22);
            this.tblLich.Name = "tblLich";
            this.tblLich.RowCount = 1;
            this.tblLich.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLich.Size = new System.Drawing.Size(644, 532);
            this.tblLich.TabIndex = 2;
            // 
            // dgvThoiKhoaBieu
            // 
            this.dgvThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(4, 4);
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.RowHeadersWidth = 51;
            this.dgvThoiKhoaBieu.RowTemplate.Height = 24;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(636, 524);
            this.dgvThoiKhoaBieu.TabIndex = 0;
            // 
            // legendPanel
            // 
            this.legendPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.legendPanel.Location = new System.Drawing.Point(0, 554);
            this.legendPanel.Name = "legendPanel";
            this.legendPanel.Size = new System.Drawing.Size(644, 40);
            this.legendPanel.TabIndex = 1;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(644, 22);
            this.dtpNgay.TabIndex = 0;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.White;
            this.infoPanel.Controls.Add(this.btnLuu);
            this.infoPanel.Controls.Add(this.lblKetThuc);
            this.infoPanel.Controls.Add(this.dtpKetThuc);
            this.infoPanel.Controls.Add(this.lblBatDau);
            this.infoPanel.Controls.Add(this.dtpBatDau);
            this.infoPanel.Controls.Add(this.lblCa);
            this.infoPanel.Controls.Add(this.txtCa);
            this.infoPanel.Controls.Add(this.lblPhong);
            this.infoPanel.Controls.Add(this.txtPhong);
            this.infoPanel.Controls.Add(this.lblSiSo);
            this.infoPanel.Controls.Add(this.txtSiSo);
            this.infoPanel.Controls.Add(this.lblGiangVien);
            this.infoPanel.Controls.Add(this.txtGiangVien);
            this.infoPanel.Controls.Add(this.lblTenHP);
            this.infoPanel.Controls.Add(this.txtTenHP);
            this.infoPanel.Controls.Add(this.lblMaLHP);
            this.infoPanel.Controls.Add(this.txtMaLHP);
            this.infoPanel.Controls.Add(this.btnQuayLai);
            this.infoPanel.Controls.Add(this.lblTitle);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(653, 3);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(15);
            this.infoPanel.Size = new System.Drawing.Size(344, 594);
            this.infoPanel.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(18, 530);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 35);
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "Lưu thông tin";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Location = new System.Drawing.Point(18, 460);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(91, 16);
            this.lblKetThuc.TabIndex = 17;
            this.lblKetThuc.Text = "Ngày kết thúc:";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKetThuc.Location = new System.Drawing.Point(18, 480);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(220, 22);
            this.dtpKetThuc.TabIndex = 16;
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Location = new System.Drawing.Point(18, 400);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(91, 16);
            this.lblBatDau.TabIndex = 15;
            this.lblBatDau.Text = "Ngày bắt đầu:";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new System.Drawing.Point(18, 420);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(220, 22);
            this.dtpBatDau.TabIndex = 14;
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Location = new System.Drawing.Point(18, 340);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(52, 16);
            this.lblCa.TabIndex = 13;
            this.lblCa.Text = "Ca học:";
            // 
            // txtCa
            // 
            this.txtCa.Location = new System.Drawing.Point(18, 360);
            this.txtCa.Name = "txtCa";
            this.txtCa.ReadOnly = true;
            this.txtCa.Size = new System.Drawing.Size(220, 22);
            this.txtCa.TabIndex = 12;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(18, 280);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(74, 16);
            this.lblPhong.TabIndex = 11;
            this.lblPhong.Text = "Phòng học:";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(18, 300);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(220, 22);
            this.txtPhong.TabIndex = 10;
            // 
            // lblSiSo
            // 
            this.lblSiSo.AutoSize = true;
            this.lblSiSo.Location = new System.Drawing.Point(18, 220);
            this.lblSiSo.Name = "lblSiSo";
            this.lblSiSo.Size = new System.Drawing.Size(78, 16);
            this.lblSiSo.TabIndex = 9;
            this.lblSiSo.Text = "Sĩ số tối đa:";
            // 
            // txtSiSo
            // 
            this.txtSiSo.Location = new System.Drawing.Point(18, 240);
            this.txtSiSo.Name = "txtSiSo";
            this.txtSiSo.Size = new System.Drawing.Size(220, 22);
            this.txtSiSo.TabIndex = 8;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(18, 160);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(74, 16);
            this.lblGiangVien.TabIndex = 7;
            this.lblGiangVien.Text = "Giảng viên:";
            // 
            // txtGiangVien
            // 
            this.txtGiangVien.Location = new System.Drawing.Point(18, 180);
            this.txtGiangVien.Name = "txtGiangVien";
            this.txtGiangVien.Size = new System.Drawing.Size(220, 22);
            this.txtGiangVien.TabIndex = 6;
            // 
            // lblTenHP
            // 
            this.lblTenHP.AutoSize = true;
            this.lblTenHP.Location = new System.Drawing.Point(18, 100);
            this.lblTenHP.Name = "lblTenHP";
            this.lblTenHP.Size = new System.Drawing.Size(92, 16);
            this.lblTenHP.TabIndex = 5;
            this.lblTenHP.Text = "Tên học phần:";
            // 
            // txtTenHP
            // 
            this.txtTenHP.Location = new System.Drawing.Point(21, 119);
            this.txtTenHP.Name = "txtTenHP";
            this.txtTenHP.Size = new System.Drawing.Size(220, 22);
            this.txtTenHP.TabIndex = 4;
            // 
            // lblMaLHP
            // 
            this.lblMaLHP.AutoSize = true;
            this.lblMaLHP.Location = new System.Drawing.Point(20, 51);
            this.lblMaLHP.Name = "lblMaLHP";
            this.lblMaLHP.Size = new System.Drawing.Size(109, 16);
            this.lblMaLHP.TabIndex = 3;
            this.lblMaLHP.Text = "Mã lớp học phần:";
            // 
            // txtMaLHP
            // 
            this.txtMaLHP.Location = new System.Drawing.Point(18, 70);
            this.txtMaLHP.Name = "txtMaLHP";
            this.txtMaLHP.Size = new System.Drawing.Size(220, 22);
            this.txtMaLHP.TabIndex = 2;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuayLai.BackColor = System.Drawing.Color.LightGray;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Location = new System.Drawing.Point(229, 5);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(100, 30);
            this.btnQuayLai.TabIndex = 1;
            this.btnQuayLai.Text = "← Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin lớp học phần";
            // 
            // UC_XepLopHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.mainLayout);
            this.Name = "UC_XepLopHocPhan";
            this.Size = new System.Drawing.Size(1000, 600);
            this.mainLayout.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.tblLich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Panel legendPanel;
        private System.Windows.Forms.TableLayoutPanel tblLich;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label lblMaLHP;
        private System.Windows.Forms.TextBox txtMaLHP;
        private System.Windows.Forms.Label lblTenHP;
        private System.Windows.Forms.TextBox txtTenHP;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.Label lblSiSo;
        private System.Windows.Forms.TextBox txtSiSo;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.TextBox txtCa;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvThoiKhoaBieu;
    }
}