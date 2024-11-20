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
using login_and_register_page.Views;

namespace login_and_register_page.Views
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void viewBook_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new newBookUC());
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new newBookUC());
        }

        private void upBook_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new newBookUC());
        }

        private void LoadUserControl(UserControl userControl)
        {
            var parentWindow = Window.GetWindow(this);
            if (parentWindow is MainWindow mainWindow)
            {
                mainWindow.Content = userControl; // Replace main content
            }
            else
            {
                MessageBox.Show("Unable to load the user control. Parent window not found.");
            }
        }
    }
}
