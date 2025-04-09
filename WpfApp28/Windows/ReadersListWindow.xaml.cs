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
using System.Windows.Shapes;
using WpfApp28.NewFolder1;


namespace WpfApp28
{
    /// <summary>
    /// Логика взаимодействия для ReadersListWindow.xaml
    /// </summary>
    public partial class ReadersListWindow : Window
    {
        public static List<Reader> readers { get; set; }
        public ReadersListWindow()
        {
            InitializeComponent();
            readers = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.isDelete == false).ToList());
            this.DataContext = this;
        }

        private void SearchReadersTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var phone = SearchReadersTb.Text;
            if (phone == "")
                ReadersLv.ItemsSource = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.isDelete == false).ToList());
            else
                ReadersLv.ItemsSource = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.Phone == phone && i.isDelete == false).ToList());
        }

        private void BirthDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = BirthDateDp.SelectedDate;
            ReadersLv.ItemsSource = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.Birthdate >= date && i.isDelete == false).ToList());
        }

        private void DeleteReadreBtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = ReadersLv.SelectedItem as Reader;
            if (reader != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить читателя {reader.Surname} {reader.Name} ?", "Удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    reader.isDelete = true;
                    Connection2.bibl_DsrymarEntities.SaveChanges();
                    ReadersLv.ItemsSource = new List<Reader>(Connection2.bibl_DsrymarEntities.Reader.Where(i => i.isDelete == false).ToList());
                }
            }
            else
            {
                MessageBox.Show("Вы никого не выбрали.");
            }
        }

        private void EditReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = ReadersLv.SelectedItem as Reader;
            if (reader != null)
            {
                Windows.EditReadersBtn editReaderWindow = new Windows.EditReadersBtn(reader); //Случайно назвала EditReaderBtn, у вас скорее всего называется EditReaderWindow, не путайтесь
                editReaderWindow.Show();

            }
            else
            {
                MessageBox.Show("Для редактирования выберите читателя");
            }
        }

    }
    }

