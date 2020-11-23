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
    /// Логика взаимодействия для TrainerMainPage.xaml
    /// </summary>
    public partial class TrainerMainPage : Page
    {
        public TrainerMainPage()
        {
            InitializeComponent();
        }

        private void OpenClientsDataGrid(object sender, RoutedEventArgs e)
        {
            SecondaryFrame.Navigate(new ClientsDataGrid());
        }

        private void OpenTrainerProfilePage(object sender, RoutedEventArgs e)
        {
            SecondaryFrame.Navigate(new TrainerProfilePage());
        }

        private void OpenTrainerSchedulePage(object sender, RoutedEventArgs e)
        {
            SecondaryFrame.Navigate(new TrainerSchedulePage());
        }
    }
}
