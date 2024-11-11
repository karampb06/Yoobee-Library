using System;
using System.Windows;

namespace login_and_register_page
{
    public partial class ForgotpasswordWindow : Window
    {
        public ForgotpasswordWindow()
        {
            InitializeComponent();
        }

        // Event handler for the "Submit" button click
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for handling the password reset or submission
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;
            string confirmPassword = ConfirmLoginPasswordBox.Password;

            // Validate fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Check if password and confirm password match
            if (password == confirmPassword)
            {
                // Proceed with further logic, e.g., update password in database
                MessageBoxResult result = MessageBox.Show("Password reset successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Once the user clicks OK on the message box, close the current window (Forgot password window)
                if (result == MessageBoxResult.OK)
                {
                    MainWindow(); // Open the login window
                    this.Close();  // Close the forgot password window
                     
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Open the login window (MainWindow)
        private void MainWindow()
        {
            MainWindow MainWindow  = new MainWindow();
            MainWindow.Show();  // Show the login window
        }
    }
}
