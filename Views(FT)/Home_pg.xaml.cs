using Home.Views;
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

namespace login_and_register_page.Views_FT_
{
    /// <summary>
    /// Interaction logic for Home_pg.xaml
    /// </summary>
    public partial class Home_pg : Window
    {
        public Home_pg()
        {
            InitializeComponent();
            this.DataContext= this;
        }

        //ADMIN WINDOW
        private void Admin_click(object sender, RoutedEventArgs e)
        {
            Adminlogin newWindow = new Adminlogin();
            newWindow.Show();
        }

        //MEMBER WINDOW
        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        //BOOK CATALOG WINDOW
        private void BookCatalog_Click(object sender, RoutedEventArgs e)
        {
            Book_Catalog newWindow = new Book_Catalog();
            newWindow.Show();
        }




        //MORE DETAILS ABOUT BOOK WINDOW!
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            More_detailswin newWindow =  new More_detailswin();
            newWindow.Show();
        }

    
    }
}
