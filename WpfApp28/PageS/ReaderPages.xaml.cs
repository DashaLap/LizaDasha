using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для ReaderPages.xaml
    /// </summary>
    public partial class ReaderPages : Page
    {
        public static List<ReadTicket> readersTicket {  get; set; }
        public static List<Employee> employees { get; set; }
        public ReaderPages()
        {
            InitializeComponent();
            readersTicket=new List<ReadTicket>(Connection2.bibl_DsrymarEntities.ReadTicket.
                Where(i=>i.Reader.isDelete==false && i.isDelete == false).ToList());
            employees=new List<Employee>(Connection2.bibl_DsrymarEntities.Employee.
                 Where(i => i.isDelete == false).ToList());
            employees.Insert(0, new Employee() { ID = -1, Surname = "Вывести всех" });
            this.DataContext = this;
        }
      
        private void TicketSearchTb_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim();
            if (search == "")
                ReadersLv.ItemsSource = readersTicket.ToList();
            else
                ReadersLv.ItemsSource = readersTicket.Where(i => i.ID.ToString() == search).ToList();
        }

        private void FiltrEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var t = FiltrEmployee.SelectedItem as Employee;
            if (t.ID != -1)
                ReadersLv.ItemsSource = readersTicket.Where(i => i.ID == t.ID).ToList();
            else
                ReadersLv.ItemsSource = readersTicket.ToList();
        }

        private void AddReaderTicket_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddReaderTicketWindow addReaderTicketWindow = new Windows.AddReaderTicketWindow();
            addReaderTicketWindow.Show();
        }
    }
}
