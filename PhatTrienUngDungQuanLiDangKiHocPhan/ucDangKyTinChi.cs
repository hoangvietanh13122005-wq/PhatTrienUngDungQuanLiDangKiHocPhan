using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class ucDangKyTinChi : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";
        private string maSV; // Mã sinh viên đang đăng nhập
        private string maHocKyHienTai; // Học kỳ hiện tại
        private const int MIN_TIN_CHI = 12;
        private const int MAX_TIN_CHI = 24;

        public ucDangKyTinChi(string maSinhVien)
        {
            InitializeComponent();
            this.maSV = maSinhVien;
            this.Load += UcDangKyTinChi_Load;

            // Đăng ký sự kiện click cho DataGridView
            dgvMonHoc.CellClick += DgvMonHoc_CellClick;
            dgvLopHocPhan.CellClick += DgvLopHocPhan_CellClick;
            dgvDaDangKy.CellClick += DgvDaDangKy_CellClick;
        }

        private void UcDangKyTinChi_Load(object sender, EventArgs e)
        {
            LayHocKyHienTai();
            LoadChuongTrinhDaoTao();
            LoadMonHocHocKy();
            LoadDanhSachDaDangKy();
            TinhTongTinChi();
        }

        //=============================================================
        // 1. KHỞI TẠO & LOAD DỮ LIỆU
        //=============================================================

        // Lấy học kỳ hiện tại
        private void LayHocKyHienTai()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 MaHocKy 
                    FROM HOC_KY 
                    WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThuc
                    ORDER BY NgayBatDau DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                    maHocKyHienTai = result.ToString();
                else
                    maHocKyHienTai = "HK1_2526"; // Mặc định nếu không tìm thấy
            }
        }

        // Kiểm tra còn trong thời gian đăng ký không
        private bool KiemTraTrongThoiGianDangKy()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM HOC_KY
                    WHERE MaHocKy = @MaHocKy
                      AND GETDATE() BETWEEN NgayBatDauDK AND NgayKetThucDK";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Load ComboBox chương trình đào tạo
        private void LoadChuongTrinhDaoTao()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ctdt.MaCTDT, ctdt.TenCTDT
                    FROM SINH_VIEN sv
                    INNER JOIN CHUONG_TRINH_DAO_TAO ctdt ON sv.MaCTDT = ctdt.MaCTDT
                    WHERE sv.MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                SqlDataReader reader = cmd.ExecuteReader();

                cboChuongTrinh.Items.Clear();
                if (reader.Read())
                {
                    string display = $"{reader["TenCTDT"]}";
                    cboChuongTrinh.Items.Add(display);
                    cboChuongTrinh.SelectedIndex = 0;
                }
            }
        }

        // Load danh sách môn học của học kỳ hiện tại
        private void LoadMonHocHocKy()
        {
            dgvMonHoc.Rows.Clear();

            // Kiểm tra còn trong thời gian đăng ký không
            if (!KiemTraTrongThoiGianDangKy())
            {
                MessageBox.Show("Hiện tại không trong thời gian đăng ký!\n" +
                                "Vui lòng liên hệ phòng đào tạo để biết thêm chi tiết.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Load các môn có lớp học phần được mở trong học kỳ hiện tại
                string query = @"
                    SELECT DISTINCT mh.MaMH, mh.TenMH, mh.SoTinChi, cm.BatBuoc_TuChon
                    FROM MON_HOC mh
                    INNER JOIN LOP_HOC_PHAN lhp ON mh.MaMH = lhp.MaMH
                    INNER JOIN CTDT_MON_HOC cm ON mh.MaMH = cm.MaMH
                    INNER JOIN SINH_VIEN sv ON cm.MaCTDT = sv.MaCTDT
                    WHERE sv.MaSV = @MaSV
                      AND lhp.MaHocKy = @MaHocKy
                      AND lhp.DaHuy = 0
                    ORDER BY cm.BatBuoc_TuChon, mh.MaMH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string loaiMon = row["BatBuoc_TuChon"].ToString();
                    string tenMonHienThi = $"{row["TenMH"]} [{loaiMon}]";

                    dgvMonHoc.Rows.Add(
                        row["MaMH"],
                        tenMonHienThi,  // Hiển thị kèm loại môn
                        row["SoTinChi"],
                        "Chọn"
                    );
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có môn học nào được mở trong học kỳ này!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Load danh sách đã đăng ký (giỏ hàng bên phải)
        private void LoadDanhSachDaDangKy()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT mh.TenMH, dkhp.MaLHP, mh.SoTinChi
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN LOP_HOC_PHAN lhp ON dkhp.MaLHP = lhp.MaLHP
                    INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                    WHERE dkhp.MaSV = @MaSV 
                      AND lhp.MaHocKy = @MaHocKy
                      AND dkhp.TrangThaiDangKy = N'Đăng ký thành công'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDaDangKy.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvDaDangKy.Rows.Add(
                        row["TenMH"],
                        row["MaLHP"]
                    );
                }
            }
        }

        // Tính tổng tín chỉ đã đăng ký
        private void TinhTongTinChi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(SUM(mh.SoTinChi), 0) AS TongTinChi
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN LOP_HOC_PHAN lhp ON dkhp.MaLHP = lhp.MaLHP
                    INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                    WHERE dkhp.MaSV = @MaSV 
                      AND lhp.MaHocKy = @MaHocKy
                      AND dkhp.TrangThaiDangKy = N'Đăng ký thành công'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                int tongTinChi = (int)cmd.ExecuteScalar();
                lblTongTinChi.Text = $"Tổng số tín chỉ: {tongTinChi}";

                // Cảnh báo nếu vượt quá giới hạn
                if (tongTinChi > MAX_TIN_CHI)
                {
                    lblTongTinChi.ForeColor = System.Drawing.Color.Red;
                    lblTongTinChi.Text += $" (Vượt quá {MAX_TIN_CHI} TC!)";
                }
                else if (tongTinChi < MIN_TIN_CHI)
                {
                    lblTongTinChi.ForeColor = System.Drawing.Color.Orange;
                    lblTongTinChi.Text += $" (Tối thiểu {MIN_TIN_CHI} TC)";
                }
                else
                {
                    lblTongTinChi.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        //=============================================================
        // 2. XỬ LÝ SỰ KIỆN CLICK
        //=============================================================

        // Click nút "Chọn" ở dgvMonHoc
        private void DgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Kiểm tra còn trong thời gian đăng ký không
            if (!KiemTraTrongThoiGianDangKy())
            {
                MessageBox.Show("Đã hết thời gian đăng ký!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra có phải click vào cột button không
            if (dgvMonHoc.Columns[e.ColumnIndex].Name == "btnCol")
            {
                string maMH = dgvMonHoc.Rows[e.RowIndex].Cells["MaHP"].Value?.ToString();
                if (!string.IsNullOrEmpty(maMH))
                {
                    LoadLopHocPhan(maMH);
                }
            }
        }

        // Load danh sách lớp học phần của môn được chọn
        private void LoadLopHocPhan(string maMH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        lhp.MaLHP,
                        lhp.MaLichHoc,
                        gv.HoTen AS TenGV,
                        lhp.SiSoToiDa,
                        COUNT(dkhp.MaSV) AS SoSVDangKy,
                        (lhp.SiSoToiDa - COUNT(dkhp.MaSV)) AS SoChoTrong
                    FROM LOP_HOC_PHAN lhp
                    LEFT JOIN GIANG_VIEN gv ON lhp.MaGV = gv.MaGV
                    LEFT JOIN DANG_KY_HOC_PHAN dkhp ON lhp.MaLHP = dkhp.MaLHP
                    WHERE lhp.MaMH = @MaMH 
                      AND lhp.MaHocKy = @MaHocKy
                      AND lhp.DaHuy = 0
                    GROUP BY lhp.MaLHP, lhp.MaLichHoc, gv.HoTen, lhp.SiSoToiDa
                    HAVING (lhp.SiSoToiDa - COUNT(dkhp.MaSV)) > 0
                    ORDER BY lhp.MaLHP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvLopHocPhan.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvLopHocPhan.Rows.Add(
                        row["MaLHP"],
                        row["MaLichHoc"],
                        row["TenGV"],
                        row["SoChoTrong"],
                        "Đăng ký"
                    );
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lớp học phần nào còn chỗ trống!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Click nút "Đăng ký" ở dgvLopHocPhan
        private void DgvLopHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Kiểm tra có phải click vào cột button không
            if (dgvLopHocPhan.Columns[e.ColumnIndex].Name == "btnDangKy")
            {
                string maLHP = dgvLopHocPhan.Rows[e.RowIndex].Cells["MaLHP"].Value?.ToString();
                if (!string.IsNullOrEmpty(maLHP))
                {
                    DangKyLopHocPhan(maLHP);
                }
            }
        }

        // Click vào giỏ hàng để hủy đăng ký
        private void DgvDaDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Kiểm tra còn trong thời gian đăng ký không
            if (!KiemTraTrongThoiGianDangKy())
            {
                MessageBox.Show("Đã hết thời gian đăng ký/hủy đăng ký!\n" +
                                "Không thể hủy đăng ký ngoài thời gian quy định.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMH = dgvDaDangKy.Rows[e.RowIndex].Cells["TenMon"].Value?.ToString();
            string maLHP = dgvDaDangKy.Rows[e.RowIndex].Cells["NameLHP"].Value?.ToString();

            if (!string.IsNullOrEmpty(maLHP))
            {
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn hủy đăng ký môn '{tenMH}'?",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    HuyDangKy(maLHP);
                }
            }
        }

        private void dgvDaDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Giữ nguyên để tương thích với designer
        }

        //=============================================================
        // 3. ĐĂNG KÝ LỚP HỌC PHẦN
        //=============================================================

        private void DangKyLopHocPhan(string maLHP)
        {
            // Bước 1: Kiểm tra đã đăng ký lớp này chưa
            if (KiemTraDaDangKy(maLHP))
            {
                MessageBox.Show("Bạn đã đăng ký lớp học phần này rồi!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 2: Kiểm tra đã đăng ký môn này chưa (không cho đăng ký 2 lớp cùng môn)
            if (KiemTraDaDangKyMonNay(maLHP))
            {
                MessageBox.Show("Bạn đã đăng ký một lớp học phần khác của môn học này rồi!\n" +
                                "Không thể đăng ký 2 lớp cùng một môn trong cùng học kỳ.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 3: Kiểm tra trùng lịch
            string lopTrungLich = KiemTraTrungLich(maLHP);
            if (!string.IsNullOrEmpty(lopTrungLich))
            {
                MessageBox.Show($"Trùng lịch với lớp: {lopTrungLich}",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 4: Kiểm tra còn chỗ trống
            if (!KiemTraConCho(maLHP))
            {
                MessageBox.Show("Lớp học phần đã hết chỗ!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 5: Kiểm tra môn tiên quyết
            string monChuaHoc = KiemTraMonTienQuyet(maLHP);
            if (!string.IsNullOrEmpty(monChuaHoc))
            {
                MessageBox.Show($"Bạn chưa hoàn thành môn tiên quyết: {monChuaHoc}",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 6: Kiểm tra giới hạn tín chỉ
            int soTinChiMon = LaySoTinChiMonHoc(maLHP);
            int tongTinChiHienTai = LayTongTinChiHienTai();

            if (tongTinChiHienTai + soTinChiMon > MAX_TIN_CHI)
            {
                MessageBox.Show($"Vượt quá giới hạn {MAX_TIN_CHI} tín chỉ/học kỳ!\n" +
                                $"Hiện tại: {tongTinChiHienTai} TC\n" +
                                $"Sau khi đăng ký: {tongTinChiHienTai + soTinChiMon} TC",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 7: Thực hiện đăng ký
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert vào DANG_KY_HOC_PHAN
                    string queryDK = @"
                        INSERT INTO DANG_KY_HOC_PHAN (MaSV, MaLHP, NgayDangKy, TrangThaiDangKy)
                        VALUES (@MaSV, @MaLHP, GETDATE(), N'Đăng ký thành công')";

                    SqlCommand cmdDK = new SqlCommand(queryDK, conn, transaction);
                    cmdDK.Parameters.AddWithValue("@MaSV", maSV);
                    cmdDK.Parameters.AddWithValue("@MaLHP", maLHP);
                    cmdDK.ExecuteNonQuery();

                    // Insert vào LICH_SU_DANG_KY
                    string queryLS = @"
                        INSERT INTO LICH_SU_DANG_KY (MaSV, MaLHP, ThoiGian, HanhDong, GhiChu)
                        VALUES (@MaSV, @MaLHP, GETDATE(), N'Đăng ký', N'Đăng ký thành công')";

                    SqlCommand cmdLS = new SqlCommand(queryLS, conn, transaction);
                    cmdLS.Parameters.AddWithValue("@MaSV", maSV);
                    cmdLS.Parameters.AddWithValue("@MaLHP", maLHP);
                    cmdLS.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Đăng ký thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh giao diện
                    LoadDanhSachDaDangKy();
                    TinhTongTinChi();
                    dgvLopHocPhan.Rows.Clear();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //=============================================================
        // 4. HỦY ĐĂNG KÝ
        //=============================================================

        private void HuyDangKy(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa khỏi DANG_KY_HOC_PHAN
                    string queryXoa = @"
                        DELETE FROM DANG_KY_HOC_PHAN
                        WHERE MaSV = @MaSV AND MaLHP = @MaLHP";

                    SqlCommand cmdXoa = new SqlCommand(queryXoa, conn, transaction);
                    cmdXoa.Parameters.AddWithValue("@MaSV", maSV);
                    cmdXoa.Parameters.AddWithValue("@MaLHP", maLHP);
                    cmdXoa.ExecuteNonQuery();

                    // Ghi log vào LICH_SU_DANG_KY
                    string queryLS = @"
                        INSERT INTO LICH_SU_DANG_KY (MaSV, MaLHP, ThoiGian, HanhDong, GhiChu)
                        VALUES (@MaSV, @MaLHP, GETDATE(), N'Hủy đăng ký', N'Sinh viên hủy đăng ký')";

                    SqlCommand cmdLS = new SqlCommand(queryLS, conn, transaction);
                    cmdLS.Parameters.AddWithValue("@MaSV", maSV);
                    cmdLS.Parameters.AddWithValue("@MaLHP", maLHP);
                    cmdLS.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Hủy đăng ký thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh giao diện
                    LoadDanhSachDaDangKy();
                    TinhTongTinChi();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi hủy đăng ký: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //=============================================================
        // 5. CÁC HÀM KIỂM TRA ĐIỀU KIỆN
        //=============================================================

        // Kiểm tra đã đăng ký lớp này chưa
        private bool KiemTraDaDangKy(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) 
                    FROM DANG_KY_HOC_PHAN
                    WHERE MaSV = @MaSV AND MaLHP = @MaLHP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Kiểm tra đã đăng ký môn này chưa (cùng môn, khác lớp)
        private bool KiemTraDaDangKyMonNay(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN LOP_HOC_PHAN lhp1 ON dkhp.MaLHP = lhp1.MaLHP
                    INNER JOIN LOP_HOC_PHAN lhp2 ON lhp1.MaMH = lhp2.MaMH
                    WHERE dkhp.MaSV = @MaSV 
                      AND lhp2.MaLHP = @MaLHP
                      AND lhp1.MaHocKy = @MaHocKy
                      AND dkhp.TrangThaiDangKy = N'Đăng ký thành công'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Kiểm tra trùng lịch
        private string KiemTraTrungLich(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 lhp1.MaLHP
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN LOP_HOC_PHAN lhp1 ON dkhp.MaLHP = lhp1.MaLHP
                    INNER JOIN LOP_HOC_PHAN lhp2 ON lhp1.MaLichHoc = lhp2.MaLichHoc
                    WHERE dkhp.MaSV = @MaSV 
                      AND lhp2.MaLHP = @MaLHP
                      AND lhp1.MaHocKy = @MaHocKy
                      AND dkhp.TrangThaiDangKy = N'Đăng ký thành công'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }

        // Kiểm tra còn chỗ trống
        private bool KiemTraConCho(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT lhp.SiSoToiDa - COUNT(dkhp.MaSV) AS SoChoTrong
                    FROM LOP_HOC_PHAN lhp
                    LEFT JOIN DANG_KY_HOC_PHAN dkhp ON lhp.MaLHP = dkhp.MaLHP
                    WHERE lhp.MaLHP = @MaLHP
                    GROUP BY lhp.SiSoToiDa";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return false;

                int soChoTrong = Convert.ToInt32(result);
                return soChoTrong > 0;
            }
        }

        // Kiểm tra môn tiên quyết
        private string KiemTraMonTienQuyet(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT mh2.TenMH
                    FROM LOP_HOC_PHAN lhp
                    INNER JOIN MON_HOC mh1 ON lhp.MaMH = mh1.MaMH
                    INNER JOIN MON_HOC mh2 ON mh1.MaMonTienQuyet = mh2.MaMH
                    WHERE lhp.MaLHP = @MaLHP
                      AND mh2.MaMH NOT IN (
                          SELECT DISTINCT lhp2.MaMH
                          FROM DANG_KY_HOC_PHAN dkhp
                          INNER JOIN LOP_HOC_PHAN lhp2 ON dkhp.MaLHP = lhp2.MaLHP
                          INNER JOIN KET_QUA_HOC_PHAN kq ON dkhp.MaSV = kq.MaSV 
                                                        AND dkhp.MaLHP = kq.MaLHP
                          WHERE dkhp.MaSV = @MaSV
                            AND kq.DiemTB >= 4.5
                      )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }

        // Lấy số tín chỉ của môn học
        private int LaySoTinChiMonHoc(string maLHP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT mh.SoTinChi
                    FROM LOP_HOC_PHAN lhp
                    INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                    WHERE lhp.MaLHP = @MaLHP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLHP", maLHP);

                object result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
        }

        // Lấy tổng tín chỉ hiện tại
        private int LayTongTinChiHienTai()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(SUM(mh.SoTinChi), 0)
                    FROM DANG_KY_HOC_PHAN dkhp
                    INNER JOIN LOP_HOC_PHAN lhp ON dkhp.MaLHP = lhp.MaLHP
                    INNER JOIN MON_HOC mh ON lhp.MaMH = mh.MaMH
                    WHERE dkhp.MaSV = @MaSV 
                      AND lhp.MaHocKy = @MaHocKy
                      AND dkhp.TrangThaiDangKy = N'Đăng ký thành công'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHocKy", maHocKyHienTai);

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}