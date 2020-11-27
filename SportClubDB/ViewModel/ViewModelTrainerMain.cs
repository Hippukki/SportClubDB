using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportClubDB
{
    public class ViewModelTrainerMain : BaseNotifyClass
    {
        public Frame frame; 

        public SimpleCommand OpenClients { get; set; }
        public SimpleCommand OpenCreateClient { get; set; }
        public SimpleCommand OpenEditTrainer { get; set; }
        public SimpleCommand OpenSchedule { get; set; }

        public ViewModelTrainerMain( Frame frame, object user)
        {
            this.frame = frame;
            OpenClients = new SimpleCommand(() =>
            {
                frame.Navigate(new ClientsDataGrid());
            });

            OpenCreateClient = new SimpleCommand(() =>
            {
                frame.Navigate(new CreateClientPage(new ViewModelAddClient(new Client())));
            });

            OpenEditTrainer = new SimpleCommand(() =>
            {
                frame.Navigate(new TrainerProfilePage());
            });

            OpenSchedule = new SimpleCommand(() =>
            {
                frame.Navigate(new TrainerSchedulePage());
            });

        }
    
    }
}
