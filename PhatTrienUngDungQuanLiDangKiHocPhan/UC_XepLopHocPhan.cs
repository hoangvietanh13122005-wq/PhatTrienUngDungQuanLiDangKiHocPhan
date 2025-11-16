using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_XepLopHocPhan : UserControl
    {
        private DataGridViewCell selectedCell = null;
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";
        private string maLHPEdit = null; // Biến lưu mã lớp đang sửa
        private bool isEditMode = false; // Biến đánh dấu chế độ sửa
        public UC_XepLopHocPhan(string maLHP = null)
        {
            InitializeComponent();
            
            BuildScheduleGrid();
            LoadMonHocComboBox();

            // Nếu có maLHP => chế độ sửa
            if (!string.IsNullOrEmpty(maLHP))
            {
                maLHPEdit = maLHP;
                isEditMode = true;
                LoadDataForEdit(maLHP); // Load dữ liệu để sửa
            }
        }
        private void LoadDataForEdit(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT LHP.*, MH.TenMH
            FROM LOP_HOC_PHAN LHP
            INNER JOIN MON_HOC MH ON LHP.MaMH = MH.MaMH
            WHERE LHP.MaLHP = @MaLHP
        ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Fill dữ liệu vào các control
                    ComboBox cmbTenHP = infoPanel.Controls.OfType<ComboBox>()
                                        .FirstOrDefault(c => c.Name == "cmbTenHP");
                    if (cmbTenHP != null)
                    {
                        cmbTenHP.Text = reader["TenMH"].ToString();
                    }

                    txtGiangVien.Text = reader["MaGV"].ToString();
                    dtpBatDau.Value = Convert.ToDateTime(reader["ThoiGianBatDau"]);
                    dtpKetThuc.Value = Convert.ToDateTime(reader["ThoiGianKetThuc"]);
                    txtPhong.Text = reader["MaPhong"].ToString();
                    txtCa.Text = reader["MaLichHoc"].ToString();
                    txtSiSo.Text = reader["SiSoToiDa"].ToString();

                    // Highlight ô đã chọn trong lưới
                    HighlightSelectedCell(reader["MaPhong"].ToString(),
                                          reader["MaLichHoc"].ToString());
                }
            }

            // Load trạng thái thời khóa biểu
            LoadExistingClasses(dtpNgay.Value);
        }
        private void HighlightSelectedCell(string phong, string ca)
        {
            var dgv = dgvThoiKhoaBieu;

            for (int r = 0; r < dgv.RowCount; r++)
            {
                if (dgv.Rows[r].HeaderCell.Value.ToString() == phong)
                {
                    for (int c = 0; c < dgv.ColumnCount; c++)
                    {
                        if (dgv.Columns[c].Name == ca)
                        {
                            selectedCell = dgv[c, r];
                            selectedCell.Style.BackColor = Color.Yellow;
                            return;
                        }
                    }
                }
            }
        }
        //===========================================================
        // TẠO MA TRẬN THỜI KHÓA BIỂU
        //===========================================================
        private List<string> LoadRoomsFromDatabase()
        {
            List<string> rooms = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaPhong FROM PHONG_HOC ORDER BY MaPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(reader.GetString(0).Trim());
                        }
                    }
                }
            }

            return rooms;
        }
        private void BuildScheduleGrid()
        {
            var dgv = dgvThoiKhoaBieu;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.RowHeadersVisible = true;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            dgv.Columns.Clear();
            dgv.Rows.Clear();

            // Tạo cột: T2(12,34,56,78) … đến T7
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7" };
            string[] sessions = { "12", "34", "56", "78" };

            foreach (string d in days)
            {
                foreach (string s in sessions)
                {
                    string colName = $"{d}{s}";
                    dgv.Columns.Add(colName, colName);
                    dgv.Columns[colName].Width = 70;
                }
            }
            //tạo ra dòng: A101, A102, A301…
            List<string> rooms = LoadRoomsFromDatabase();

            foreach (var room in rooms)
                dgv.Rows.Add();

            for (int i = 0; i < rooms.Count; i++)
                dgv.Rows[i].HeaderCell.Value = rooms[i];  // A101, A102, A301...

            dgv.RowHeadersWidth = 70;

            dgv.CellClick += Dgv_CellClick;

            // Load trạng thái đã có lớp từ database
            LoadExistingClasses(DateTime.Today);
        }

        //===========================================================
        // Load trạng thái các ô đã có lớp (màu xanh)
        //===========================================================
        private void LoadExistingClasses(DateTime ngayChon)
        {
            var dgv = dgvThoiKhoaBieu;
            // 1. Reset màu ô
            for (int r = 0; r < dgv.RowCount; r++)
                for (int c = 0; c < dgv.ColumnCount; c++)
                    dgv[c, r].Style.BackColor = Color.White;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                                                SELECT MaPhong, MaLichHoc 
                                                FROM LOP_HOC_PHAN
                                                WHERE @NgayChon >= ThoiGianBatDau AND @NgayChon <= ThoiGianKetThuc
                                                ", conn);
                cmd.Parameters.AddWithValue("@NgayChon", ngayChon.Date);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string phong = reader["MaPhong"].ToString();
                    string lich = reader["MaLichHoc"].ToString();

                    for (int r = 0; r < dgv.RowCount; r++)
                    {
                        if (dgv.Rows[r].HeaderCell.Value.ToString() == phong)
                        {
                            for (int c = 0; c < dgv.ColumnCount; c++)
                            {
                                if (dgv.Columns[c].Name == lich)
                                    dgv[c, r].Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }


        //===========================================================
        // Click cell chọn ô
        //===========================================================
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var dgv = dgvThoiKhoaBieu;

            // 
            
            if (selectedCell != null)
                selectedCell.Style.BackColor = Color.White;

            selectedCell = dgv[e.ColumnIndex, e.RowIndex];

            // 
            if (selectedCell.Style.BackColor == Color.LightGreen)
            {
                selectedCell = null;
                return;
            }
            selectedCell.Style.BackColor = Color.Yellow;


            // 
            txtPhong.Text = dgv.Rows[e.RowIndex].HeaderCell.Value.ToString();
            txtCa.Text = dgv.Columns[e.ColumnIndex].HeaderText;
            txtSiSo.Text = "50"; // mặc định
        }

        //===========================================================
        // Load danh sách môn học vào ComboBox
        //===========================================================
        private void LoadMonHocComboBox()
        {
            ComboBox cmbTenHP = new ComboBox
            {
                Location = txtTenHP.Location,
                Size = txtTenHP.Size,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.CustomSource
            };

            infoPanel.Controls.Remove(txtTenHP);
            infoPanel.Controls.Add(cmbTenHP);

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenMH, MaMH FROM MON_HOC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    source.Add(reader["TenMH"].ToString());
                    cmbTenHP.Items.Add(reader["TenMH"].ToString());
                }
            }

            cmbTenHP.AutoCompleteCustomSource = source;
            cmbTenHP.Name = "cmbTenHP";
        }
        //===========================================================
        // Lưu thông tin lớp học phần
        //===========================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (selectedCell == null)
            {
                MessageBox.Show("Vui lòng chọn ô thời khóa biểu!");
                return;
            }

            string phong = txtPhong.Text;
            string ca = txtCa.Text;
            string siSo = txtSiSo.Text;
            DateTime batDau = dtpBatDau.Value.Date;
            DateTime ketThuc = dtpKetThuc.Value.Date;
            string maGV = txtGiangVien.Text;

            ComboBox cmbTenHP = infoPanel.Controls.OfType<ComboBox>().FirstOrDefault();
            if (cmbTenHP == null || string.IsNullOrEmpty(cmbTenHP.Text))
            {
                MessageBox.Show("Vui lòng chọn tên học phần!");
                return;
            }

            string tenMH = cmbTenHP.Text;
            string maMH = "";

            // Lấy MaMH
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaMH FROM MON_HOC WHERE TenMH=@TenMH", conn);
                cmd.Parameters.AddWithValue("@TenMH", tenMH);
                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Môn học không tồn tại!");
                    return;
                }
                maMH = result.ToString();
            }

            // Lấy MaHocKy
            string maHocKy = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT MaHocKy FROM HOC_KY
            WHERE @NgayBatDau >= NgayBatDau AND @NgayKetThuc <= NgayKetThuc
        ", conn);
                cmd.Parameters.AddWithValue("@NgayBatDau", batDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ketThuc);

                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Không xác định được học kỳ!");
                    return;
                }
                maHocKy = result.ToString();
            }

            string maLHP = "";
            string maLichHoc = ca;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (isEditMode)
                {
                    // Chế độ SỬA
                    maLHP = maLHPEdit;
                    cmd.CommandText = @"
                UPDATE LOP_HOC_PHAN
                SET MaMH = @MaMH,
                    MaHocKy = @MaHocKy,
                    MaPhong = @MaPhong,
                    SiSoToiDa = @SiSoToiDa,
                    MaLichHoc = @MaLichHoc,
                    ThoiGianBatDau = @ThoiGianBatDau,
                    ThoiGianKetThuc = @ThoiGianKetThuc,
                    MaGV = @MaGV
                WHERE MaLHP = @MaLHP
            ";
                }
                else
                {
                    // Chế độ THÊM MỚI
                    int soThuTuLop = 1;
                    using (SqlConnection conn2 = new SqlConnection(connectionString))
                    {
                        conn2.Open();
                        SqlCommand cmd2 = new SqlCommand(@"
                    SELECT COUNT(*) FROM LOP_HOC_PHAN 
                    WHERE MaMH=@MaMH AND MaHocKy=@MaHocKy
                ", conn2);
                        cmd2.Parameters.AddWithValue("@MaMH", maMH);
                        cmd2.Parameters.AddWithValue("@MaHocKy", maHocKy);
                        soThuTuLop = (int)cmd2.ExecuteScalar() + 1;
                    }

                    maLHP = $"{maMH}{maHocKy}{soThuTuLop:D2}";

                    cmd.CommandText = @"
                        INSERT INTO LOP_HOC_PHAN 
                        (MaLHP, MaMH, MaHocKy, MaPhong, SiSoToiDa, MaLichHoc, 
                         ThoiGianBatDau, ThoiGianKetThuc, MaGV)
                        VALUES (@MaLHP, @MaMH, @MaHocKy, @MaPhong, @SiSoToiDa, 
                                @MaLichHoc, @ThoiGianBatDau, @ThoiGianKetThuc, @MaGV)
                    ";
                }

                // Thêm parameters
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKy);
                cmd.Parameters.AddWithValue("@MaPhong", phong);
                cmd.Parameters.AddWithValue("@SiSoToiDa", int.Parse(siSo));
                cmd.Parameters.AddWithValue("@MaLichHoc", maLichHoc);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", batDau);
                cmd.Parameters.AddWithValue("@ThoiGianKetThuc", ketThuc);
                cmd.Parameters.AddWithValue("@MaGV", (object)maGV ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }

            selectedCell.Style.BackColor = Color.LightGreen;
            selectedCell = null;

            MessageBox.Show(isEditMode ? "Đã cập nhật lớp học phần!" : "Đã lưu lớp học phần!");
            this.FindForm().Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            // Chỉ đóng Form popup, không ảnh hưởng UC_QLLopHocPhan
            this.FindForm().Close();
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadExistingClasses(dtpNgay.Value);
        }
    }
}
