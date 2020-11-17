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
        public Client Client { get; set; }
        public Phone Phone { get; set; }

        public void CreateTrainer()
        {
            string add = "Insert Into trainer" +
                   "(id, name, surname, id_post, id_client, login, password, id_phone) " +
                   "Values(0, '" + Name + "', '" + Surname + "', '" + Post.ID + "', '"+Client.ID+"', '" + Login + "', '" + Password + "', '"+Phone.ID+"')";
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
                "id_client = '" + Client.ID + "'," +
                "login = '" + Login + "', " +
                "password = '" + Password + "'" +
                "id_phone = '"+ Phone.ID +"' Where id = '" + ID + "'";
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
                        Phone phone = new Phone();
                        post.ID = dr.GetInt32("id_post");
                        phone.ID = dr.GetInt32("id_phone");
                        trainers.Add(new Trainer
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("surname"),
                            Post = post,
                            Phone = phone
                        });
                    }
                CloseConnection();
            }
            return trainers;
        }
    }
}
