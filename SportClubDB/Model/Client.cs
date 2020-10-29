using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Trainer Trainer { get; set; }
        public Post Post { get; set; }
        public DateTime Cteated { get; set; }
        public DateTime Removed { get; set; }

        public void CreateClient()
        {

        }
        public void RemoveClient()
        {

        }
        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            return clients;
        }
    }
}