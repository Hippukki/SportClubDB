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
        Phone phone;
        Client selectedClient; 

        public Client SelectedClient { get => selectedClient; set { selectedClient = value; RaiseProperty(); } }
        public ObservableCollection<Client> Clients { get; set; }

        public SimpleCommand Search { get; set; }
        public SimpleCommand Edit { get; set; }
        public SimpleCommand Delete { get; set; }
        public ViewModelClientsList(Trainer trainer)
        {
            client = new Client();
            Clients = new ObservableCollection<Client>(client.GetClientsByTrainer(trainer.ID));
            Converter();

            Edit = new SimpleCommand(() =>
            {
                new ClientEditWindow(new ViewModelEditClient(SelectedClient)).ShowDialog();
                Converter();
            });

            Delete = new SimpleCommand(() =>
            {
                SelectedClient.RemoveClient();
                Clients.Remove(SelectedClient);
            });
        }
        public void Converter()
        {
            foreach (Client client in Clients)
            {
                phone = new Phone();
                phone.Number = phone.GetNumberById(client.IdPhone);
                client.IdPhone = Convert.ToInt64(phone.Number);
            }
        }

    }
}
