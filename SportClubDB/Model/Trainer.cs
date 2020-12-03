using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SportClubDB
{
    public class Trainer : DB, INotifyPropertyChanged
    {
        string name;
        string surname;
        string lastname;
        string login;
        string password;
        long idPhone;

        public int ID { get; set; }
        public string Name { get => name; set { name = value; RaiseProperty(); } }
        public string Surname { get => surname; set { surname = value; RaiseProperty(); } }
        public string Lastname { get => lastname; set { lastname = value; RaiseProperty(); } }
        public int IdPost { get; set; }
        public string Login { get => login; set { login = value; RaiseProperty(); } }
        public string Password { get => password; set { password = value; RaiseProperty(); } }
        public long IdPhone { get => idPhone; set { idPhone = value; RaiseProperty(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseProperty([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(property));
        }
        public void CreateTrainer()
        {
            string add = "Insert Into trainer" +
                   "(id, name, surname, lastname, id_post, login, password, id_phone) " +
                   "Values(0, '" + Name + "', '" + Surname + "', '"+Lastname+"', 2, '" + Login + "', '" + Password + "', "+IdPhone+")";
            MySqlCommand(add);
        }
        public void RemoveTrainer()
        {
            string remove = "Delete from trainer where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public void UpdateTrainer()
        {
            string update = "Update trainer Set name = '" + Name + "',surname = '" + Surname + "', lastname = '" + Lastname + "', login ='"+Login+"', password ='"+Password+"', id_phone = '" + IdPhone + "' WHERE id = '" + ID + "'";
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
                            Lastname = dr.GetString("lastname"),
                            IdPost = dr.GetInt32("id_post"),
                            IdPhone = dr.GetInt32("id_phone"),
                            Login = dr.GetString("login"),
                            Password = dr.GetString("password")
                        });
                    }
                CloseConnection();
            }
            return trainers;
        }
        public List<Trainer> GetTrainersByLogin(string value)
        {
            List<Trainer> trainers = GetTrainers();
            List<Trainer> result = new List<Trainer>();

            foreach (Trainer trainer in trainers)
            {
                if (trainer.Login == value)
                    result.Add(trainer);
            }
            return result;
        }
        public Trainer GetTrainerByLoginAndPassword(string login, string password)
        {
            Trainer trueTrainer = new Trainer();
            List<Trainer> trainers = GetTrainersByLogin(login);
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Password == password)
                    trueTrainer = trainer;
                else
                    MessageBox.Show("Пароль был введен неверно. Пожалуйста повторите попытку.");
            }
            return trueTrainer;
        }
    }
}
