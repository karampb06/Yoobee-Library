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

        // Event handler for the "Register" button click
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsernameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Text;
            string confirmPassword = RegisterConfirmPasswordBox.Text;

            // Basic validation for the fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Here, you can add further logic to save the user data to a database or file
            MessageBox.Show("Registration successful!");
        }

        // Event handler for when the RegisterUsernameTextBox gains focus
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "Enter Username" || textBox.Text == "Enter Email address" || textBox.Text == "Enter Password" || textBox.Text == "Confirm Password")
                {
                    textBox.Clear();
                    textBox.Foreground = System.Windows.Media.Brushes.Black;
                }
            }
        }

        // Event handler for when the RegisterUsernameTextBox loses focus
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Foreground = System.Windows.Media.Brushes.Gray;

                    // Default text based on the TextBox
                    if (textBox.Name == "RegisterUsernameTextBox")
                        textBox.Text = "Enter Username";
                    else if (textBox.Name == "RegisterEmailTextBox")
                        textBox.Text = "Enter Email address";
                    else if (textBox.Name == "RegisterPasswordBox")
                        textBox.Text = "Enter Password";
                    else if (textBox.Name == "RegisterConfirmPasswordBox")
                        textBox.Text = "Confirm Password";
                }
            }
        }

        // Event handler for the "Forgot password?" link
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Password recovery page (not implemented).");
        }
    }
}
