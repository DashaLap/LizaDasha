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
using WpfApp28.NewFolder1;


namespace WpfApp28.PageS
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        public static List<Book_1> books { get; set; }
        public static List<Author> authors { get; set; }
        public Book()
        {
            InitializeComponent();
            books = new List<Book_1>(Connection2.bibl_DsrymarEntities.Book_1.ToList());
            authors = new List<Author>(Connection2.bibl_DsrymarEntities.Author.
                Where(i => i.isDelete == false).ToList());
            authors.Insert(0, new Author() { ID = -1, Surname = "Вывести всех" });
            this.DataContext = this;
        }

        private void BookSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = BookSearchTb.Text.Trim();
            if (search == "")
                BookLv.ItemsSource = books.ToList();
            else
                BookLv.ItemsSource=books.Where(i=>i.ID.ToString()==search).ToList();
        }

        private void FiltrAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = FiltrAuthor.SelectedItem as Book_1;
            if (t.ID!=-1)
                BookLv.ItemsSource=books.Where(i=>i.ID==t.ID).ToList();
            else
                BookLv.ItemsSource=books.ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
