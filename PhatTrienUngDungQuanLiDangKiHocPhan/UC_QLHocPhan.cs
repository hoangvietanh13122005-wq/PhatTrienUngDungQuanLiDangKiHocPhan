using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLHocPhan : UserControl
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public UC_QLHocPhan()
        {
            InitializeComponent();

            this.Load += UC_QLHocPhan_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void UC_QLHocPhan_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var type = cboTimTheo.SelectedItem?.ToString();
            var term = txtTuKhoa.Text?.Trim();
            LoadMonHoc(type, term);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Text = "";
            cboTimTheo.SelectedIndex = -1;
            LoadMonHoc();
        }

        private void LoadMonHoc(string filterType = null, string filterTerm = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    var sql = @"
                                SELECT 
                                    mh.MaMH, 
                                    mh.TenMH, 
                                    mh.SoTinChi, 
                                    mtq.TenMH AS TenMonTienQuyet
                                FROM MON_HOC mh
                                LEFT JOIN MON_HOC mtq ON mh.MaMonTienQuyet = mtq.MaMH";


                    if (!string.IsNullOrWhiteSpace(filterType) && !string.IsNullOrWhiteSpace(filterTerm))
                    {
                        if (filterType.IndexOf("Mã", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            sql += " WHERE mh.MaMH LIKE @term + '%'";
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                        else
                        {
                            sql += " WHERE mh.TenMH LIKE '%' + @term + '%'";
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                    }

                    cmd.CommandText = sql;

                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    // Bind to grid
                    dgvHocPhan.AutoGenerateColumns = true;
                    dgvHocPhan.DataSource = table;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học phần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
