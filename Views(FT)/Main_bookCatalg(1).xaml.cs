using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
    /// Interaction logic for Main_bookCatalg_1_.xaml
    /// </summary>
    public partial class Main_bookCatalg_1_ : Window
    {
        List<Book> books;
        public Main_bookCatalg_1_()
        {
            InitializeComponent();

            // Read the CSV file
            var lines = File.ReadAllLines(@"""C:\Users\FTael\OneDrive - UP Education\Documents\BSE Y1 - 2024\CS106 INTEGRATED STUDIO II\clone\Models\Book(Sheet1).csv");

            books = new List<Book>();

            // Skip the first header line
            for (var i = 1; i < lines.Length; i++)
            {
                // Split each line into array of string
                var line = lines[i].Split(',');

                // Create new book and add to the book list
                books.Add(new Book { Book_Title = line[0], Book_Author = line[1] });
            }

            booksList.ItemsSource = books;
        }

        //class for SearchBar control - (user enters)
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {                           //Query - LINQ 
            booksList.ItemsSource = (from b in books
                                     where !(b.Book_Title.IndexOf(searchBar.Text, StringComparison.OrdinalIgnoreCase) < 0 &&
                                             b.Book_Author.IndexOf(searchBar.Text, StringComparison.OrdinalIgnoreCase) < 0)
                                     select b).ToList();
        }
    }

    public class Book
    {
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
    }
}

