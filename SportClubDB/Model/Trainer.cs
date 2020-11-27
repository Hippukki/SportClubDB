﻿using MySqlConnector;
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
        public int IdPost { get; set; }
        public int IdClient { get; set; }
        public int IdPhone { get; set; }

        public void CreateTrainer()
        {
            string add = "Insert Into trainer" +
                   "(id, name, surname, id_post, login, password, id_phone) " +
                   "Values(0, '" + Name + "', '" + Surname + "', 2, '" + Login + "', '" + Password + "', "+IdPhone+")";
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
                "id_client = '" + IdClient + "'," +
                "login = '" + Login + "', " +
                "password = '" + Password + "'" +
                "id_phone = '"+ IdPhone +"' Where id = '" + ID + "'";
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
                        trainers.Add(new Trainer
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("surname"),
                            IdClient = dr.GetInt32("id_client"),
                            IdPost = dr.GetInt32("id_post"),
                            IdPhone = dr.GetInt32("id_phone")
                        });
                    }
                CloseConnection();
            }
            return trainers;
        }
    }
}
