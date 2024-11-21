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
using System.Windows.Navigation;
using System.Windows.Shapes;
using login_and_register_page.Views;

namespace login_and_register_page.Views
{
    /// <summary>
    /// Interaction logic for newMemberUC.xaml
    /// </summary>
    public partial class newMemberUC : UserControl
    {
        public newMemberUC()
        {
            InitializeComponent();
        }

        // Event handler for Add Member button
        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Logic to add the member 
            MessageBox.Show($"Member '{name}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the form
            ClearForm();
        }

        // Event handler for Update Member button
        private void UpdateMember_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Logic to update the member (e.g., database update)
            MessageBox.Show($"Member '{name}' updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally clear the form
            ClearForm();
        }

        // Utility method to clear the form fields
        private void ClearForm()
        {
            NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            UsernameTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }
    }
}
