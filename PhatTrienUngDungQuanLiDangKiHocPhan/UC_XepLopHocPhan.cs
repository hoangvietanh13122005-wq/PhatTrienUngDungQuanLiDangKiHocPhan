using PhatTrienUngDungQuanLiDangKiHocPhan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhatTrienUngDungQuanLiDangKiHocPhan
{
    public partial class UC_XepLopHocPhan : UserControl
    {
        private TableLayoutPanel tblLich;
        private DateTimePicker dtpNgay;
        private Panel legendPanel;
        private TableLayoutPanel mainLayout;
        private Panel infoPanel;
        private TextBox txtMaLHP, txtTenHP, txtGiangVien, txtSiSo, txtPhong, txtCa;
        private DateTimePicker dtpBatDau, dtpKetThuc;
        private Button btnLuu;

        // Danh sách lưu các lớp theo phòng – ca – tuần
        private Dictionary<string, List<(DateTime tuanBatDau, DateTime tuanKetThuc)>> lichTheoPhongCa = new Dictionary<string, List<(DateTime tuanBatDau, DateTime tuanKetThuc)>>();
        private readonly Color mauTrong = Color.White;
        private readonly Color mauChon = Color.Khaki;
        private readonly Color mauCoLop = Color.LightGreen;

        public UC_XepLopHocPhan()
        {
            InitializeComponent();
            this.Load += UC_XepLopHocPhan_Load;
        }

        private void UC_XepLopHocPhan_Load(object sender, EventArgs e)
        {
            BuildUI();
        }

        private void BuildUI()
        {
            this.BackColor = Color.WhiteSmoke;
            this.Controls.Clear();

            // === Layout chính chia 2 phần ===
            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            this.Controls.Add(mainLayout);

            // === BÊN TRÁI ===
            Panel leftPanel = new Panel { Dock = DockStyle.Fill };
            mainLayout.Controls.Add(leftPanel, 0, 0);

            // Bộ chọn ngày (trên cùng)
            dtpNgay = new DateTimePicker
            {
                Dock = DockStyle.Top,
                Format = DateTimePickerFormat.Short,
                Height = 30
            };
            leftPanel.Controls.Add(dtpNgay);

            // Chú thích màu (dưới cùng)
            legendPanel = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            legendPanel.Controls.Add(CreateLegendItem("Chưa có lớp", mauTrong, 0));
            legendPanel.Controls.Add(CreateLegendItem("Đang chọn", mauChon, 1));
            legendPanel.Controls.Add(CreateLegendItem("Đã có lớp", mauCoLop, 2));
            leftPanel.Controls.Add(legendPanel);

            // Bảng lưới (fill phần giữa)
            tblLich = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };
            leftPanel.Controls.Add(tblLich);
            leftPanel.Controls.SetChildIndex(tblLich, 1); // đặt giữa picker và legend

            // === Cấu hình bảng lưới ===
            string[] thu = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            string[] tiet = { "12", "34", "56", "78" };
            var danhSachCa = thu.SelectMany(t => tiet.Select(ti => t + ti)).ToList();

            int soCot = danhSachCa.Count + 1;
            int soHang = 20 + 1;
            int cellSize = 45;

            tblLich.ColumnCount = soCot;
            tblLich.RowCount = soHang;

            for (int i = 0; i < soCot; i++)
                tblLich.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));

            for (int j = 0; j < soHang; j++)
                tblLich.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));

            // Hàng tiêu đề
            tblLich.Controls.Add(new Label { Text = "", BackColor = Color.LightGray, Dock = DockStyle.Fill }, 0, 0);
            for (int c = 1; c < soCot; c++)
            {
                Label lbl = new Label
                {
                    Text = danhSachCa[c - 1],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.LightGray,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold)
                };
                tblLich.Controls.Add(lbl, c, 0);
            }

            // Phòng học
            var danhSachPhong = Enumerable.Range(1, 4)
                .SelectMany(t => Enumerable.Range(1, 5).Select(p => $"{t}0{p}"))
                .ToList();

            // compute Monday of week shown in dtpNgay
            DateTime refDate = dtpNgay.Value.Date;
            int diffToMon = ((int)refDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime startOfWeek = refDate.AddDays(-diffToMon); // Monday

            for (int r = 1; r <= danhSachPhong.Count; r++)
            {
                Label lblPhong = new Label
                {
                    Text = danhSachPhong[r - 1],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold)
                };
                tblLich.Controls.Add(lblPhong, 0, r);

                for (int c = 1; c < soCot; c++)
                {
                    // determine weekday index from danhSachCa entry (T2..T7, CN)
                    string caTag = danhSachCa[c - 1];
                    string dayCode = caTag.StartsWith("CN") ? "CN" : caTag.Substring(0, 2);
                    int dayIndex = 0;
                    switch (dayCode)
                    {
                        case "T2": dayIndex = 0; break;
                        case "T3": dayIndex = 1; break;
                        case "T4": dayIndex = 2; break;
                        case "T5": dayIndex = 3; break;
                        case "T6": dayIndex = 4; break;
                        case "T7": dayIndex = 5; break;
                        case "CN": dayIndex = 6; break;
                    }
                    DateTime dateForColumn = startOfWeek.AddDays(dayIndex);

                    Button btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = mauTrong,
                        Margin = new Padding(0),
                        FlatStyle = FlatStyle.Flat,
                        // Tag now includes room, ca and a date (yyyy-MM-dd) so LayNgayTuButton can parse it
                        Tag = $"{danhSachPhong[r - 1]}-{danhSachCa[c - 1]}-{dateForColumn:yyyy-MM-dd}"
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += Btn_Click;
                    tblLich.Controls.Add(btn, c, r);
                }
            }

            // === BÊN PHẢI: Bảng thông tin lớp ===
            infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15),
                BackColor = Color.White
            };
            mainLayout.Controls.Add(infoPanel, 1, 0);

            Label lblTitle = new Label
            {
                Text = "Thông tin lớp học phần",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40
            };
            infoPanel.Controls.Add(lblTitle);
            // === Nút Quay lại (góc trên bên phải) ===
            Button btnQuayLai = new Button
            {
                Text = "← Quay lại",
                Width = 100,
                Height = 30,
                Top = 5,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnQuayLai.FlatAppearance.BorderSize = 0;
            btnQuayLai.Left = infoPanel.Width - btnQuayLai.Width - 10;

            // Xử lý sự kiện khi nhấn nút
            btnQuayLai.Click += BtnQuayLai_Click;

            // Thêm vào infoPanel
            infoPanel.Controls.Add(btnQuayLai);
            btnQuayLai.BringToFront();

            // Đảm bảo cập nhật vị trí khi panel resize
            infoPanel.Resize += (s, e) =>
            {
                btnQuayLai.Left = infoPanel.Width - btnQuayLai.Width - 10;
            };


            int y = 60;
            txtMaLHP = AddTextField(infoPanel, "Mã lớp học phần:", ref y);
            txtTenHP = AddTextField(infoPanel, "Tên học phần:", ref y);
            txtGiangVien = AddTextField(infoPanel, "Giảng viên:", ref y);
            txtSiSo = AddTextField(infoPanel, "Sĩ số tối đa:", ref y);
            txtPhong = AddTextField(infoPanel, "Phòng học:", ref y);
            txtPhong.ReadOnly = true;
            txtCa = AddTextField(infoPanel, "Ca học:", ref y);
            txtCa.ReadOnly = true;

            Label lblBatDau = new Label { Text = "Ngày bắt đầu:", Top = y, Left = 10, AutoSize = true };
            dtpBatDau = new DateTimePicker { Top = y + 20, Left = 10, Width = 220, Format = DateTimePickerFormat.Short };
            y += 60;

            Label lblKetThuc = new Label { Text = "Ngày kết thúc:", Top = y, Left = 10, AutoSize = true };
            dtpKetThuc = new DateTimePicker { Top = y + 20, Left = 10, Width = 220, Format = DateTimePickerFormat.Short };
            y += 60;

            infoPanel.Controls.Add(lblBatDau);
            infoPanel.Controls.Add(dtpBatDau);
            infoPanel.Controls.Add(lblKetThuc);
            infoPanel.Controls.Add(dtpKetThuc);

            btnLuu = new Button
            {
                Text = "Lưu thông tin",
                Width = 180,
                Height = 35,
                Top = y + 10,
                Left = 10,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat

            };
            btnLuu.FlatAppearance.BorderSize = 0;
            infoPanel.Controls.Add(btnLuu);
            btnLuu.Click += BtnLuu_Click;
        }

        private TextBox AddTextField(Panel parent, string label, ref int top)
        {
            Label lbl = new Label { Text = label, Top = top, Left = 10, AutoSize = true };
            TextBox txt = new TextBox { Top = top + 20, Left = 10, Width = 220 };
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
            top += 60;
            return txt;
        }

        private void UC_XepLopHocPhan_Load_1(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn.BackColor == mauTrong)
                btn.BackColor = mauChon;
            else if (btn.BackColor == mauChon)
                btn.BackColor = mauTrong;

            ShowInfo(btn.Tag.ToString());
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string phong = txtPhong.Text.Trim();
            string ca = txtCa.Text.Trim();
            string key = $"{phong}-{ca}";
            DateTime batDau = dtpBatDau.Value.Date;
            DateTime ketThuc = dtpKetThuc.Value.Date;

            // Nếu không nhập đủ thông tin => xem như xóa lớp
            bool isEmpty = string.IsNullOrWhiteSpace(txtMaLHP.Text)
                        && string.IsNullOrWhiteSpace(txtTenHP.Text)
                        && string.IsNullOrWhiteSpace(txtGiangVien.Text);

            if (isEmpty)
            {
                if (lichTheoPhongCa.ContainsKey(key))
                    lichTheoPhongCa.Remove(key);

                foreach (Control c in tblLich.Controls)
                {
                    if (c is Button btn && btn.Tag.ToString().StartsWith(key))
                        btn.BackColor = mauTrong;
                }

                MessageBox.Show("Đã xóa lớp khỏi lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật danh sách tuần cho phòng-ca này
            if (!lichTheoPhongCa.ContainsKey(key))
                lichTheoPhongCa[key] = new List<(DateTime, DateTime)>();

            lichTheoPhongCa[key].Clear();
            lichTheoPhongCa[key].Add((batDau, ketThuc));

            // Tô màu các ô tương ứng trong khoảng tuần
            foreach (Control c in tblLich.Controls)
            {
                if (c is Button btn && btn.Tag.ToString().StartsWith(key))
                {
                    DateTime tuan = LayNgayTuButton(btn);
                    if (tuan >= batDau && tuan <= ketThuc)
                        btn.BackColor = mauCoLop;
                    else
                        btn.BackColor = mauTrong;
                }
            }

            MessageBox.Show("Đã lưu thông tin lớp học phần!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (Control c in tblLich.Controls)
            {
                if (c is Button btn && btn.Tag.ToString().StartsWith(key))
                {
                    DateTime tuan = LayNgayTuButton(btn);
                    if (tuan >= batDau && tuan <= ketThuc)
                        btn.BackColor = mauCoLop;
                }
            }
        }
        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            // Giả sử UC này nằm trong Form cha có panelMain chứa các UserControl
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                // Tìm panel chính chứa UC
                var panelMain = parentForm.Controls.Find("panelMain", true).FirstOrDefault();
                if (panelMain != null)
                {
                    panelMain.Controls.Clear();
                    var ucQLLopHocPhan = new UC_QLLopHocPhan(); // tạo lại UC gốc
                    ucQLLopHocPhan.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(ucQLLopHocPhan);
                }
            }
        }


        private void ShowInfo(string tag)
        {
            string[] parts = tag.Split('-');
            if (parts.Length < 2) return;

            txtMaLHP.Text = $"LHP-{parts[0]}-{parts[1]}";
            txtTenHP.Text = "Nhập tên học phần...";
            txtGiangVien.Text = "";
            txtSiSo.Text = "50";
            txtPhong.Text = parts[0];
            txtCa.Text = parts[1];
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now.AddMonths(4);
        }

        private Panel CreateLegendItem(string text, Color color, int index)
        {
            Panel panel = new Panel { Location = new Point(index * 160, 5), Size = new Size(150, 30) };
            Panel colorBox = new Panel
            {
                BackColor = color,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(20, 20),
                Location = new Point(0, 5)
            };
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(30, 5),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            panel.Controls.Add(colorBox);
            panel.Controls.Add(lbl);
            return panel;
        }

        /// <summary>
        /// Lấy ngày đại diện cho tuần từ Button trong bảng lịch.
        /// Ở đây giả định mỗi hàng là một phòng, mỗi cột là một ca.
        /// Trả về ngày đầu tuần (thứ 2) của tuần hiện tại.
        /// </summary>
        private DateTime LayNgayTuButton(Button btn)
        {
            // Giả sử Tag của nút giờ có dạng: "101-T212-2025-10-26"
            // tách lấy phần cuối cùng là ngày tuần (năm-tháng-ngày)
            string[] parts = btn.Tag.ToString().Split('-');
            if (parts.Length >= 4)
            {
                // explicit indices (C# 7.3 compatible)
                string year = parts[parts.Length - 3];
                string month = parts[parts.Length - 2];
                string day = parts[parts.Length - 1];
                DateTime ngay;
                if (DateTime.TryParse($"{year}-{month}-{day}", out ngay))
                    return ngay;
            }

            // Nếu không có thông tin ngày, trả về ngày hôm nay để tránh lỗi
            return DateTime.Today;
        }

    }
}
