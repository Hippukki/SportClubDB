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
        Trainer trainer;
        public SimpleCommand OpenClients { get; set; }
        public SimpleCommand OpenCreateClient { get; set; }
        public SimpleCommand OpenEditTrainer { get; set; }
        public SimpleCommand OpenMySchedule { get; set; }
        public Page CurrentPage { get => currentPage; set { currentPage = value; RaiseProperty(); } }

        public ViewModelTrainerMain( Trainer trainer)
        {
            this.trainer = trainer;
            OpenClients = new SimpleCommand(() =>
            {
                CurrentPage = new ClientsDataGrid(new ViewModelClientsList(trainer));
            });

            OpenCreateClient = new SimpleCommand(() =>
            {
                CurrentPage = new CreateClientPage(new ViewModelAddClient(new Client(), trainer));
            });

            OpenEditTrainer = new SimpleCommand(() =>
            {
                 CurrentPage = new TrainerProfilePage(new ViewModelEditTrainer(trainer));
            });

            OpenMySchedule = new SimpleCommand(() =>
            {
                 CurrentPage = new TrainerSchedulePage();
            });

        }
    
    }
}
