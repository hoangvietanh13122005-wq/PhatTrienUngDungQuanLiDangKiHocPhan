using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_QLHocPhan : UserControl
    {
        private readonly string _connectionString = @"Data Source=DESKTOP-KGSNLET\SQLEXPRESS;Initial Catalog=QL_DangKyTinChi;Integrated Security=True";

        // ComboBox động (tạo mới)
        private ComboBox cboCTDTDynamic;

        public UC_QLHocPhan()
        {
            InitializeComponent();
            this.Load += UC_QLHocPhan_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            cboTimTheo.SelectedIndexChanged += CboTimTheo_SelectedIndexChanged;  // Sự kiện thay đổi loại tìm kiếm
        }

        private void UC_QLHocPhan_Load(object sender, EventArgs e)
        {
            InitializeSearchControls();  // Khởi tạo ComboBox động

            

            LoadMonHoc();
        }

        // KHỞI TẠO COMBOBOX ĐỘNG
        private void InitializeSearchControls()
        {
            // Tạo ComboBox cho tìm kiếm CTDT
            cboCTDTDynamic = new ComboBox();
            cboCTDTDynamic.Name = "cboCTDTDynamic";
            cboCTDTDynamic.DropDownStyle = ComboBoxStyle.DropDown;
            cboCTDTDynamic.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCTDTDynamic.Visible = false;

            // ĐẶT CÙNG VỊ TRÍ VỚI txtTuKhoa
            cboCTDTDynamic.Location = txtTuKhoa.Location;
            cboCTDTDynamic.Size = txtTuKhoa.Size;

            // Thêm vào Panel/Form
            txtTuKhoa.Parent.Controls.Add(cboCTDTDynamic);
        }

        //  SỰ KIỆN THAY ĐỔI LOẠI TÌM KIẾM
        private void CboTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = cboTimTheo.SelectedItem?.ToString();

            if (type == null)
            {
                txtTuKhoa.Visible = true;
                cboCTDTDynamic.Visible = false;
                return;
            }

            //  TÌM KIẾM THEO MÃ HOẶC TÊN → Hiển thị TextBox
            if (type.IndexOf("Mã", StringComparison.OrdinalIgnoreCase) >= 0 ||
                type.IndexOf("Tên", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                txtTuKhoa.Visible = true;
                cboCTDTDynamic.Visible = false;
                txtTuKhoa.Clear();
                txtTuKhoa.Focus();
            }
            //  TÌM KIẾM THEO CHƯƠNG TRÌNH ĐÀO TẠO → Hiển thị ComboBox
            else if (type.IndexOf("Chương trình", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                txtTuKhoa.Visible = false;
                txtTuKhoa.Enabled = false;  // Thêm dòng này
                cboCTDTDynamic.BringToFront(); // Đưa lên trên
                cboCTDTDynamic.Visible = true;
                cboCTDTDynamic.Focus();
                LoadChuongTrinhDaoTao();
            }
        }

        //  LOAD COMBOBOX CHƯƠNG TRÌNH ĐÀO TẠO
        private void LoadChuongTrinhDaoTao()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT MaCTDT, TenCTDT FROM CHUONG_TRINH_DAO_TAO ORDER BY TenCTDT", conn))
                {
                    conn.Open();
                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    cboCTDTDynamic.DataSource = table;
                    cboCTDTDynamic.DisplayMember = "TenCTDT";
                    cboCTDTDynamic.ValueMember = "MaCTDT";
                    cboCTDTDynamic.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chương trình đào tạo: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var type = cboTimTheo.SelectedItem?.ToString();
            string term = null;
            string maCTDT = null;

            //  LẤY DỮ LIỆU TỪ CONTROL PHÙ HỢP
            if (type != null && type.IndexOf("Chương trình", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                maCTDT = cboCTDTDynamic.SelectedValue?.ToString();
            }
            else
            {
                term = txtTuKhoa.Text?.Trim();
            }

            LoadMonHoc(type, term, maCTDT);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboTimTheo.SelectedIndex = -1;
            txtTuKhoa.Clear();
            cboCTDTDynamic.SelectedIndex = -1;
            txtTuKhoa.Visible = true;  // Hiển thị lại TextBox
            cboCTDTDynamic.Visible = false;
            LoadMonHoc();
        }

        private void LoadMonHoc(string filterType = null, string filterTerm = null, string maCTDT = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    StringBuilder sql = new StringBuilder(@"
                        SELECT DISTINCT
                            mh.MaMH, 
                            mh.TenMH, 
                            mh.SoTinChi, 
                            mtq.TenMH AS TenMonTienQuyet,
                            ctdt.TenCTDT
                        FROM MON_HOC mh
                        LEFT JOIN MON_HOC mtq ON mh.MaMonTienQuyet = mtq.MaMH
                        LEFT JOIN CTDT_MON_HOC cm ON mh.MaMH = cm.MaMH
                        LEFT JOIN CHUONG_TRINH_DAO_TAO ctdt ON cm.MaCTDT = ctdt.MaCTDT
                        WHERE 1=1");

                    //  LỌC THEO TỪ KHÓA
                    if (!string.IsNullOrWhiteSpace(filterType) && !string.IsNullOrWhiteSpace(filterTerm))
                    {
                        if (filterType.IndexOf("Mã", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            sql.Append(" AND mh.MaMH LIKE @term + '%'");
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                        else if (filterType.IndexOf("Tên", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            sql.Append(" AND mh.TenMH LIKE '%' + @term + '%'");
                            cmd.Parameters.AddWithValue("@term", filterTerm);
                        }
                    }

                    //  LỌC THEO CHƯƠNG TRÌNH ĐÀO TẠO
                    if (!string.IsNullOrWhiteSpace(maCTDT))
                    {
                        sql.Append(" AND ctdt.MaCTDT = @maCTDT");
                        cmd.Parameters.AddWithValue("@maCTDT", maCTDT);
                    }

                    sql.Append(" ORDER BY mh.MaMH");
                    cmd.CommandText = sql.ToString();

                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvHocPhan.AutoGenerateColumns = true;
                    dgvHocPhan.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học phần: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e) { }
        private void btnSua_Click(object sender, EventArgs e) { }
        private void btnXoa_Click(object sender, EventArgs e) { }
        private void btnLuu_Click(object sender, EventArgs e) { }
        private void btnHuy_Click(object sender, EventArgs e) { }
        private void panelTop_Paint(object sender, PaintEventArgs e) { }

    }
}