using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class ucLichSuDangKy : UserControl
    {
        private string _maSV;
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        public ucLichSuDangKy(string maSV)
        {
            InitializeComponent();
            this.Load += ucLichSuDangKy_Load;
            _maSV = maSV;
        }

        private void ucLichSuDangKy_Load(object sender, EventArgs e)
        {
            LoadNamHocComboBox();
            LoadHocKyComboBox();
            LoadLichSuDangKy();
        }

        // Load danh sách năm học vào ComboBox
        private void LoadNamHocComboBox()
        {
            string query = @"
                SELECT DISTINCT nh.MaNamHoc, nh.TenNamHoc
                FROM NAM_HOC nh
                INNER JOIN HOC_KY hk ON nh.MaNamHoc = hk.MaNamHoc
                INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
                INNER JOIN LICH_SU_DANG_KY lsdk ON lhp.MaLHP = lsdk.MaLHP
                WHERE lsdk.MaSV = @MaSV
                ORDER BY nh.MaNamHoc DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MaSV", _maSV);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboNamHoc.Items.Clear();
                    cboNamHoc.Items.Add("Tất cả năm học");

                    while (reader.Read())
                    {
                        // Thêm item dạng: "NH2526"
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

        // Load danh sách học kỳ vào ComboBox
        private void LoadHocKyComboBox()
        {
            string query = @"
                SELECT DISTINCT hk.MaHocKy, hk.TenHocKy
                FROM HOC_KY hk
                INNER JOIN LOP_HOC_PHAN lhp ON hk.MaHocKy = lhp.MaHocKy
                INNER JOIN LICH_SU_DANG_KY lsdk ON lhp.MaLHP = lsdk.MaLHP
                WHERE lsdk.MaSV = @MaSV
                ORDER BY hk.MaHocKy DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MaSV", _maSV);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    cboHocKy.Items.Clear();
                    cboHocKy.Items.Add("Tất cả học kỳ");

                    while (reader.Read())
                    {
                        // Thêm item dạng: "HK1_2526"
                        string display = $"{reader["MaHocKy"]}";
                        cboHocKy.Items.Add(display);
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

        // Load lịch sử đăng ký (mặc định hoặc có lọc)
        private void LoadLichSuDangKy(string namHoc = null, string hocKy = null)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                SELECT 
                    lsdk.MaSV,
                    lsdk.MaLHP,
                    mh.TenMH,
                    lsdk.ThoiGian,
                    lsdk.HanhDong
                FROM LICH_SU_DANG_KY lsdk
                INNER JOIN LOP_HOC_PHAN lhp ON lhp.MaLHP = lsdk.MaLHP
                INNER JOIN MON_HOC mh ON mh.MaMH = lhp.MaMH
                INNER JOIN HOC_KY hk ON hk.MaHocKy = lhp.MaHocKy
                INNER JOIN NAM_HOC nh ON nh.MaNamHoc = hk.MaNamHoc
                WHERE lsdk.MaSV = @MaSV");

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@MaSV", _maSV);

                // Lọc theo năm học
                if (!string.IsNullOrEmpty(namHoc) && namHoc != "Tất cả năm học")
                {
                    // Lấy phần mã năm học (VD: "NH2526 - Năm học 2025-2026" => "NH2526")
                    string maNamHoc = namHoc;
                    queryBuilder.Append(" AND nh.MaNamHoc = @MaNamHoc");
                    cmd.Parameters.AddWithValue("@MaNamHoc", maNamHoc);
                }

                // Lọc theo học kỳ
                if (!string.IsNullOrEmpty(hocKy) && hocKy != "Tất cả học kỳ")
                {
                    // Lấy phần mã học kỳ (VD: "HK1_2526 - Học kỳ 1..." => "HK1_2526")
                    string maHocKy = hocKy;
                    queryBuilder.Append(" AND hk.MaHocKy = @MaHocKy");
                    cmd.Parameters.AddWithValue("@MaHocKy", maHocKy);
                }

                queryBuilder.Append(" ORDER BY lsdk.ThoiGian DESC");
                cmd.CommandText = queryBuilder.ToString();

                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                    dgvLichSu.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải lịch sử: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện nút Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString();

            // Nếu cả 2 đều chọn "Tất cả" thì load tất cả
            if ((namHoc == "Tất cả năm học" || string.IsNullOrEmpty(namHoc)) &&
                (hocKy == "Tất cả học kỳ" || string.IsNullOrEmpty(hocKy)))
            {
                LoadLichSuDangKy();
            }
            else
            {
                LoadLichSuDangKy(namHoc, hocKy);
            }
        }

        // Sự kiện thay đổi năm học - TỰ ĐỘNG lọc
        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không tự động tìm khi mới load
            if (cboNamHoc.SelectedIndex < 0) return;

            // Tự động tìm kiếm khi thay đổi năm học
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString();

            if (namHoc == "Tất cả năm học" && hocKy == "Tất cả học kỳ")
            {
                LoadLichSuDangKy();
            }
            else
            {
                LoadLichSuDangKy(namHoc, hocKy);
            }
        }

        // Sự kiện thay đổi học kỳ - TỰ ĐỘNG lọc
        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không tự động tìm khi mới load
            if (cboHocKy.SelectedIndex < 0) return;

            // Tự động tìm kiếm khi thay đổi học kỳ
            string namHoc = cboNamHoc.SelectedItem?.ToString();
            string hocKy = cboHocKy.SelectedItem?.ToString();

            if (namHoc == "Tất cả năm học" && hocKy == "Tất cả học kỳ")
            {
                LoadLichSuDangKy();
            }
            else
            {
                LoadLichSuDangKy(namHoc, hocKy);
            }
        }
    }
}