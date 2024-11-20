using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace login_and_register_page
{
    public partial class Userprofile : Window
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\106.2 practice\\login and register page\\Aucklandlibrary.mdf\";Integrated Security=True;Connect Timeout=30"; // Set your database connection string here

        public Userprofile()
        {
            InitializeComponent();
            LoadUserProfile();
        }

        // Load the current user profile details when the profile page is opened
        private void LoadUserProfile()
        {
            try
            {
                // Assuming we have a user ID that identifies the logged-in user, you need to fetch it dynamically
                int userId = 5; // Replace this with the actual user ID (you may store it in a session or context)

                string query = "SELECT UserName, Email FROM Users WHERE Id = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UsernameTextBox.Text = reader["UserName"].ToString();
                                EmailTextBox.Text = reader["Email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("User not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading user data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Go back to the main login page
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        // Update user profile when the Update button is clicked
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (UpdateUserProfile(username, email, password))
            {
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Validate email format
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Update user profile in the database
        private bool UpdateUserProfile(string username, string email, string password)
        {
            try
            {
                // Hash the password before storing it
                string hashedPassword = HashPassword(password);

                // Assuming we have the user ID from the current session or context
                int userId = 5; // Replace with actual user ID

                string query = "UPDATE Users SET UserName = @UserName, Email = @Email, Password = @Password WHERE Id = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.Parameters.AddWithValue("@UserId", userId);

                        int result = command.ExecuteNonQuery();
                        return result > 0; // If rows were affected, the update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating user data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Logout functionality: Show the login page and close the user profile page
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        // Method to hash the password (SHA256 in this case)
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

            //Navigate to the Home page
          //  Home_pg newWindow = new Home_pg();
           //newWindow.Show();

           //  Close the current  window
            //this.Close();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
