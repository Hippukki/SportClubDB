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
        private Page currentPage;

        public SimpleCommand OpenClients { get; set; }
        public SimpleCommand OpenCreateClient { get; set; }
        public SimpleCommand OpenEditTrainer { get; set; }
        public SimpleCommand OpenSchedule { get; set; }
        public Page CurrentPage { get => currentPage; set { currentPage = value; RaiseProperty(); } }

        public ViewModelTrainerMain( object user)
        {
            user = new Trainer();
            OpenClients = new SimpleCommand(() =>
            {
                CurrentPage = new ClientsDataGrid();
            });

            OpenCreateClient = new SimpleCommand(() =>
            {
                CurrentPage = new CreateClientPage(new ViewModelAddClient(new Client()));
            });

            OpenEditTrainer = new SimpleCommand(() =>
            {
                 CurrentPage = new TrainerProfilePage();
            });

            OpenSchedule = new SimpleCommand(() =>
            {
                 CurrentPage = new TrainerSchedulePage();
            });

        }
    
    }
}
