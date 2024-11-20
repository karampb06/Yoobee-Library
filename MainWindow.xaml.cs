
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace login_and_register_page
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Login button
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Get username and password from input fields
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            // Validate credentials against the database
            if (ValidateCredentialsFromDatabase(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Navigate to the Home page
                // Home_pg newWindow = new Home_pg();
                // newWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Validates the user's credentials by checking the database.
        /// </summary>
        /// <param name="username">The entered username</param>
        /// <param name="password">The entered password</param>
        /// <returns>True if credentials are valid, otherwise false</returns>
        private bool ValidateCredentialsFromDatabase(string username, string password)
        {
            bool isValid = false;

            // Database connection string (replace with your actual connection string)
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\106.2 practice\\login and register page\\Aucklandlibrary.mdf\";Integrated Security=True;Connect Timeout=30";

            // SQL query to retrieve user credentials
            string query = "SELECT Password FROM Users WHERE UserName = @UserName";

            try
            {
                // Connect to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@UserName", username);

                        // Execute the query and read the result
                        object dbPassword = command.ExecuteScalar();

                        if (dbPassword != null)
                        {
                            // Hash the entered password and compare it to the stored password
                            string hashedPassword = HashPassword(password); // Hashing the entered password
                            if (hashedPassword == dbPassword.ToString()) // Replace with proper hashing comparison
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while accessing the database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isValid;
        }

        // Hashes a password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Simple validation for demo purposes, replace this with actual authentication logic
        private bool ValidateCredentials(string username, string password)
        {
            // Example hardcoded credentials, replace with your actual authentication
            return username == "User" && password == "Password";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Your code for handling the button click event
            MessageBox.Show("Button clicked!");
        }

        // Event handler for the Register button to open the registration page
        private void RegisterAccount_Click(object sender, RoutedEventArgs e)
        {
            // Open the registration window
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        // Event handler for the "Back" button click
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {

            // Open the Adminlogin window (Admin login)

            AdminloginWindow loginWindow = new AdminloginWindow();
            loginWindow.Show();
            // Close the forgot password window
            this.Close();
        }

        // Event handler for Forgot password link
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {

            ForgotpasswordWindow forgotpasswordWindow = new ForgotpasswordWindow();
            forgotpasswordWindow.Show();
            this.Close();


        }
    }
}