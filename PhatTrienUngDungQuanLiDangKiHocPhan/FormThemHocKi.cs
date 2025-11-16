using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UngdungQuanliDangkiHocphan
{
    public partial class FormThemHocKi : Form
    {
        // adjust connection string if needed or read from config
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";
        private bool _isEdit = false;
        private string _maHocKyEdit;

        public FormThemHocKi()
        {
            InitializeComponent();
            // default: add mode
            btnThem.Text = "Thêm học kỳ";
            ClearForm();
        }

        // New constructor: edit mode
        public FormThemHocKi(string maHocKy) : this()
        {
            if (string.IsNullOrWhiteSpace(maHocKy)) return;
            _isEdit = true;
            _maHocKyEdit = maHocKy;
            btnThem.Text = "Lưu";
            LoadHocKyToForm(maHocKy);
        }

        private void ClearForm()
        {
            cboTenHocKi.SelectedIndex = -1;
            cboTenHocKi.Text = "";
            txtNamHoc.Text = "";
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;
            dtpMoDangKy.Value = DateTime.Today;
            dtpDongDangKy.Value = DateTime.Today;
        }

        private static string NormalizeYearRange(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "";
            // Remove "Năm học" prefix if present
            var s = input.Trim();
            if (s.StartsWith("Năm học", StringComparison.InvariantCultureIgnoreCase))
                s = s.Substring("Năm học".Length).Trim();

            // Normalize different dash characters to ASCII hyphen
            var dashChars = new[] { '\u2013', '\u2014', '\u2212', '–', '—' };
            foreach (var d in dashChars) s = s.Replace(d, '-');

            // Replace any non-digit/non-hyphen with nothing except preserve digits and hyphen
            // Keep spaces around hyphen trimmed
            s = s.Replace(" ", "");

            // allow formats like 2024-2025 or 2024/2025 (convert / to -)
            s = s.Replace("/", "-");

            // Now expect exactly one '-' between two 4-digit years
            var parts = s.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return "";

            if (parts[0].Length == 4 && parts[1].Length == 4
                && int.TryParse(parts[0], out int start)
                && int.TryParse(parts[1], out int end)
                && end == start + 1)
            {
                return $"{parts[0]}-{parts[1]}";
            }

            return "";
        }

        private void LoadHocKyToForm(string maHocKy)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"
                    SELECT h.MaHocKy, h.TenHocKy, n.TenNamHoc, n.MaNamHoc, h.NgayBatDau, h.NgayKetThuc, h.NgayBatDauDK, h.NgayKetThucDK
                    FROM HOC_KY h
                    LEFT JOIN NAM_HOC n ON h.MaNamHoc = n.MaNamHoc
                    WHERE h.MaHocKy = @ma", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maHocKy);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            var tenHocKy = rdr["TenHocKy"]?.ToString();
                            var tenNam = rdr["TenNamHoc"]?.ToString();

                            // Try to match DB value to one of the combo items (case-insensitive contains / exact)
                            if (!string.IsNullOrWhiteSpace(tenHocKy))
                            {
                                int idx = -1;
                                for (int i = 0; i < cboTenHocKi.Items.Count; i++)
                                {
                                    var item = cboTenHocKi.Items[i].ToString();
                                    if (string.Equals(item, tenHocKy, StringComparison.OrdinalIgnoreCase)
                                        || item.ToLowerInvariant().Contains(tenHocKy.Trim().ToLowerInvariant())
                                        || tenHocKy.Trim().ToLowerInvariant().Contains(item.ToLowerInvariant()))
                                    {
                                        idx = i;
                                        break;
                                    }
                                }

                                if (idx >= 0) cboTenHocKi.SelectedIndex = idx;
                                else cboTenHocKi.SelectedIndex = -1; // keep DropDownList behavior
                            }
                            else
                            {
                                cboTenHocKi.SelectedIndex = -1;
                            }

                            // Year textbox: normalize to yyyy-yyyy
                            var normalizedYear = NormalizeYearRange(tenNam);
                            txtNamHoc.Text = string.IsNullOrEmpty(normalizedYear) ? "" : normalizedYear;

                            // Dates
                            dtpNgayBatDau.Value = rdr["NgayBatDau"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayBatDau"]) : DateTime.Today;
                            dtpNgayKetThuc.Value = rdr["NgayKetThuc"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayKetThuc"]) : DateTime.Today;
                            dtpMoDangKy.Value = rdr["NgayBatDauDK"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayBatDauDK"]) : DateTime.Today;
                            dtpDongDangKy.Value = rdr["NgayKetThucDK"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayKetThucDK"]) : DateTime.Today;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Now btnThem acts as Add or Save depending on mode
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate semester selection
            var tenHocKiSelection = cboTenHocKi.SelectedItem?.ToString() ?? cboTenHocKi.Text;
            if (string.IsNullOrWhiteSpace(tenHocKiSelection))
            {
                MessageBox.Show("Vui lòng chọn tên học kỳ (ví dụ: Học kỳ 1, Học kỳ 2 hoặc Học kỳ hè).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Normalize year input (accept "Năm học 2024–2025", "2024/2025", "2024-2025")
            var namTextRaw = txtNamHoc.Text?.Trim();
            var namText = NormalizeYearRange(namTextRaw);
            if (string.IsNullOrEmpty(namText))
            {
                MessageBox.Show("Định dạng năm học không hợp lệ. Dùng định dạng YYYY-YYYY (ví dụ: 2024-2025).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // parse years after normalization
            var parts = namText.Split('-');
            int startYear = int.Parse(parts[0]);
            int endYear = int.Parse(parts[1]);

            string twoYearPair = $"{(startYear % 100):D2}{(endYear % 100):D2}";
            string simpleName = tenHocKiSelection; // use combo selection as canonical semester name
            string hkPrefix = simpleName.Contains("1") ? "HK1" : simpleName.Contains("2") ? "HK2" : "HKH";
            string maHocKy = $"{hkPrefix}_{twoYearPair}";
            string tenHocKy = $"{simpleName} năm {namText}";

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
            DateTime ngayBatDauDK = dtpMoDangKy.Value.Date;
            DateTime ngayKetThucDK = dtpDongDangKy.Value.Date;

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // ensure NAM_HOC exists (or update as earlier logic)
                        string maNamHoc = $"NH{(startYear % 100):D2}{(endYear % 100):D2}";
                        using (var cmdCheckNam = new SqlCommand("SELECT NgayBatDau, NgayKetThuc FROM NAM_HOC WHERE MaNamHoc = @ma", conn, tran))
                        {
                            cmdCheckNam.Parameters.AddWithValue("@ma", maNamHoc);
                            using (var rdr = cmdCheckNam.ExecuteReader())
                            {
                                if (rdr.Read())
                                {
                                    DateTime existingStart = rdr["NgayBatDau"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayBatDau"]) : ngayBatDau;
                                    DateTime existingEnd = rdr["NgayKetThuc"] != DBNull.Value ? Convert.ToDateTime(rdr["NgayKetThuc"]) : ngayKetThuc;
                                    rdr.Close();

                                    DateTime newStart = existingStart < ngayBatDau ? existingStart : ngayBatDau;
                                    DateTime newEnd = existingEnd > ngayKetThuc ? existingEnd : ngayKetThuc;

                                    if (newStart != existingStart || newEnd != existingEnd)
                                    {
                                        using (var cmdUpdateNam = new SqlCommand("UPDATE NAM_HOC SET NgayBatDau=@s, NgayKetThuc=@e WHERE MaNamHoc=@ma", conn, tran))
                                        {
                                            cmdUpdateNam.Parameters.AddWithValue("@s", newStart);
                                            cmdUpdateNam.Parameters.AddWithValue("@e", newEnd);
                                            cmdUpdateNam.Parameters.AddWithValue("@ma", maNamHoc);
                                            cmdUpdateNam.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    rdr.Close();
                                    using (var cmdInsertNam = new SqlCommand("INSERT INTO NAM_HOC (MaNamHoc, TenNamHoc, NgayBatDau, NgayKetThuc) VALUES (@ma,@ten,@s,@e)", conn, tran))
                                    {
                                        cmdInsertNam.Parameters.AddWithValue("@ma", maNamHoc);
                                        cmdInsertNam.Parameters.AddWithValue("@ten", $"Năm học {startYear}–{endYear}");
                                        cmdInsertNam.Parameters.AddWithValue("@s", ngayBatDau < ngayBatDauDK ? ngayBatDau : ngayBatDauDK);
                                        cmdInsertNam.Parameters.AddWithValue("@e", ngayKetThuc);
                                        cmdInsertNam.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        if (_isEdit)
                        {
                            // update HOC_KY with _maHocKyEdit
                            using (var cmdUpdate = new SqlCommand(@"
                                UPDATE HOC_KY SET TenHocKy=@ten, MaNamHoc=@maNam, NgayBatDau=@nbd, NgayKetThuc=@nkt, NgayBatDauDK=@nbdDK, NgayKetThucDK=@nktDK
                                WHERE MaHocKy = @maHK", conn, tran))
                            {
                                cmdUpdate.Parameters.AddWithValue("@ten", tenHocKy);
                                cmdUpdate.Parameters.AddWithValue("@maNam", maNamHoc);
                                cmdUpdate.Parameters.AddWithValue("@nbd", ngayBatDau);
                                cmdUpdate.Parameters.AddWithValue("@nkt", ngayKetThuc);
                                cmdUpdate.Parameters.AddWithValue("@nbdDK", ngayBatDauDK);
                                cmdUpdate.Parameters.AddWithValue("@nktDK", ngayKetThucDK);
                                cmdUpdate.Parameters.AddWithValue("@maHK", _maHocKyEdit);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            tran.Commit();
                            MessageBox.Show("Cập nhật học kỳ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                        else
                        {
                            // insertion path
                            using (var cmdCheckHK = new SqlCommand("SELECT COUNT(1) FROM HOC_KY WHERE MaHocKy=@ma", conn, tran))
                            {
                                cmdCheckHK.Parameters.AddWithValue("@ma", maHocKy);
                                var exists = Convert.ToInt32(cmdCheckHK.ExecuteScalar()) > 0;
                                if (exists)
                                {
                                    tran.Rollback();
                                    MessageBox.Show($"Mã học kỳ {maHocKy} đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            using (var cmdInsert = new SqlCommand(@"
                                INSERT INTO HOC_KY (MaHocKy, TenHocKy, MaNamHoc, NgayBatDau, NgayKetThuc, NgayBatDauDK, NgayKetThucDK)
                                VALUES (@maHK,@ten,@maNam,@nbd,@nkt,@nbdDK,@nktDK)", conn, tran))
                            {
                                cmdInsert.Parameters.AddWithValue("@maHK", maHocKy);
                                cmdInsert.Parameters.AddWithValue("@ten", tenHocKy);
                                cmdInsert.Parameters.AddWithValue("@maNam", maNamHoc);
                                cmdInsert.Parameters.AddWithValue("@nbd", ngayBatDau);
                                cmdInsert.Parameters.AddWithValue("@nkt", ngayKetThuc);
                                cmdInsert.Parameters.AddWithValue("@nbdDK", ngayBatDauDK);
                                cmdInsert.Parameters.AddWithValue("@nktDK", ngayKetThucDK);
                                cmdInsert.ExecuteNonQuery();
                            }

                            tran.Commit();
                            MessageBox.Show($"Thêm học kỳ thành công: {maHocKy}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
