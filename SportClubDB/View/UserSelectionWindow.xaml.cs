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

namespace SportClubDB
{
    /// <summary>
    /// Логика взаимодействия для UserSelectionWindow.xaml
    /// </summary>
    public partial class UserSelectionWindow : Window
    {
        LogInPage page;
        public UserSelectionWindow(LogInPage page)
        {
            InitializeComponent();
            this.page = page;
        }

        private void IsAdmin(object sender, RoutedEventArgs e)
        {
            page.NavigationService.Navigate(new SingUpPage(new ViewModelAddAdmin()));
            Close();
        }

        private void IsTrainer(object sender, RoutedEventArgs e)
        {
            page.NavigationService.Navigate(new SingUpPage(new ViewModelAddTrainer()));
            Close();
        }
    }
}
