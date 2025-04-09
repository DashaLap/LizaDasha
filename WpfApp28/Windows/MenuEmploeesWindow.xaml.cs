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
using WpfApp28.PageS;

namespace WpfApp28.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuEmploeesWindow.xaml
    /// </summary>
    public partial class MenuEmploeesWindow : Window
    {
        public MenuEmploeesWindow()
        {
            InitializeComponent();
        }

        private void btnReader_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new ReaderPages());
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new Book());
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
