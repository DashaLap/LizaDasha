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
using System.Runtime.Remoting.Messaging;
using WpfApp28.NewFolder1;
using System.Data.Common;


namespace WpfApp28.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditReadersBtn.xaml
    /// </summary>
    public partial class EditReadersBtn : Window
    {
        public static Reader reader1 = new Reader();
        public EditReadersBtn(Reader reader)
        {
            InitializeComponent();
            reader1 = reader ;
            LastNameTb.Text = reader1.Surname;
            NameTb.Text = reader1.Name;
            PatronymicTb.Text = reader1.Middle_name;
            BirthDateDp.SelectedDate = reader1.Birthdate;
            PhoneTb.Text = reader1.Phone;
            this.DataContext = this;
        }

        private void SaveEditBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите изменить читателя {reader1.Surname} {reader1.Name} ?", "Удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                reader1.Surname = LastNameTb.Text;
                reader1.Name = NameTb.Text;
                reader1.Middle_name = PatronymicTb.Text;
                reader1.Birthdate = BirthDateDp.SelectedDate;
                reader1.Phone = PhoneTb.Text;
                Connection2.bibl_DsrymarEntities.SaveChanges();
                ReadersListWindow readersListWindow = new ReadersListWindow();
                readersListWindow.ReadersLv.ItemsSource = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.isDelete == false).ToList());
            }
            MessageBox.Show("Читатель успешно изменен");
            Close();
        }
    }
}
