using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLSinhVien : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public UC_QLSinhVien()
        {
            InitializeComponent();
            this.Load += UC_QLSinhVien_Load;
        }

        private void UC_QLSinhVien_Load(object sender, EventArgs e)
        {
            LoadNamHocComboBox();
            LoadDanhSachDangKy();
        }

        // Load danh sách năm học vào ComboBox
        private void LoadNamHocComboBox()
        {
            string query = @"
                SELECT DISTINCT nh.MaNamHoc, nh.TenNamHoc
                FROM NAM_HOC nh
                INNER JOIN HOC_KY hk ON nh.MaNamHoc = hk.MaNamHoc
                INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
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

        // Load danh sách đăng ký của tất cả sinh viên
        private void LoadDanhSachDangKy(string namHoc = null, string hocKy = null)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                SELECT 
                    sv.MaSV,
                    sv.HoTen,
                    dkhp.MaLHP,
                    mh.TenMH,
                    dkhp.NgayDangKy AS ThoiGian,
                    dkhp.TrangThaiDangKy AS HanhDong
                FROM DANG_KY_HOC_PHAN dkhp
                INNER JOIN SINH_VIEN sv ON dkhp.MaSV = sv.MaSV
                INNER JOIN LOP_HOC_PHAN lhp ON dkhp.MaLHP = lhp.MaLHP
                INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                INNER JOIN HOC_KY hk ON lhp.MaHocKy = hk.MaHocKy
                INNER JOIN NAM_HOC nh ON hk.MaNamHoc = nh.MaNamHoc
                WHERE 1=1");

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;

                // Lọc theo năm học
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    // Lấy phần mã năm học (VD: "NH2526 - Năm học 2025-2026" => "NH2526")
                    string maNamHoc = namHoc;
                    queryBuilder.Append(" AND nh.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", maNamHoc);
                }

                // Lọc theo học kỳ (tìm kiếm trong mã học kỳ hoặc tên học kỳ)
                if (!string.IsNullOrEmpty(hocKy))
                {
                    queryBuilder.Append(" AND (hk.MaHocKy LIKE @HocKy OR hk.TenHocKy LIKE @HocKy)");
                    cmd.Parameters.AddWithValue("@HocKy", "%" + hocKy + "%");
                }

                queryBuilder.Append(" ORDER BY dkhp.NgayDangKy DESC, sv.MaSV");
                cmd.CommandText = queryBuilder.ToString();

                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    dgvDangKy.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Tìm kiếm
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = txtHocKy.Text.Trim();

            // Kiểm tra nếu không nhập gì
            if ((namHoc == "Tất cả năm học" || string.IsNullOrEmpty(namHoc)) &&
                string.IsNullOrEmpty(hocKy))
            {
                LoadDanhSachDangKy();
            }
            else
            {
                LoadDanhSachDangKy(namHoc, hocKy);
            }
        }

        // Nút Làm mới
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            // Reset các bộ lọc
            cboNamHoc.SelectedIndex = 0;
            txtHocKy.Clear();

            // Load lại toàn bộ dữ liệu
            LoadDanhSachDangKy();

            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = txtHocKy.Text.Trim();

            // Lưu giá trị gốc để hiển thị label
            string displayNamHoc = (namHoc == "Tất cả năm học" || string.IsNullOrEmpty(namHoc)) ? "Tất cả" : namHoc;
            string displayHocKy = string.IsNullOrEmpty(hocKy) ? "Tất cả" : hocKy;

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                    SELECT 
                        sv.MaSV,
                        sv.HoTen AS TenSinhVien,
                        dkhp.MaLHP,
                        mh.TenMH,
                        CONVERT(varchar(19), dkhp.NgayDangKy, 120) AS ThoiGian,
                        dkhp.TrangThaiDangKy AS HanhDong,
                        hk.MaHocKy,
                        hk.TenHocKy,
                        nh.MaNamHoc,
                        nh.TenNamHoc,
                        mh.SoTinChi
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN SINH_VIEN sv ON dkhp.MaSV = sv.MaSV
                    INNER JOIN LOP_HOC_PHAN lhp ON dkhp.MaLHP = lhp.MaLHP
                    INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                    INNER JOIN HOC_KY hk ON lhp.MaHocKy = hk.MaHocKy
                    INNER JOIN NAM_HOC nh ON hk.MaNamHoc = nh.MaNamHoc
                    WHERE 1=1");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // Lọc theo năm học
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    queryBuilder.Append(" AND nh.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", namHoc);
                }

                // Lọc theo học kỳ
                if (!string.IsNullOrEmpty(hocKy))
                {
                    queryBuilder.Append(" AND (hk.MaHocKy LIKE @HocKy OR hk.TenHocKy LIKE @HocKy)");
                    cmd.Parameters.AddWithValue("@HocKy", "%" + hocKy + "%");
                }

                queryBuilder.Append(" ORDER BY dkhp.NgayDangKy DESC, sv.MaSV");
                cmd.CommandText = queryBuilder.ToString();

                DataTable dt = new DataTable();
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    // Tạo report
                    var rpt = new rptDanhSachDangKy();

                    rpt.lblKyNamHoc.Text =
                        $"Năm học: {displayNamHoc}\nHọc kỳ: {displayHocKy}";

                    rpt.lblNgayIn.Text =
                        $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    rpt.DataSource = dt;
                    rpt.ShowPreviewDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu báo cáo: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}