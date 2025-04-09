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
using WpfApp28.NewFolder1;

namespace WpfApp28.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReaderTicketWindow.xaml
    /// </summary>
    public partial class AddReaderTicketWindow : Window
    { public static List<Reader> readers {  get; set; }
        public static List<Employee> employees { get; set; }

        public AddReaderTicketWindow()
        {
            InitializeComponent();
            readers=new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i=>i.isDelete==false).ToList());
            employees=new List<Employee>(Connection2.bibl_DsrymarEntities.Employee.Where(i=>i.isDelete==false).ToList());
            this.DataContext = this;
        }

        private void SaveTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            ReadTicket readTicket = new ReadTicket();
            readTicket.isDelete = false;
            readTicket.Date_Registr=DateTime.Now;
            var reader = ReaderCm.SelectedItem as Reader;
            readTicket.ID_Reader = reader.ID;
            var employee = EmployeeCm.SelectedItem as Employee;
            readTicket.ID_Employee= employee.ID;
            Connection2.bibl_DsrymarEntities.ReadTicket.Add(readTicket);
            Connection2.bibl_DsrymarEntities.SaveChanges();
            MessageBox.Show("Новый билет добавлен.");
            Close();
        }

        private void AddReaderTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddReaderTicketWindow addReaderTicketWindow = new Windows.AddReaderTicketWindow();
            addReaderTicketWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ReaderCm.ItemsSource=new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i=>i.isDelete==false).ToList());
        }
    }
}
