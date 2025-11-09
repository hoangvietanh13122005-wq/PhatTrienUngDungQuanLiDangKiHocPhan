using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnDKTC_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucDangKyTinChi());
        }

        private void btnTCHP_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTraCuuHocPhan());
        }

        private void btnLSDK_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucLichSuDangKy());
        }
    }
}
