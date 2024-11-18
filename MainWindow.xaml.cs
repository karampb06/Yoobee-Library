
using System.Windows;

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
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            // Basic login validation (replace with your actual authentication logic)
            if (ValidateCredentials(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the Home page
               // Home_pg newWindow = new Home_pg();
              //  newWindow.Show();

                // Close the current login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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