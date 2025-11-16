using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class ucTraCuuHocPhan : UserControl
    {
        // Update this connection string to match your SQL Server and database.
        // Alternatively move it to App.config and use ConfigurationManager.
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public ucTraCuuHocPhan()
        {
            InitializeComponent();

            // wire events
            btnTimKiem.Click += BtnTimKiem_Click;
            this.Load += ucTraCuuHocPhan_Load;

            // default selection
            if (cboLoaiTraCuu.Items.Count > 0)
                cboLoaiTraCuu.SelectedIndex = 0;
        }

        private void ucTraCuuHocPhan_Load(object sender, EventArgs e)
        {
            LoadMonHoc(); // load all on control load
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            var term = txtThongTinMonHoc.Text?.Trim();
            if (string.IsNullOrEmpty(term))
            {
                LoadMonHoc();
                return;
            }

            var type = cboLoaiTraCuu.SelectedItem?.ToString();
            LoadMonHoc(type, term);
        }

        /// <summary>
        /// Loads courses into dgvMonHoc. If filterType/filterTerm provided, applies a WHERE clause.
        /// filterType expected values: "Mã học phần" or "Tên học phần" (as in Designer).
        /// </summary>
        private void LoadMonHoc(string filterType = null, string filterTerm = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    var sql = new StringBuilder();
                    sql.Append("SELECT MaMH, TenMH, SoTinChi, SoTietLyThuyet, SoTietThucHanh FROM MON_HOC");

                    if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterTerm))
                    {
                        if (filterType.IndexOf("Mã", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            sql.Append(" WHERE MaMH LIKE @term + '%'");
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                        else
                        {
                            // search by name (contains)
                            sql.Append(" WHERE TenMH LIKE '%' + @term + '%'");
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                    }

                    cmd.CommandText = sql.ToString();

                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvMonHoc.DataSource = table;

                    // optional cosmetic adjustments
                    dgvMonHoc.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load course data: " + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLoaiTraCuu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // keep existing designer hook; no changes required
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // keep existing designer hook; no changes required
        }
    }
}
