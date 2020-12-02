using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelClientsList : BaseNotifyClass
    {
        Client client;
        public ObservableCollection<Client> clients { get; set; }

        public SimpleCommand Search { get; set; }
        public ViewModelClientsList(Trainer trainer)
        {
            client = new Client();
            clients = new ObservableCollection<Client>(client.GetClientsByTrainer(trainer.ID));
        }
    }
}
