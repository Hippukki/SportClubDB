using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SportClubDB
{
    public class Trainer : DB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Post Post { get; set; }
        public List<Client> Clients { get; set; }

        public void CreateTrainer()
        {
            string add = "Insert Into trainer" +
                   "(id, name, surname, id_post, id_client, login, password) " +
                   "Values(0, '" + Name + "', '" + Surname + "', '" + Post.ID + "', '"+Clients+"', '" + Login + "', '" + Password + "')";
            MySqlCommand(add);
        }
        public void RemoveTrainer()
        {
            string remove = "Delete from trainer where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public void UpdateTrainer()
        {
            string update = "Update trainer Set name = '" + Name + "', " +
                "surname = '" + Surname + "', " +
                "id_post = '" + Post + "', " +
                "id_client = '" + Clients + "'," +
                "login = '" + Login + "', " +
                "password = '" + Password + "' Where id = '" + ID + "'";
            MySqlCommand(update);
        }
        public List<Trainer> GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();            
            string sql = "select * from trainer";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        Post post = new Post();
                        post.ID = dr.GetInt32("id_post");
                        trainers.Add(new Trainer
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("name"),
                            Post = post
                        });
                    }
                CloseConnection();
            }
            return trainers;
        }
    }
}
