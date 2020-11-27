using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Client : DB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdPost { get; set; }
        public int IdTrainer { get; set; }
        public DateTime Created { get; set; }
        public int IdPhone { get; set; }

        public void CreateClient()
        {
            string add = "Insert Into client" +
                   "(id, name, surname, id_post, id_trainer, created, id_phone) " +
                   "Values(0, '" + Name + "', '" + Surname + "', 3, "+IdTrainer+ ", '"+DateTime.Now+"'," + IdPhone+")";
            MySqlCommand(add);
        }
        public void RemoveClient()
        {
            string remove = "Delete from client where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public void UpdateClient()
        {
            string update = "Update client Set name = '" + Name + "', " +
                "surname = '" + Surname + "'" +
                "id_trainer = '" + IdTrainer + "'" +
                "id_phone = '"+ IdPhone + "' Where id = '" + ID + "'";
            MySqlCommand(update);
        }
        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();           
            string sql = "select * from client";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        clients.Add(new Client
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("surname"),
                            IdPost = dr.GetInt32("id_post"),
                            IdTrainer = dr.GetInt32("id_trainer"),
                            Created = dr.GetDateTime("created"),
                            IdPhone = dr.GetInt32("id_phone")
                        });
                    }
                CloseConnection();
            }
            return clients;
        }
        public List<Client> GetClientsByTrainer(int trainer)
        {
            List<Client> clients = GetClients();
            List<Client> result = new List<Client>();
            foreach( Client client in clients)
            {
                if(client.IdTrainer == trainer)
                {
                    result.Add(client);
                }                  
            }return result;
        }
    }
}