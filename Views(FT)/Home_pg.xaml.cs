﻿using Home.Views;
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
        

        //MEMBER WINDOW


        //BOOK CATALOG WINDOW
        private void BookCatalog_Click(object sender, RoutedEventArgs e)
        {
            Book_Catalog newWindow = new Book_Catalog();
            newWindow.Show();
        }

        //BOOK CHECKOUT WINDOW 
        private void BookCheckout_Click(object sender, RoutedEventArgs e)
        {
            Book_Checkout newWindow = new Book_Checkout();
            newWindow.Show();
        }


        //MORE DETAILS ABOUT BOOK WINDOW!
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            More_detailswin newWindow = More_detailswin();
            newWindow.Show();
        }

    
    }
}