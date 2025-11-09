using System;
using System.Windows.Forms;

namespace UngdungQuanliDangkiHocphan
{
    public partial class UC_QLHocKi : UserControl
    {
        public UC_QLHocKi()
        {
            InitializeComponent();
            this.Load += UC_QLHocKi_Load;
        }

        private void UC_QLHocKi_Load(object sender, EventArgs e)
        {
            // Tạm thời chưa load data, chỉ setup UI
            // Có thể thêm style nhẹ nếu muốn
            dgvHocKi.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvHocKi.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            btnThemHocKi.Left = this.Width - btnThemHocKi.Width - 25;
            btnThemHocKi.Top = 25;
        }

        private void btnThemHocKi_Click(object sender, EventArgs e)
        {
            // Mở form thêm học kỳ mới (sẽ tạo sau)
            using (FormThemHocKi f = new FormThemHocKi())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
            }
        }
    }
}
