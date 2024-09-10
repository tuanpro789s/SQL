using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLLN
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            // Handle form load event if needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            // Handle label click event if needed
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (ValidateLogin(username, password, out string role))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RedirectUser(role);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
        }

        private bool ValidateLogin(string username, string password, out string role)
        {
            role = string.Empty;
            string connectionString = "Data Source=DESKTOP-S3844LJ\\MOULSAN;Initial Catalog=QLNH_LauNuong_BTN18;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        role = reader["Role"].ToString();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private void RedirectUser(string role)
        {
            switch (role)
            {
                case "NhanVienPhucVu":
                    // Redirect to NhanVienPhucVu form
                    NhanVienPhucVuForm nvForm = new NhanVienPhucVuForm();
                    nvForm.Show();
                    break;
                case "AdminQTV":
                    // Redirect to Admin form
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    break;
                case "moneyNV":
                    // Redirect to ThuNgan form
                    MoneyNVForm tnForm = new MoneyNVForm();
                    tnForm.Show();
                    break;
                default:
                    MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            this.Hide(); // Hide login form after successful login
        }
    }
}