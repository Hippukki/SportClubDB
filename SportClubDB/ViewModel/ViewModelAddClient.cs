using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelAddClient : BaseNotifyClass
    {
        Client client;
        public string Name { get; set; }
        public string Surname { get; set; }
        public Phone phone { get; set; }
        public string Number { get; set; }

        public SimpleCommand CreateClient { get; set; }

        public ViewModelAddClient(Client client)
        {
            this.client = client;
            client.Name = Name;
            client.Surname = Surname;
            phone = new Phone();
            phone.Number = Number;
            client.Phone = phone;
            CreateClient = new SimpleCommand(() =>
            {
                client.CreateClient();
            });
        }
    }
}
