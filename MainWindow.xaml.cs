using System;
using System.Windows;
using System.Windows.Controls;

namespace login_and_register_page
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Handle the 'GotFocus' event for the Login Username TextBox
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginUsernameTextBox.Text == "Enter Username / Email:")
            {
                LoginUsernameTextBox.Text = "";
                LoginUsernameTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Handle the 'LostFocus' event for the Login Username TextBox
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUsernameTextBox.Text))
            {
                LoginUsernameTextBox.Text = "Enter Username / Email:";
                LoginUsernameTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Handle the Login Button Click Event
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Text;

            // For this example, we will just check if the username and password are not empty.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if login credentials are valid (you can replace this with actual validation logic)
            if (username == "user@example.com" && password == "password123")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // You can navigate to another window or perform additional actions here.
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Handle the Forgot Password link Click Event
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Redirecting to Forgot Password page...", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Information);
            // Redirect the user to the Forgot Password page or logic here.
        }
    }
}
