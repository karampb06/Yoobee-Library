using System.Windows;

using System.Windows.Controls;

using System.Text.RegularExpressions;
namespace login_and_register_page
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsernameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Password;
            string confirmPassword = RegisterConfirmPasswordBox.Password;

            // Validate fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Attempt to register the user
            if (RegisterUser(username, email, password))
            {
                // Show success message
                MessageBoxResult result = MessageBox.Show("Registration successful! Do you want to log in now?", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // If the user clicks OK, open the login page and close the register window
                if (result == MessageBoxResult.OK)
                {
                    // Create the LoginWindow instance and show it
                    MainWindow loginWindow = new MainWindow();
                    loginWindow.Show();

                    // Close the current RegisterWindow
                    this.Close();
                }

                // Clear fields after successful registration
                RegisterUsernameTextBox.Clear();
                RegisterEmailTextBox.Clear();
                RegisterPasswordBox.Clear();
                RegisterConfirmPasswordBox.Clear();
            }
            else
            {
                // If registration fails, show an error message
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Event handler for the "Back" button click
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            // Create an instance of MainWindow and show it
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();

            // Close the Registration page
            this.Close();
        }

        private bool RegisterUser(string username, string email, string password)

        {

            // Placeholder for actual registration logic (e.g., saving to a database)

            return true;

        }

        private bool IsValidEmail(string email)

        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, emailPattern);

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)

        {

            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Foreground == System.Windows.Media.Brushes.Gray)

            {

                textBox.Text = "";

                textBox.Foreground = System.Windows.Media.Brushes.Black;

            }

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)

        {

            TextBox textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))

            {

                textBox.Foreground = System.Windows.Media.Brushes.Gray;

                if (textBox == RegisterUsernameTextBox)

                {

                    textBox.Text = "Enter User Name";

                }

                else if (textBox == RegisterEmailTextBox)

                {

                    textBox.Text = "Email Address";

                }

            }

        }

    }

}