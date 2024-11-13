using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace login_and_register_page
{
    public partial class Userprofile : Window
    {
        public Userprofile()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

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

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool UpdateUserProfile(string username, string email, string password)
        {
            return true; // Placeholder for actual update logic
        }
    }
}
