using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLGiangVien : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public UC_QLGiangVien()
        {
            InitializeComponent();
        }

        private void UC_QLGiangVien_Load(object sender, EventArgs e)
        {
            LoadNamHocComboBox();
            LoadHocKyComboBox(); // THÊM DÒNG NÀY
            LoadDanhSachPhanCong();
        }

        #region LOAD COMBOBOX

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

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboNamHoc.Items.Clear();
                    cboNamHoc.Items.Add("Tất cả năm học"); // Item 0

                    while (reader.Read())
                    {
                        string maNamHoc = reader["MaNamHoc"].ToString();
                        string tenNamHoc = reader["TenNamHoc"].ToString();
                        string display = $"{maNamHoc}"; // HIỂN THỊ ĐẸP
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

        // THÊM HÀM MỚI: Load học kỳ
        private void LoadHocKyComboBox()
        {
            string query = @"
                    SELECT DISTINCT hk.MaHocKy, hk.TenHocKy
                    FROM HOC_KY hk
                    INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
                    WHERE lhp.MaGV IS NOT NULL
                    ORDER BY hk.MaHocKy DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboHocKy.Items.Clear();
                    cboHocKy.Items.Add("Tất cả học kỳ"); // Placeholder

                    while (reader.Read())
                    {
                        string ma = reader["MaHocKy"].ToString();
                        string ten = reader["TenHocKy"].ToString();
                        cboHocKy.Items.Add($"{ma}");
                    }

                    cboHocKy.SelectedIndex = 0; // Chọn "Tất cả"
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải học kỳ: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        // Load dữ liệu phân công
        private void LoadDanhSachPhanCong(string namHoc = null, string hocKy = null)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                SELECT 
                    gv.MaGV,
                    gv.HoTen,
                    lhp.MaLHP,
                    mh.TenMH,
                    lhp.MaLichHoc,
                    lhp.MaPhong
                FROM LOP_HOC_PHAN lhp
                INNER JOIN GIANG_VIEN gv ON lhp.MaGV = gv.MaGV
                INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                INNER JOIN HOC_KY hk ON lhp.MaHocKy = hk.MaHocKy
                INNER JOIN NAM_HOC nh ON hk.MaNamHoc = nh.MaNamHoc
                WHERE lhp.MaGV IS NOT NULL");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // LỌC NĂM HỌC
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    // Lấy mã năm học từ chuỗi: "NH2526 - Năm học 2025-2026" → "NH2526"
                    string maNamHoc = namHoc;
                    queryBuilder.Append(" AND nh.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", maNamHoc);
                }

                // LỌC HỌC KỲ
                if (!string.IsNullOrEmpty(hocKy) && hocKy != "Tất cả học kỳ")
                {
                    string search = hocKy;
                    queryBuilder.Append(" AND (hk.MaHocKy LIKE @HocKy OR hk.TenHocKy LIKE @HocKy)");
                    cmd.Parameters.AddWithValue("@HocKy", "%" + search + "%");
                }

                queryBuilder.Append(" ORDER BY gv.MaGV, lhp.MaLHP");
                cmd.CommandText = queryBuilder.ToString();

                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    new SqlDataAdapter(cmd).Fill(dt);
                    dgvPhanCong.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NÚT TÌM KIẾM
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString(); 

            if ((namHoc == "Tất cả năm học" || string.IsNullOrEmpty(namHoc)) &&
                (hocKy == "Tất cả học kỳ" || string.IsNullOrEmpty(hocKy)))
            {
                LoadDanhSachPhanCong();
            }
            else
            {
                LoadDanhSachPhanCong(namHoc, hocKy);
            }
        }

        // NÚT LÀM MỚI
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            cboNamHoc.SelectedIndex = 0;
            cboHocKy.SelectedIndex = 0;
            LoadDanhSachPhanCong();

            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString();

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                        SELECT 
                            gv.MaGV,
                            gv.HoTen,
                            lhp.MaLHP,
                            mh.TenMH,
                            lhp.MaLichHoc,
                            lhp.MaPhong,
                            hk.MaHocKy,
                            hk.TenHocKy,
                            nh.MaNamHoc,
                            nh.TenNamHoc
                        FROM LOP_HOC_PHAN lhp
                        INNER JOIN GIANG_VIEN gv ON lhp.MaGV = gv.MaGV
                        INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                        INNER JOIN HOC_KY hk ON lhp.MaHocKy = hk.MaHocKy
                        INNER JOIN NAM_HOC nh ON hk.MaNamHoc = nh.MaNamHoc
                        WHERE lhp.MaGV IS NOT NULL");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // LỌC NĂM HỌC
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    string maNamHoc = namHoc;
                    queryBuilder.Append(" AND nh.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", maNamHoc);
                }

                // LỌC HỌC KỲ
                if (!string.IsNullOrEmpty(hocKy) && hocKy != "Tất cả học kỳ")
                {
                    string search = hocKy;
                    queryBuilder.Append(" AND (hk.MaHocKy LIKE @HocKy OR hk.TenHocKy LIKE @HocKy)");
                    cmd.Parameters.AddWithValue("@HocKy", "%" + search + "%");
                }

                queryBuilder.Append(" ORDER BY gv.MaGV, lhp.MaLHP");
                cmd.CommandText = queryBuilder.ToString();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    var rpt = new rptPhanCongGV();

                    rpt.lblTieuDeKy.Text =
                        $"Năm học: {namHoc}\nHọc kỳ: {hocKy}";

                    rpt.lblNgayIn.Text =
                        $"Hà Nội, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";

                    rpt.DataSource = dt;

                    rpt.ShowPreviewDialog();
                }
            }
        }

    }
}