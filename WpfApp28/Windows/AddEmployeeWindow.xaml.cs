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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void SaveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader();
            reader.Surname=SurnameTb.Text.Trim();
            reader.Name=NameTb.Text.Trim();
            reader.Middle_name=Middle_nameTb.Text.Trim();
            reader.Birthdate=BirthDateDp.SelectedDate;
            reader.Phone=PhoneTb.Text.Trim();
            reader.isDelete=false;
            Connection2.bibl_DsrymarEntities.Reader.Add(reader);
            Connection2.bibl_DsrymarEntities.SaveChanges();
            MessageBox.Show("Читатель успешно добавлен.");
            Close();


        }
    }
}
