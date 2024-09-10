using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLLN
{
    public partial class AdminForm : Form
    {
        // Kết nối cơ sở dữ liệu
        private string connectionString = "Data Source=DESKTOP-S3844LJ\\MOULSAN;Initial Catalog=QLNH_LauNuong_BTN18;Integrated Security=True;TrustServerCertificate=True";

        public AdminForm()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // Set the view to show details
            listView1.View = View.Details;

            // Add columns
            listView1.Columns.Add("Mã Danh Mục", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Tên Danh Mục", 250, HorizontalAlignment.Left);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các ô nhập liệu không trống
            if (!string.IsNullOrEmpty(txtMDM.Text) && !string.IsNullOrEmpty(txtTDM.Text))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DanhMuc (ma_danh_muc, ten_danh_muc) VALUES (@MaDM, @TenDM)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDM", txtMDM.Text);
                        cmd.Parameters.AddWithValue("@TenDM", txtTDM.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Thêm dữ liệu vào ListView
                ListViewItem item = new ListViewItem(txtMDM.Text);
                item.SubItems.Add(txtTDM.Text);
                listView1.Items.Add(item);

                // Sau khi thêm, xóa dữ liệu trong các ô nhập liệu
                txtMDM.Text = "";
                txtTDM.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục.", "Thông báo");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đã chọn một mục trong ListView
            if (listView1.SelectedItems.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DanhMuc SET ma_danh_muc = @MaDM, ten_danh_muc = @TenDM WHERE ma_danh_muc = @OldMaDM";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        ListViewItem selectedItem = listView1.SelectedItems[0];
                        string oldMaDM = selectedItem.SubItems[0].Text;

                        cmd.Parameters.AddWithValue("@MaDM", txtMDM.Text);
                        cmd.Parameters.AddWithValue("@TenDM", txtTDM.Text);
                        cmd.Parameters.AddWithValue("@OldMaDM", oldMaDM);
                        cmd.ExecuteNonQuery();

                        // Cập nhật lại ListView
                        selectedItem.SubItems[0].Text = txtMDM.Text;
                        selectedItem.SubItems[1].Text = txtTDM.Text;

                        // Sau khi sửa, xóa dữ liệu trong các ô nhập liệu
                        txtMDM.Text = "";
                        txtTDM.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông báo");
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ma_danh_muc, ten_danh_muc FROM DanhMuc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ma_danh_muc"].ToString());
                            item.SubItems.Add(reader["ten_danh_muc"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                txtMDM.Text = selectedItem.SubItems[0].Text;
                txtTDM.Text = selectedItem.SubItems[1].Text;
            }
        }
    }
}