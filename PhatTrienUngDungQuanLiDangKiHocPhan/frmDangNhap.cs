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
    public partial class frmDangNhap : Form
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public frmDangNhap()
        {
            InitializeComponent();
            btnDangNhap.Click += BtnDangNhap_Click;
            this.AcceptButton = btnDangNhap;
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            var username = txtEmail.Text?.Trim();
            var password = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"SELECT LoaiTaiKhoan, MaNguoiDung, TrangThai 
                                                 FROM TAI_KHOAN 
                                                 WHERE TenDangNhap = @user AND MatKhau = @pass", conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Invalid username or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var loai = reader["LoaiTaiKhoan"]?.ToString();
                        var trangThai = reader["TrangThai"]?.ToString();

                        if (!string.Equals(trangThai, "Hoạt động", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Account is not active.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var main = loai.Equals("Admin", StringComparison.OrdinalIgnoreCase) ? (Form)new frmAdmin() : new frmMain();

                        // IMPORTANT: when main is closed, re-show the original login form (do not Close it)
                        main.FormClosed += (s, args) => this.Show();

                        main.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}