using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelTrainersList : BaseNotifyClass
    {
        Trainer trainer;
        Client client;
        Event @event;
        Trainer selectedTrainer;
        string selectedType;

        public string Request { get; set; }
        public List<string> types { get; set; }
        public string SelectedType { get => selectedType; set { selectedType = value; RaiseProperty(); } }

        public Trainer SelectedTrainer { get => selectedTrainer;
            set { selectedTrainer = value;
                RaiseProperty();
                GetClientsBySelectedTrainer();
                GetEventsBySelectedTrainer();
            } }
        public ObservableCollection<Trainer> Trainers { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        public SimpleCommand Search { get; set; }
        public SimpleCommand Remove { get; set; }

        public ViewModelTrainersList()
        {
            trainer = new Trainer();
            client = new Client();
            @event = new Event();
            Trainers = new ObservableCollection<Trainer>(trainer.GetTrainers());
            Clients = new ObservableCollection<Client>();
            Events = new ObservableCollection<Event>();
            ConverterForTrainers();
            types = new List<string>()
            {
                "Имя",
                "Фамилия",
                "Отчество"
            };

            Search = new SimpleCommand(() =>
            {
                if (Request != null)
                {
                    List<Trainer> trainers = new List<Trainer>();
                    switch (SelectedType)
                    {
                        case "Имя":
                            foreach (Trainer trainer in Trainers)
                            {
                                if (trainer.Name == Request)
                                {
                                    trainers.Add(trainer);
                                }
                            }
                            break;
                        case "Фамилия":
                            foreach (Trainer trainer in Trainers)
                            {
                                if (trainer.Surname == Request)
                                {
                                    trainers.Add(trainer);
                                }
                            }
                            break;
                        case "Отчество":
                            foreach (Trainer trainer in Trainers)
                            {
                                if (trainer.Lastname == Request)
                                {
                                    trainers.Add(trainer);
                                }
                            }
                            break;
                    }
                    GetSearchResult(trainers);
                }
                else
                    MessageBox.Show("Пожалуйста, введите запрос в поле поиска!");
            });

            Remove = new SimpleCommand(() =>
            {
                var phone = new Phone();
                List<Phone> phones = new List<Phone>(phone.GetAllPhone());
                foreach(Phone phone1 in phones)
                {
                    if(phone1.Number == SelectedTrainer.IdPhone.ToString())
                    {
                        phone1.RemovePhone();
                    }
                }
                phones.Clear();
                foreach(Client client in Clients)
                {
                    client.RemoveClient();
                }
                Clients.Clear();
                foreach(Event _event in Events)
                {
                    _event.RemoveEvent();
                }
                Events.Clear();
                SelectedTrainer.RemoveTrainer();
                Trainers.Remove(SelectedTrainer);
            });
        }
        public void GetClientsBySelectedTrainer()
        {
            List<Client> clients = new List<Client>(client.GetClientsByTrainer(SelectedTrainer.ID));
            Clients.Clear();
            foreach(Client client in clients)
            {
                Clients.Add(client);
            }
            ConverterForClients();

        }
        public void GetEventsBySelectedTrainer()
        {
            List<Event> events = new List<Event>(@event.GetEventsForTrainerById(SelectedTrainer.ID));
            Events.Clear();
            foreach(Event _event in events)
            {
                Events.Add(_event);
            }
        }
        public void ConverterForTrainers()
        {
           foreach(Trainer trainer in Trainers)
            {
                Phone phone = new Phone();
                phone.Number = phone.GetNumberById(trainer.IdPhone);
                trainer.IdPhone = Convert.ToInt64(phone.Number);
            }
        }
        public void ConverterForClients()
        {
            foreach (Client client in Clients)
            {
                Phone phone = new Phone();
                phone.Number = phone.GetNumberById(client.IdPhone);
                client.IdPhone = Convert.ToInt64(phone.Number);
            }
        }
        public void GetSearchResult(List<Trainer> trainers)
        {
            Trainers.Clear();
            foreach (Trainer trainer in trainers)
            {
                Trainers.Add(trainer);
            }
        }
    }
}
