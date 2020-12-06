using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelClientsList : BaseNotifyClass
    {
        Client client;
        Client selectedClient;
        string selectedType;

        public string Request { get; set; }
        public List<string> types { get; set; }
        public Client SelectedClient { get => selectedClient; set { selectedClient = value; RaiseProperty(); } }
        public string SelectedType { get => selectedType; set { selectedType = value; RaiseProperty(); } }
        public ObservableCollection<Client> Clients { get; set; }

        public SimpleCommand Search { get; set; }
        public SimpleCommand Edit { get; set; }
        public SimpleCommand Delete { get; set; }
        public ViewModelClientsList(Trainer trainer)
        {
            client = new Client();
            Clients = new ObservableCollection<Client>(client.GetClientsByTrainer(trainer.ID));
            Converter();

            types = new List<string>()
            {
                "Имя",
                "Фамилия",
                "Отчество"
            };

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
            Search = new SimpleCommand(() =>
            {
                if (Request != null)
                {
                    List<Client> clients = new List<Client>();
                    switch (SelectedType)
                    {
                        case "Имя":
                            foreach (Client client in Clients)
                            {
                                if (client.Name == Request)
                                {
                                    clients.Add(client);
                                }
                            }break;
                        case "Фамилия":
                            foreach (Client client in Clients)
                            {
                                if (client.Surname == Request)
                                {
                                    clients.Add(client);
                                }
                            }break;
                        case "Отчество":
                            foreach (Client client in Clients)
                            {
                                if (client.Lastname == Request)
                                {
                                    clients.Add(client);
                                }
                            }break;
                    }
                    GetSearchResult(clients);
                }
                else
                    MessageBox.Show("Пожалуйста, введите запрос в поле поиска!");
            });
        }
        public void Converter()
        {
            foreach (Client client in Clients)
            {
                Phone phone = new Phone();
                phone.Number = phone.GetNumberById(client.IdPhone);
                client.IdPhone = Convert.ToInt64(phone.Number);
            }
        }
        public void GetSearchResult(List<Client> clients)
        {
            Clients.Clear();
            foreach(Client client in clients)
            {
                Clients.Add(client);
            }
        }

    }
}
