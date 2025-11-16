using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLLopHocPhan : UserControl
    {
        public event Action MoUCXepLopHocPhan; // sự kiện mở UC_XepLopHocPhan
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";
        public UC_QLLopHocPhan()
        {
            InitializeComponent();
        }
        
        private void UC_QLLopHocPhan_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu nếu cần
            LoadLopHocPhan();
            LoadHocKyComboBox();
            LoadNamHocComboBox();
        }

        // Event handlers giữ nguyên
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (Form popup = new Form())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Size = new Size(800, 600);

                var uc = new UC_XepLopHocPhan();
                uc.Dock = DockStyle.Fill;
                popup.Controls.Add(uc);

                popup.ShowDialog(); // modal, panel gốc vẫn giữ UC_QLLopHocPhan
                LoadLopHocPhan();
            }
        }
        private void LoadLopHocPhan(string namHoc = null, string hocKy = null)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                                SELECT 
                                    LHP.MaLHP, 
                                    LHP.MaMH, 
                                    MH.TenMH,
                                    LHP.ThoiGianBatDau, 
                                    LHP.ThoiGianKetThuc,
                                    LHP.MaPhong, 
                                    GV.HoTen, 
                                    LHP.SiSoToiDa,
                                    COUNT(DKHP.MaSV) AS SoSVDangKy,
                                    CAST(COUNT(DKHP.MaSV) AS NVARCHAR) + '/' + CAST(LHP.SiSoToiDa AS NVARCHAR) AS SiSo,
                                    LH.TenLichHoc, 
                                    CASE WHEN LHP.DaHuy = 1 THEN N'Đã hủy' ELSE N'Đã mở' END AS TrangThai
                                FROM LOP_HOC_PHAN LHP
                                INNER JOIN MON_HOC MH ON LHP.MaMH = MH.MaMH
                                LEFT JOIN GIANG_VIEN GV ON LHP.MaGV = GV.MaGV
                                INNER JOIN HOC_KY HK ON LHP.MaHocKy = HK.MaHocKy
                                INNER JOIN NAM_HOC NH ON HK.MaNamHoc = NH.MaNamHoc
                                JOIN LICH_HOC LH ON LHP.MaLichHoc = LH.MaLichHoc
                                LEFT JOIN DANG_KY_HOC_PHAN DKHP ON LHP.MaLHP = DKHP.MaLHP 
                                                                AND DKHP.TrangThaiDangKy = N'Đăng ký thành công'
                                WHERE 1=1");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // Lọc năm học
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    string maNamHoc = namHoc.Split('-')[0].Trim(); // Lấy mã năm học
                    queryBuilder.Append(" AND NH.MaNamHoc = @NamHoc");
                    cmd.Parameters.AddWithValue("@NamHoc", maNamHoc);
                }

                // Lọc học kỳ
                if (!string.IsNullOrEmpty(hocKy) && hocKy != "Tất cả học kỳ")
                {
                    queryBuilder.Append(" AND (HK.MaHocKy LIKE @HocKy OR HK.TenHocKy LIKE @HocKy)");
                    cmd.Parameters.AddWithValue("@HocKy", "%" + hocKy + "%");
                }

                queryBuilder.Append(@"
                        GROUP BY LHP.MaLHP, LHP.MaMH, MH.TenMH, LHP.ThoiGianBatDau, 
                                 LHP.ThoiGianKetThuc, LHP.MaPhong, GV.HoTen, LHP.SiSoToiDa, 
                                 LH.TenLichHoc, LHP.DaHuy
                        ORDER BY LHP.ThoiGianBatDau DESC");

                cmd.CommandText = queryBuilder.ToString();

                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvLopHocPhan.DataSource = dt;

                    // Ẩn các cột không cần thiết
                    if (dgvLopHocPhan.Columns.Contains("SiSoToiDa"))
                        dgvLopHocPhan.Columns["SiSoToiDa"].Visible = false;

                    if (dgvLopHocPhan.Columns.Contains("SoSVDangKy"))
                        dgvLopHocPhan.Columns["SoSVDangKy"].Visible = false;

                    

                    dgvLopHocPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào chưa
            if (dgvLopHocPhan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học phần cần sửa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy MaLHP từ dòng được chọn
            string maLHP = dgvLopHocPhan.SelectedRows[0].Cells["MaLHP"].Value.ToString();

            // Mở Form popup với UC_XepLopHocPhan ở chế độ sửa
            using (Form popup = new Form())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Size = new Size(800, 600);
                popup.Text = "Sửa lớp học phần";

                var uc = new UC_XepLopHocPhan(maLHP); // Truyền MaLHP vào
                uc.Dock = DockStyle.Fill;
                popup.Controls.Add(uc);

                popup.ShowDialog();
                LoadLopHocPhan(); // Refresh lại danh sách
            }
        }





        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLopHocPhan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 lớp học phần.");
                return;
            }

            string ma = dgvLopHocPhan.SelectedRows[0].Cells["MaLHP"].Value.ToString();

            if (ma == null)
            {
                MessageBox.Show("Hãy chọn lớp để xóa (hủy).");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn hủy lớp " + ma + "?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE LOP_HOC_PHAN SET DaHuy = 1 WHERE MaLHP = @ma";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Lớp đã được đánh dấu hủy.");
                LoadLopHocPhan(); // load lại DataGridView
            }
        }



        private void btndetails_Click(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString();

            if ((namHoc == "Tất cả năm học" || string.IsNullOrEmpty(namHoc)) &&
                (hocKy == "Tất cả học kỳ" || string.IsNullOrEmpty(hocKy)))
            {
                LoadLopHocPhan();
            }
            else
            {
                LoadLopHocPhan(namHoc, hocKy);
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboNamHoc.SelectedIndex = 0;
            cboHocKy.SelectedIndex = 0;
            LoadLopHocPhan();

            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Load năm học
        private void LoadNamHocComboBox()
        {
            string query = @"
                SELECT DISTINCT nh.MaNamHoc, nh.TenNamHoc
                FROM NAM_HOC nh
                INNER JOIN HOC_KY hk ON nh.MaNamHoc = hk.MaNamHoc
                INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
                WHERE lhp.MaGV IS NOT NULL
                ORDER BY nh.MaNamHoc DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboNamHoc.Items.Clear();
                    cboNamHoc.Items.Add("Tất cả năm học");

                    while (reader.Read())
                    {
                        // Thêm item dạng: "NH2526 - Năm học 2025-2026"
                        string display = $"{reader["MaNamHoc"]}";
                        cboNamHoc.Items.Add(display);
                    }

                    cboNamHoc.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải năm học: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Load học kỳ
        private void LoadHocKyComboBox()
        {
            string query = @"
        SELECT DISTINCT hk.MaHocKy, hk.TenHocKy
        FROM HOC_KY hk
        INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
        ORDER BY hk.MaHocKy DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboHocKy.Items.Clear();
                    cboHocKy.Items.Add("Tất cả học kỳ"); // Placeholder đầu tiên

                    while (reader.Read())
                    {
                        string ma = reader["MaHocKy"].ToString();
                        cboHocKy.Items.Add(ma); // Hoặc $"{ma} - {reader["TenHocKy"]}" nếu muốn hiển thị đẹp
                    }

                    cboHocKy.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải học kỳ: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString() ?? "ALL";
            string hocKy = cboHocKy.SelectedItem?.ToString() ?? "ALL";

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                    SELECT 
                        LHP.MaLHP,
                        LHP.MaMH,
                        MH.TenMH,
                        CONVERT(varchar(10), LHP.ThoiGianBatDau, 103) AS ThoiGianBatDau,
                        CONVERT(varchar(10), LHP.ThoiGianKetThuc, 103) AS ThoiGianKetThuc,
                        LHP.MaPhong,
                        GV.HoTen AS TenGiangVien,
                        LHP.SiSoToiDa,
                        COUNT(DKHP.MaSV) AS SoSVDangKy,
                        CAST(COUNT(DKHP.MaSV) AS NVARCHAR) + '/' + CAST(LHP.SiSoToiDa AS NVARCHAR) AS SiSo,
                        LH.TenLichHoc,
                        HK.MaHocKy,
                        HK.TenHocKy,
                        NH.MaNamHoc,
                        NH.TenNamHoc
                    FROM LOP_HOC_PHAN LHP
                    INNER JOIN MON_HOC MH ON LHP.MaMH = MH.MaMH
                    LEFT JOIN GIANG_VIEN GV ON LHP.MaGV = GV.MaGV
                    INNER JOIN HOC_KY HK ON LHP.MaHocKy = HK.MaHocKy
                    INNER JOIN NAM_HOC NH ON HK.MaNamHoc = NH.MaNamHoc
                    INNER JOIN LICH_HOC LH ON LHP.MaLichHoc = LH.MaLichHoc
                    LEFT JOIN DANG_KY_HOC_PHAN DKHP 
                           ON LHP.MaLHP = DKHP.MaLHP
                          AND DKHP.TrangThaiDangKy = N'Đăng ký thành công'
                    WHERE LHP.DaHuy = 0");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // Lọc năm học
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    string maNamHoc = namHoc.Split('-')[0].Trim();
                    queryBuilder.Append(" AND NH.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", maNamHoc);
                }

                // Lọc học kỳ
                if (!string.IsNullOrEmpty(hocKy) && hocKy != "Tất cả học kỳ")
                {
                    queryBuilder.Append(" AND (HK.MaHocKy LIKE @MaHocKy OR HK.TenHocKy LIKE @MaHocKy)");
                    cmd.Parameters.AddWithValue("@MaHocKy", "%" + hocKy + "%");
                }

                queryBuilder.Append(@"
                    GROUP BY 
                        LHP.MaLHP, LHP.MaMH, MH.TenMH,
                        LHP.ThoiGianBatDau, LHP.ThoiGianKetThuc,
                        LHP.MaPhong, GV.HoTen, 
                        LHP.SiSoToiDa, LH.TenLichHoc,
                        HK.MaHocKy, HK.TenHocKy,
                        NH.MaNamHoc, NH.TenNamHoc
                    ORDER BY LHP.ThoiGianBatDau DESC");

                cmd.CommandText = queryBuilder.ToString();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    var rpt = new rptDanhSachLHP();

                    rpt.lblKyNamHoc.Text = $"Năm học: {namHoc}\nHọc kỳ: {hocKy}";

                    rpt.lblNgayIn.Text =
                        $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    rpt.DataSource = dt;

                    rpt.ShowPreviewDialog();
                }
            }
        }
    }
}
