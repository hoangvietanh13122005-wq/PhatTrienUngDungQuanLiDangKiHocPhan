namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    partial class frmMain
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.lblTenDaihoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChucNang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLSDK = new Guna.UI2.WinForms.Guna2Button();
            this.btnTCHP = new Guna.UI2.WinForms.Guna2Button();
            this.btnDKTC = new Guna.UI2.WinForms.Guna2Button();
            this.pnlThongTinSV = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblTenSV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMSV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picLogo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlThongTinSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTenDaihoc);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1800, 122);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.BorderColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.BorderRadius = 10;
            this.btnDangXuat.BorderThickness = 1;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(1667, 40);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(113, 36);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblTenDaihoc
            // 
            this.lblTenDaihoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenDaihoc.AutoSize = false;
            this.lblTenDaihoc.AutoSizeHeightOnly = true;
            this.lblTenDaihoc.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDaihoc.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDaihoc.ForeColor = System.Drawing.Color.Transparent;
            this.lblTenDaihoc.Location = new System.Drawing.Point(383, 42);
            this.lblTenDaihoc.Name = "lblTenDaihoc";
            this.lblTenDaihoc.Size = new System.Drawing.Size(1203, 42);
            this.lblTenDaihoc.TabIndex = 0;
            this.lblTenDaihoc.Text = "CPA UNIVERSITY";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.lblChucNang);
            this.pnlSidebar.Controls.Add(this.btnLSDK);
            this.pnlSidebar.Controls.Add(this.btnTCHP);
            this.pnlSidebar.Controls.Add(this.btnDKTC);
            this.pnlSidebar.Controls.Add(this.pnlThongTinSV);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 122);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(275, 583);
            this.pnlSidebar.TabIndex = 1;
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = false;
            this.lblChucNang.AutoSizeHeightOnly = true;
            this.lblChucNang.BackColor = System.Drawing.Color.Transparent;
            this.lblChucNang.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucNang.ForeColor = System.Drawing.Color.Transparent;
            this.lblChucNang.Location = new System.Drawing.Point(26, 190);
            this.lblChucNang.Name = "lblChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(202, 32);
            this.lblChucNang.TabIndex = 4;
            this.lblChucNang.Text = "CHỨC NĂNG";
            // 
            // btnLSDK
            // 
            this.btnLSDK.BackColor = System.Drawing.Color.Transparent;
            this.btnLSDK.BorderRadius = 15;
            this.btnLSDK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLSDK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLSDK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLSDK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLSDK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLSDK.ForeColor = System.Drawing.Color.White;
            this.btnLSDK.Location = new System.Drawing.Point(48, 365);
            this.btnLSDK.Name = "btnLSDK";
            this.btnLSDK.Size = new System.Drawing.Size(180, 45);
            this.btnLSDK.TabIndex = 3;
            this.btnLSDK.Text = "Lịch sử đăng ký";
            this.btnLSDK.Click += new System.EventHandler(this.btnLSDK_Click);
            // 
            // btnTCHP
            // 
            this.btnTCHP.BackColor = System.Drawing.Color.Transparent;
            this.btnTCHP.BorderRadius = 15;
            this.btnTCHP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTCHP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTCHP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTCHP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTCHP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTCHP.ForeColor = System.Drawing.Color.White;
            this.btnTCHP.Location = new System.Drawing.Point(48, 296);
            this.btnTCHP.Name = "btnTCHP";
            this.btnTCHP.Size = new System.Drawing.Size(180, 45);
            this.btnTCHP.TabIndex = 2;
            this.btnTCHP.Text = "Tra cứu học phần";
            this.btnTCHP.Click += new System.EventHandler(this.btnTCHP_Click);
            // 
            // btnDKTC
            // 
            this.btnDKTC.BackColor = System.Drawing.Color.Transparent;
            this.btnDKTC.BorderRadius = 15;
            this.btnDKTC.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDKTC.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDKTC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDKTC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDKTC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDKTC.ForeColor = System.Drawing.Color.White;
            this.btnDKTC.Location = new System.Drawing.Point(48, 228);
            this.btnDKTC.Name = "btnDKTC";
            this.btnDKTC.Size = new System.Drawing.Size(180, 45);
            this.btnDKTC.TabIndex = 1;
            this.btnDKTC.Text = "Đăng ký tín chỉ";
            this.btnDKTC.Click += new System.EventHandler(this.btnDKTC_Click);
            // 
            // pnlThongTinSV
            // 
            this.pnlThongTinSV.BackColor = System.Drawing.Color.Transparent;
            this.pnlThongTinSV.Controls.Add(this.lblTenSV);
            this.pnlThongTinSV.Controls.Add(this.lblMSV);
            this.pnlThongTinSV.Controls.Add(this.guna2CirclePictureBox1);
            this.pnlThongTinSV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlThongTinSV.Location = new System.Drawing.Point(26, 20);
            this.pnlThongTinSV.Name = "pnlThongTinSV";
            this.pnlThongTinSV.Radius = 15;
            this.pnlThongTinSV.ShadowColor = System.Drawing.Color.Black;
            this.pnlThongTinSV.Size = new System.Drawing.Size(221, 143);
            this.pnlThongTinSV.TabIndex = 0;
            // 
            // lblTenSV
            // 
            this.lblTenSV.AutoSize = false;
            this.lblTenSV.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSV.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSV.ForeColor = System.Drawing.Color.Transparent;
            this.lblTenSV.Location = new System.Drawing.Point(34, 78);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new System.Drawing.Size(310, 34);
            this.lblTenSV.TabIndex = 1;
            this.lblTenSV.Text = "TenSV";
            // 
            // lblMSV
            // 
            this.lblMSV.AutoSize = false;
            this.lblMSV.AutoSizeHeightOnly = true;
            this.lblMSV.BackColor = System.Drawing.Color.Transparent;
            this.lblMSV.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSV.ForeColor = System.Drawing.Color.Transparent;
            this.lblMSV.Location = new System.Drawing.Point(34, 108);
            this.lblMSV.Name = "lblMSV";
            this.lblMSV.Size = new System.Drawing.Size(158, 21);
            this.lblMSV.TabIndex = 2;
            this.lblMSV.Text = "MSV";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.FillColor = System.Drawing.Color.White;
            this.pnlMainContent.Location = new System.Drawing.Point(275, 122);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1525, 583);
            this.pnlMainContent.TabIndex = 2;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::PhatTrienUngDungQuanLiDangKiHocPhan.Properties.Resources.user;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(83, 12);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(61, 60);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.picLogo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(115)))), ((int)(((byte)(190)))));
            this.picLogo.Image = global::PhatTrienUngDungQuanLiDangKiHocPhan.Properties.Resources.Logo_NEU;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(99, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picLogo.Size = new System.Drawing.Size(119, 116);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1800, 705);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlThongTinSV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenDaihoc;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMSV;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenSV;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlThongTinSV;
        private Guna.UI2.WinForms.Guna2Button btnDKTC;
        private Guna.UI2.WinForms.Guna2Button btnLSDK;
        private Guna.UI2.WinForms.Guna2Button btnTCHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChucNang;
        private Guna.UI2.WinForms.Guna2Panel pnlMainContent;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}

