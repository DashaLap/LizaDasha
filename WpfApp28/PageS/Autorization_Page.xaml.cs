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
using WpfApp28.Windows;

namespace WpfApp28.PageS
{
    /// <summary>
    /// Логика взаимодействия для Autorization_Page.xaml
    /// </summary>
    public partial class Autorization_Page : Page
    {
        public Autorization_Page()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuEmploeesWindow menuEmploeeWindow = new MenuEmploeesWindow(); 
            menuEmploeeWindow.Show();
        }

        private void btnLoginReader_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationChitatel());
        }
    }
}
