using System;
using System.Windows;
using System.Windows.Controls;

namespace login_and_register_page
{
    public partial class AdminloginWindow : Window
    {
        public AdminloginWindow ()
        {
            InitializeComponent();
        }

        // Event handler for the Login button
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            // Here, you would add the logic to validate the admin login
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Example logic: Check if the username and password match predefined values
            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Login successful!");
                // Add your navigation logic here
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        // Event handler for Forgot Password link click
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotpasswordWindow forgotpasswordWindow = new ForgotpasswordWindow();
            forgotpasswordWindow.Show();
            this.Close();
            
        }
    }
}
