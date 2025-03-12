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

namespace WpfApp28
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            newFrame.NavigationService.Navigate(new PageS.Autorization_Page());
        }
    }
     public class Connection
    {
        public static Bibl_dsrymarEntities bibliotrq = new Bibl_dsrymarEntities();
    }
}
