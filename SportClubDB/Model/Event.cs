using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class Event : DB, INotifyPropertyChanged
    {
        string date;
        string name;
        string description;

        public int ID { get; set; }
        public string Date { get => date; set { date = value; RaiseProperty(); } }
        public string Name { get => name; set { name = value; RaiseProperty(); } }
        public string Description { get => description; set { description = value; RaiseProperty(); } }
        public int IdUser { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseProperty([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(property));
        }

        public void CreateEventForAdmin()
        {
            string add = "Insert Into event" +
                   "(id, date, name, description,id_admin) " +
                   "Values(0, '" + Date + "', '" + Name + "', '"+Description+"','" + IdUser + "')";
            MySqlCommand(add);
        }
        public void CreateEventForTrainer()
        {
            string add = "Insert Into event" +
                   "(id, date, name, description,id_trainer) " +
                   "Values(0, '" + Date + "', '" + Name + "', '" + Description + "','" + IdUser + "')";
            MySqlCommand(add);
        }
        public void UpdateEventForAdmin()
        {
            string update = "Update event Set date = '" + Date + "',name = '" + Name + "', description = '" + Description + "',id_admin = '" + IdUser + "' WHERE id = '" + ID + "'";
            MySqlCommand(update);
        }
        public void UpdateEventForTrainer()
        {
            string update = "Update event Set date = '" + Date + "',name = '" + Name + "', description = '" + Description + "',id_trainer = '" + IdUser + "' WHERE id = '" + ID + "'";
            MySqlCommand(update);
        }
        public void RemoveEvent()
        {
            string remove = "Delete from event where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public List<Event> GetEventsForAdminById( int value)
        {
            List<Event> events = new List<Event>();
            string sql = $"select * from event where id_admin like '{value}'";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        events.Add(new Event
                        {
                            ID = dr.GetInt32("id"),
                            Date = dr.GetString("date"),
                            Name = dr.GetString("name"),
                            Description = dr.GetString("description"),
                            IdUser = dr.GetInt32("id_admin")
                        });
                    }
                CloseConnection();
            }
            return events;
        }
        public List<Event> GetEventsForTrainerById(int value)
        {
            List<Event> events = new List<Event>();
            string sql = $"select * from event where id_trainer like '{value}'";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        events.Add(new Event
                        {
                            ID = dr.GetInt32("id"),
                            Date = dr.GetString("date"),
                            Name = dr.GetString("name"),
                            Description = dr.GetString("description"),
                            IdUser = dr.GetInt32("id_trainer")
                        });
                    }
                CloseConnection();
            }
            return events;
        }

    }

}
