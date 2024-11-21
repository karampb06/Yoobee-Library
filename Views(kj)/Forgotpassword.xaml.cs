using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Forgotpassword.xaml
    /// </summary>
    public partial class Forgotpassword : Window
    {
        public Forgotpassword()
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

        // Event handler for the "Back" button click
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            // Open the login window (MainWindow)

            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            // Close the forgot password window
            this.Close();
        }






        // Open the login window (MainWindow)
        private void MainWindow()
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();  // Show the login window
        }

    }
}
