using System;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLGiangVien : UserControl
    {
        public UC_QLGiangVien()
        {
            InitializeComponent();
        }

        private void UC_QLGiangVien_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu nếu cần
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string truong = cboTimTheo.SelectedItem.ToString();
            string keyword = txtTuKhoa.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvPhanCong.Rows)
            {
                bool visible = true;
                switch (truong)
                {
                    case "Mã giảng viên":
                        visible = row.Cells["MaGV"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Tên giảng viên":
                        visible = row.Cells["TenGV"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Mã học phần":
                        visible = row.Cells["MaLopHP"].Value.ToString().ToLower().Contains(keyword);
                        break;
                    case "Tên học phần":
                        visible = row.Cells["TenHP"].Value.ToString().ToLower().Contains(keyword);
                        break;
                }
                row.Visible = visible;
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Text = "";
            foreach (DataGridViewRow row in dgvPhanCong.Rows)
                row.Visible = true;
        }

        private void dgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTimTheo_Click(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
