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
            this.cboTenHocKi = new System.Windows.Forms.ComboBox();
            this.lblTenHocKi = new System.Windows.Forms.Label();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();

            this.lblCongDangKy = new System.Windows.Forms.Label();
            this.lblMoDangKy = new System.Windows.Forms.Label();
            this.lblDongDangKy = new System.Windows.Forms.Label();
            this.dtpMoDangKy = new System.Windows.Forms.DateTimePicker();
            this.dtpDongDangKy = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();

            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();

            // 
            // FormThemHocKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 630);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Thêm học kỳ mới";

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Thêm học kỳ mới";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.AutoSize = true;

            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(30, 70);
            this.pnlThongTin.Size = new System.Drawing.Size(520, 480);
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // 
            // lblThongTinCoBan
            // 
            this.lblThongTinCoBan.Text = "📅 Thông tin cơ bản";
            this.lblThongTinCoBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongTinCoBan.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinCoBan.AutoSize = true;

            // 
            // lblTenHocKi
            // 
            this.lblTenHocKi.Text = "Tên học kỳ";
            this.lblTenHocKi.Location = new System.Drawing.Point(0, 40);
            this.lblTenHocKi.AutoSize = true;

            // 
            // cboTenHocKi
            // 
            this.cboTenHocKi.Items.AddRange(new object[] { "Học kỳ 1", "Học kỳ 2", "Học kỳ hè" });
            this.cboTenHocKi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenHocKi.Location = new System.Drawing.Point(0, 65);
            this.cboTenHocKi.Width = 220;

            // 
            // lblNamHoc
            // 
            this.lblNamHoc.Text = "Năm học";
            this.lblNamHoc.Location = new System.Drawing.Point(260, 40);
            this.lblNamHoc.AutoSize = true;

            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(260, 65);
            this.txtNamHoc.Width = 220;
            this.txtNamHoc.Text = "2024-2025";

            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.Text = "Ngày bắt đầu học kỳ";
            this.lblNgayBatDau.Location = new System.Drawing.Point(0, 120);
            this.lblNgayBatDau.AutoSize = true;

            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(0, 145);
            this.dtpNgayBatDau.Width = 220;

            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.Text = "Ngày kết thúc học kỳ";
            this.lblNgayKetThuc.Location = new System.Drawing.Point(260, 120);
            this.lblNgayKetThuc.AutoSize = true;

            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(260, 145);
            this.dtpNgayKetThuc.Width = 220;

            // 
            // lblCongDangKy
            // 
            this.lblCongDangKy.Text = "⏰ Cổng đăng ký tín chỉ";
            this.lblCongDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCongDangKy.Location = new System.Drawing.Point(0, 210);
            this.lblCongDangKy.AutoSize = true;

            // 
            // lblMoDangKy
            // 
            this.lblMoDangKy.Text = "Ngày mở đăng ký";
            this.lblMoDangKy.Location = new System.Drawing.Point(0, 250);
            this.lblMoDangKy.AutoSize = true;

            // 
            // dtpMoDangKy
            // 
            this.dtpMoDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMoDangKy.Location = new System.Drawing.Point(0, 275);
            this.dtpMoDangKy.Width = 220;

            // 
            // lblDongDangKy
            // 
            this.lblDongDangKy.Text = "Ngày đóng đăng ký";
            this.lblDongDangKy.Location = new System.Drawing.Point(260, 250);
            this.lblDongDangKy.AutoSize = true;

            // 
            // dtpDongDangKy
            // 
            this.dtpDongDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDongDangKy.Location = new System.Drawing.Point(260, 275);
            this.dtpDongDangKy.Width = 220;

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.Location = new System.Drawing.Point(0, 340);
            this.lblTrangThai.AutoSize = true;

            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Items.AddRange(new object[] { "Sắp diễn ra", "Đang diễn ra", "Đã kết thúc" });
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new System.Drawing.Point(0, 365);
            this.cboTrangThai.Width = 220;

            // 
            // btnHuy
            // 
            this.btnHuy.Text = "Hủy";
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnHuy.Location = new System.Drawing.Point(300, 570);
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 
            // btnThem
            // 
            this.btnThem.Text = "Thêm học kỳ";
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(17, 110, 255);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Location = new System.Drawing.Point(420, 570);
            this.btnThem.Size = new System.Drawing.Size(130, 35);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // Add controls
            this.pnlThongTin.Controls.AddRange(new Control[] {
                this.lblThongTinCoBan, this.lblTenHocKi, this.cboTenHocKi,
                this.lblNamHoc, this.txtNamHoc,
                this.lblNgayBatDau, this.dtpNgayBatDau,
                this.lblNgayKetThuc, this.dtpNgayKetThuc,
                this.lblCongDangKy, this.lblMoDangKy, this.dtpMoDangKy,
                this.lblDongDangKy, this.dtpDongDangKy,
                this.lblTrangThai, this.cboTrangThai
            });

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);

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

        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
    }
}
