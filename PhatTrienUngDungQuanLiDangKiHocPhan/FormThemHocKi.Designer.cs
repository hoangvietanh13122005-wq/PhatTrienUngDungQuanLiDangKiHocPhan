using System.Windows.Forms;

namespace UngdungQuanliDangkiHocphan
{
    partial class FormThemHocKi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblThongTinCoBan = new System.Windows.Forms.Label();
            this.lblTenHocKi = new System.Windows.Forms.Label();
            this.cboTenHocKi = new System.Windows.Forms.ComboBox();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblCongDangKy = new System.Windows.Forms.Label();
            this.lblMoDangKy = new System.Windows.Forms.Label();
            this.dtpMoDangKy = new System.Windows.Forms.DateTimePicker();
            this.lblDongDangKy = new System.Windows.Forms.Label();
            this.dtpDongDangKy = new System.Windows.Forms.DateTimePicker();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin học kỳ";
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Controls.Add(this.lblThongTinCoBan);
            this.pnlThongTin.Controls.Add(this.lblTenHocKi);
            this.pnlThongTin.Controls.Add(this.cboTenHocKi);
            this.pnlThongTin.Controls.Add(this.lblNamHoc);
            this.pnlThongTin.Controls.Add(this.txtNamHoc);
            this.pnlThongTin.Controls.Add(this.lblNgayBatDau);
            this.pnlThongTin.Controls.Add(this.dtpNgayBatDau);
            this.pnlThongTin.Controls.Add(this.lblNgayKetThuc);
            this.pnlThongTin.Controls.Add(this.dtpNgayKetThuc);
            this.pnlThongTin.Controls.Add(this.lblCongDangKy);
            this.pnlThongTin.Controls.Add(this.lblMoDangKy);
            this.pnlThongTin.Controls.Add(this.dtpMoDangKy);
            this.pnlThongTin.Controls.Add(this.lblDongDangKy);
            this.pnlThongTin.Controls.Add(this.dtpDongDangKy);
            this.pnlThongTin.Location = new System.Drawing.Point(30, 56);
            this.pnlThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(520, 384);
            this.pnlThongTin.TabIndex = 1;
            // 
            // lblThongTinCoBan
            // 
            this.lblThongTinCoBan.AutoSize = true;
            this.lblThongTinCoBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongTinCoBan.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinCoBan.Name = "lblThongTinCoBan";
            this.lblThongTinCoBan.Size = new System.Drawing.Size(176, 23);
            this.lblThongTinCoBan.TabIndex = 0;
            this.lblThongTinCoBan.Text = "📅 Thông tin cơ bản";
            // 
            // lblTenHocKi
            // 
            this.lblTenHocKi.AutoSize = true;
            this.lblTenHocKi.Location = new System.Drawing.Point(0, 32);
            this.lblTenHocKi.Name = "lblTenHocKi";
            this.lblTenHocKi.Size = new System.Drawing.Size(73, 16);
            this.lblTenHocKi.TabIndex = 1;
            this.lblTenHocKi.Text = "Tên học kỳ";
            // 
            // cboTenHocKi
            // 
            this.cboTenHocKi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenHocKi.Items.AddRange(new object[] {
            "Học kỳ 1",
            "Học kỳ 2",
            "Học kỳ hè"});
            this.cboTenHocKi.Location = new System.Drawing.Point(0, 52);
            this.cboTenHocKi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTenHocKi.Name = "cboTenHocKi";
            this.cboTenHocKi.Size = new System.Drawing.Size(220, 24);
            this.cboTenHocKi.TabIndex = 2;
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Location = new System.Drawing.Point(260, 32);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(61, 16);
            this.lblNamHoc.TabIndex = 3;
            this.lblNamHoc.Text = "Năm học";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(260, 52);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(220, 22);
            this.txtNamHoc.TabIndex = 4;
            this.txtNamHoc.Text = "2024-2025";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(0, 96);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(130, 16);
            this.lblNgayBatDau.TabIndex = 5;
            this.lblNgayBatDau.Text = "Ngày bắt đầu học kỳ";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(0, 116);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(220, 22);
            this.dtpNgayBatDau.TabIndex = 6;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(260, 96);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(130, 16);
            this.lblNgayKetThuc.TabIndex = 7;
            this.lblNgayKetThuc.Text = "Ngày kết thúc học kỳ";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(260, 116);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(220, 22);
            this.dtpNgayKetThuc.TabIndex = 8;
            // 
            // lblCongDangKy
            // 
            this.lblCongDangKy.AutoSize = true;
            this.lblCongDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCongDangKy.Location = new System.Drawing.Point(0, 168);
            this.lblCongDangKy.Name = "lblCongDangKy";
            this.lblCongDangKy.Size = new System.Drawing.Size(206, 23);
            this.lblCongDangKy.TabIndex = 9;
            this.lblCongDangKy.Text = "⏰ Cổng đăng ký tín chỉ";
            // 
            // lblMoDangKy
            // 
            this.lblMoDangKy.AutoSize = true;
            this.lblMoDangKy.Location = new System.Drawing.Point(0, 200);
            this.lblMoDangKy.Name = "lblMoDangKy";
            this.lblMoDangKy.Size = new System.Drawing.Size(113, 16);
            this.lblMoDangKy.TabIndex = 10;
            this.lblMoDangKy.Text = "Ngày mở đăng ký";
            // 
            // dtpMoDangKy
            // 
            this.dtpMoDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMoDangKy.Location = new System.Drawing.Point(0, 220);
            this.dtpMoDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpMoDangKy.Name = "dtpMoDangKy";
            this.dtpMoDangKy.Size = new System.Drawing.Size(220, 22);
            this.dtpMoDangKy.TabIndex = 11;
            // 
            // lblDongDangKy
            // 
            this.lblDongDangKy.AutoSize = true;
            this.lblDongDangKy.Location = new System.Drawing.Point(260, 200);
            this.lblDongDangKy.Name = "lblDongDangKy";
            this.lblDongDangKy.Size = new System.Drawing.Size(125, 16);
            this.lblDongDangKy.TabIndex = 12;
            this.lblDongDangKy.Text = "Ngày đóng đăng ký";
            // 
            // dtpDongDangKy
            // 
            this.dtpDongDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDongDangKy.Location = new System.Drawing.Point(260, 220);
            this.dtpDongDangKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDongDangKy.Name = "dtpDongDangKy";
            this.dtpDongDangKy.Size = new System.Drawing.Size(220, 22);
            this.dtpDongDangKy.TabIndex = 13;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Location = new System.Drawing.Point(300, 456);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 28);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(420, 456);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 28);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Lưu";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FormThemHocKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 504);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormThemHocKi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin học kỳ";
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblThongTinCoBan;
        private System.Windows.Forms.Label lblTenHocKi;
        private System.Windows.Forms.ComboBox cboTenHocKi;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;

        private System.Windows.Forms.Label lblCongDangKy;
        private System.Windows.Forms.Label lblMoDangKy;
        private System.Windows.Forms.Label lblDongDangKy;
        private System.Windows.Forms.DateTimePicker dtpMoDangKy;
        private System.Windows.Forms.DateTimePicker dtpDongDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
    }
}
