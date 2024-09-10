using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLLN
{
    public partial class NhanVienPhucVuForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-S3844LJ\\MOULSAN;Initial Catalog=QLNH_LauNuong_BTN18;Integrated Security=True;TrustServerCertificate=True";

        public NhanVienPhucVuForm()
        {
            InitializeComponent();
        }

        private void btnSum_MA_Click(object sender, EventArgs e)
        {
            CalculateTotalMonAn();
        }

        private void btnSum_Hd_Click(object sender, EventArgs e)
        {
            CalculateTotalHoaDon();
        }

        private void CalculateTotalMonAn()
        {
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) AS TotalMonAn FROM MonAn";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int totalMonAn = (int)cmd.ExecuteScalar();
                    ListViewItem item = new ListViewItem("Tổng Số Món Ăn");
                    item.SubItems.Add(totalMonAn.ToString());
                    listView1.Items.Add(item);
                }
            }
        }

        private void CalculateTotalHoaDon()
        {
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) AS TotalHoaDon FROM HoaDon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int totalHoaDon = (int)cmd.ExecuteScalar();
                    ListViewItem item = new ListViewItem("Tổng Số Hóa Đơn");
                    item.SubItems.Add(totalHoaDon.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
}
