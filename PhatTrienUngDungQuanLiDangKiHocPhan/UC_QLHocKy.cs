using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UngdungQuanliDangkiHocphan
{
    public partial class UC_QLHocKi : UserControl
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public UC_QLHocKi()
        {
            InitializeComponent();
            this.Load += UC_QLHocKi_Load;
        }

        private void UC_QLHocKi_Load(object sender, EventArgs e)
        {
            dgvHocKi.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvHocKi.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            btnThemHocKi.Left = this.Width - btnThemHocKi.Width - 25;
            btnThemHocKi.Top = 25;

            // Load data from DB
            LoadHocKy();
        }

        private void LoadHocKy()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"
                    SELECT h.MaHocKy, n.TenNamHoc, h.TenHocKy, h.NgayBatDau, h.NgayKetThuc, h.NgayBatDauDK, h.NgayKetThucDK
                    FROM HOC_KY h
                    LEFT JOIN NAM_HOC n ON h.MaNamHoc = n.MaNamHoc
                    ORDER BY h.NgayBatDau DESC", conn))
                {
                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvHocKi.AutoGenerateColumns = true;
                    dgvHocKi.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemHocKi_Click(object sender, EventArgs e)
        {
            // Mở form thêm học kỳ mới (sẽ tạo sau)
            using (FormThemHocKi f = new FormThemHocKi())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
            }

            // refresh after adding
            LoadHocKy();
        }

        private void btnSuaHocKi_Click(object sender, EventArgs e)
        {
            if (dgvHocKi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một học kỳ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvHocKi.CurrentRow.DataBoundItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var maHocKy = row["MaHocKy"]?.ToString();
            if (string.IsNullOrEmpty(maHocKy))
            {
                MessageBox.Show("Không lấy được mã học kỳ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new FormThemHocKi(maHocKy))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadHocKy();
            }
        }
    }
}
