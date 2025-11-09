using System;
using System.Windows.Forms;

namespace UngdungQuanliDangkiHocphan
{
    public partial class FormThemHocKi : Form
    {
        public FormThemHocKi()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Hiện tại chỉ đóng form, chưa lưu
            MessageBox.Show("Học kỳ mới đã được thêm (mô phỏng).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
