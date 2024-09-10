using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLLN
{
    public partial class MoneyNVForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-S3844LJ\\MOULSAN;Initial Catalog=QLNH_LauNuong_BTN18;Integrated Security=True;TrustServerCertificate=True";

        public MoneyNVForm()
        {
            InitializeComponent();
            InitializeListView();
        }

        private bool isHdMode = true; // Biến xác định trạng thái hiện tại của nút

        private void InitializeListView()
        {
            // Xóa tất cả các cột trước khi thêm cột mới
            listView1.Columns.Clear();

            // Thiết lập ListView để hiển thị chi tiết
            listView1.View = View.Details;

            if (isHdMode)
            {
                // Thêm các cột cho ListView khi hiển thị Hóa Đơn
                listView1.Columns.Add("Mã Hóa Đơn", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Mã Khách Hàng", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Ngày", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Tổng Tiền", 150, HorizontalAlignment.Left);
            }
            else
            {
                // Thêm các cột cho ListView khi hiển thị Chi Tiết Hóa Đơn
                listView1.Columns.Add("Mã Chi Tiết Hóa Đơn", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Mã Hóa Đơn", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Mã Món Ăn", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Số Lượng", 150, HorizontalAlignment.Left);
                listView1.Columns.Add("Mã Nhân Viên", 150, HorizontalAlignment.Left);
            }
        }

        private void btnHd_Click(object sender, EventArgs e)
        {
            isHdMode = true; // Đặt trạng thái hiện tại là hiển thị Hóa Đơn
            InitializeListView(); // Cập nhật giao diện
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM HoaDon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ma_hoa_don"].ToString());
                            item.SubItems.Add(reader["ma_khach_hang"].ToString());
                            item.SubItems.Add(reader["ngay"].ToString());
                            item.SubItems.Add(reader["tong_tien"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            isHdMode = false; // Đặt trạng thái hiện tại là hiển thị Chi Tiết Hóa Đơn
            InitializeListView(); // Cập nhật giao diện
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM ChiTietHoaDon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ma_chi_tiet_hoa_don"].ToString());
                            item.SubItems.Add(reader["ma_hoa_don"].ToString());
                            item.SubItems.Add(reader["ma_mon_an"].ToString());
                            item.SubItems.Add(reader["so_luong"].ToString());
                            item.SubItems.Add(reader["ma_nhan_vien"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }



        }
}
