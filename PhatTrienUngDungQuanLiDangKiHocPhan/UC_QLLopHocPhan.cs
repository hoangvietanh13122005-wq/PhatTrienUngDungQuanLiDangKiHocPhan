using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLLopHocPhan : UserControl
    {
        public event Action MoUCXepLopHocPhan; // sự kiện mở UC_XepLopHocPhan

        public UC_QLLopHocPhan()
        {
            InitializeComponent();
        }

        private void UC_QLLopHocPhan_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu nếu cần
        }

        // Event handlers giữ nguyên
        private void btnThem_Click(object sender, EventArgs e)
        {
            MoUCXepLopHocPhan?.Invoke();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Code sửa lớp học phần
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Code xóa lớp học phần
        }

        private void btndetails_Click(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
