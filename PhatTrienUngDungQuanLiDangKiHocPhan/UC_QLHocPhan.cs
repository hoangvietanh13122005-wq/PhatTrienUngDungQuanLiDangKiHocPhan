using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLHocPhan : UserControl
    {
        public UC_QLHocPhan()
        {
            InitializeComponent();
        }

        private void UC_QLHocPhan_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu nếu cần
        }

        // ===== Event handlers ví dụ =====
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string truong = cboTimTheo.SelectedItem.ToString();
            string keyword = txtTuKhoa.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvHocPhan.Rows)
            {
                bool visible = true;
                switch (truong)
                {
                    case "Mã học phần":
                        visible = row.Cells["MaHP"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Tên học phần":
                        visible = row.Cells["TenHP"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Loại":
                        visible = row.Cells["Loai"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Điều kiện tiên quyết":
                        visible = row.Cells["DieuKien"].Value.ToString().ToLower().Contains(keyword);
                        break;
                }
                row.Visible = visible;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Text = "";
            foreach (DataGridViewRow row in dgvHocPhan.Rows)
                row.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Logic thêm học phần
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Logic sửa học phần
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Logic xóa học phần
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Logic lưu học phần
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Logic hủy thao tác
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
