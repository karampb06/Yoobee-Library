using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Grid_View_filter_demo
{
    public partial class MainWindow : Window
    {
        List<Book> books;
        public MainWindow()
        {
            InitializeComponent();

            // Read the CSV file
            var lines = File.ReadAllLines(@"C:\Users\FTael\OneDrive - UP Education\Documents\BSE Y1 - 2024\CS106 INTEGRATED STUDIO II\Grid View filter demo\Book(Sheet1).csv");

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

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
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
