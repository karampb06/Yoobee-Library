using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace login_and_register_page.Views
{
    /// <summary>
    /// Interaction logic for newBookUC.xaml
    /// </summary>
    public partial class newBookUC : UserControl
    {
        public newBookUC()
        {
            InitializeComponent();

            InitializeComponent();

            TextUC nameText = makeText("Name");
            TextUC authorText = makeText("Author");
            TextUC PagesText = makeText("Pages");
            TextUC collectionText = makeText("Collection");
            Button addBookBtn = new Button(); addBookBtn.Height = 70; addBookBtn.Width = 200; addBookBtn.Content = "Submit"; addBookBtn.Click += (sender, e) =>
            submitBtn(nameText.Text, authorText.Text, PagesText.Text, collectionText.Text);
            setGrid(nameText, 2, newGrid);
            setGrid(authorText, 3, newGrid);
            setGrid(PagesText, 4, newGrid);
            setGrid(collectionText, 5, newGrid);
            Grid.SetRow(addBookBtn, 6);
            newGrid.Children.Add(addBookBtn);




        }


        public TextUC makeText(string placeholder)
        {
            return new TextUC
            {
                Height = 70,
                Width = 200,
                PlaceHolder = placeholder
            };
        }

        public void setGrid(TextUC UC, int row, Grid gridname)
        {
            Grid.SetRow(UC, row);
            gridname.Children.Add(UC);

        }

        void submitBtn(string name, string author, string pages, string collectionName)
        {
            string connectionString = "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;";

            string query = $@"
                 INSERT INTO {collectionName} 
                 (Name, Author, Pages, Available, Overdue, Time, Owner, PreBookOwner, Image) 
                 VALUES 
                 (@Name, @Author, @Pages, @Available, @Overdue, @Time, @Owner, @PreBookOwner, @Image);";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Author", author);
                        command.Parameters.AddWithValue("@Pages", pages);
                        command.Parameters.AddWithValue("@Available", "Yes");
                        command.Parameters.AddWithValue("@Overdue", "No");
                        command.Parameters.AddWithValue("@Time", 300);
                        command.Parameters.AddWithValue("@Owner", string.Empty);
                        command.Parameters.AddWithValue("@PreBookOwner", string.Empty);
                        command.Parameters.AddWithValue("@Image", "https://storage.googleapis.com/librarybookimages/ancient%20book%20placeholder.jpg");

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"{name} has been added to the library");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void newbookcloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
