using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using login_and_register_page.Views_kj_;


namespace login_and_register_page.Views_kj_
{
    /// <summary>
    /// Interaction logic for Adminlogin.xaml
    /// </summary>
    public partial class Adminlogin : Window
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        // Event handler for the Login button
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Attempt to log in
            if (ValidateAdminLogin(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Navigate to the admin dashboard or next window
                //AdminDashboardWindow adminDashboard = new AdminDashboardWindow();
                //adminDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Validates admin login by checking credentials in the database.
        /// </summary>
        private bool ValidateAdminLogin(string username, string password)
        {
            bool isValid = false;

            // Connection string (replace with your actual connection details)
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\106.2 practice\\login and register page\\Aucklandlibrary.mdf\";Integrated Security=True;Connect Timeout=30";

            // SQL query to validate the admin credentials
            string query = " SELECT 1 FROM Admins WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameterized queries to the avoid SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", (password)); // Hash password before checking

                        // Execute the query
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        isValid = count == 1; // Login is valid if count is 1
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while accessing the database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isValid;
        }

        /// <summary>
        /// Hashes a password using SHA256.
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Event handler for Forgot Password link click
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Forgotpassword forgotpasswordWindow = new Forgotpassword();
            forgotpasswordWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the login window (MainWindow)
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            // Close the current window
            this.Close();
        }

    }
}
