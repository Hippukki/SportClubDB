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

namespace SportClubDB
{
    /// <summary>
    /// Логика взаимодействия для SingUpPage.xaml
    /// </summary>
    public partial class SingUpPage : Page
    {
        public SingUpPage(object user)
        {
            InitializeComponent();
            DataContext = user;

        }

        private void CloseSingUpPage(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
