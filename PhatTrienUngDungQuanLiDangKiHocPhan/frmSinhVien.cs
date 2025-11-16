using System;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        // New constructor: accept student id and optional student name
        public frmMain(string maSV, string tenSV) : this()
        {
            if (!string.IsNullOrEmpty(maSV))
                lblMSV.Text = maSV;

            if (!string.IsNullOrEmpty(tenSV))
                lblTenSV.Text = tenSV;
            
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }

        private void picLogo_Click(object sender, EventArgs e) { }

        private void btnDKTC_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucDangKyTinChi(lblMSV.Text));
        }

        private void btnTCHP_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTraCuuHocPhan());
        }

        private void btnLSDK_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucLichSuDangKy(lblMSV.Text));
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Closing this form will re-show the original login form (frmDangNhap) because login attached FormClosed handler
            this.Close();
        }

        
    }
}
