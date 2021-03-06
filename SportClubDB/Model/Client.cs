﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Client : DB, INotifyPropertyChanged
    {
        string name;
        string surname;
        string lastname;
        long idPhone;

        public int ID { get; set; }
        public string Name { get => name; set { name = value; RaiseProperty(); } }
        public string Surname { get => surname; set { surname = value; RaiseProperty(); } }
        public string Lastname { get => lastname; set { lastname = value; RaiseProperty(); } }
        public int IdPost { get; set; }
        public int IdTrainer { get; set; }
        public string Created { get; set; }
        public long IdPhone { get => idPhone; set { idPhone = value; RaiseProperty(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseProperty([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(property));
        }

        public void CreateClient()
        {
            string add = "Insert Into client" +
                   "(id, name, surname, lastname, id_post, id_trainer, created, id_phone) " +
                   "Values(0, '" + Name + "', '" + Surname + "', '"+Lastname+"', 3, "+IdTrainer+ ", '"+DateTime.Now+"'," + IdPhone+")";
            MySqlCommand(add);
        }
        public void RemoveClient()
        {
            string remove = "Delete from client where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public void UpdateClient()
        {
            string update = "Update client Set name = '" + Name + "',surname = '" + Surname + "', lastname = '" + Lastname + "', id_trainer = '" + IdTrainer + "', id_phone = '" + IdPhone + "' WHERE id = '" + ID + "'";
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
                            Lastname = dr.GetString("lastname"),
                            IdPost = dr.GetInt32("id_post"),
                            IdTrainer = dr.GetInt32("id_trainer"),
                            Created = dr.GetString("created"),
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