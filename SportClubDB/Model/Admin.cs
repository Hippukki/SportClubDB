
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Admin : DB, INotifyPropertyChanged
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
        public void CreateAdmin()
        {
            string add = "Insert Into administrator" +
                   "(id, name, surname, lastname, id_post, login, password, id_phone) " +
                   "Values(0, '"+Name+"', '"+Surname+"','"+Lastname+"', 1, '"+Login+"', '"+Password+"', "+IdPhone+")";
            MySqlCommand(add);
        }
        public void RemoveAdmin()
        {
            string remove = "Delete from administrator where id = '"+ID+"'";
            MySqlCommand(remove);
        }
        public void UpdateAdmin()
        {
            string update = "Update administrator Set name = '" + Name + "',surname = '" + Surname + "', lastname = '" + Lastname + "', login ='" + Login + "', password ='" + Password + "', id_phone = '" + IdPhone + "' WHERE id = '" + ID + "'";
            MySqlCommand(update);
        }
        public List<Admin> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();           
            string sql = "select * from administrator";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        admins.Add(new Admin
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("surname"),
                            Lastname = dr.GetString("lastname"),
                            IdPost = dr.GetInt32("id_post"),
                            IdPhone = dr.GetInt32("id_phone"),
                            Login = dr.GetString("login"),
                            Password = dr.GetString("password")
                        }) ;
                    }
                CloseConnection();
            }
            return admins;
        }
        public List<Admin> GetAdminsByLogin(string value)
        {
            List<Admin> admins = GetAdmins();
            List<Admin> result = new List<Admin>();

            foreach(Admin admin in admins)
            {
                if (admin.Login == value)
                    result.Add(admin);
            }
            return result;
        }
        public Admin GetAdminByLoginAndPassword(string login, string password)
        {
            Admin trueAdmin = new Admin();
            List<Admin> admins = GetAdminsByLogin(login);
            foreach(Admin admin in admins)
            {
                if (admin.Password == password)
                    trueAdmin = admin;
                else
                    MessageBox.Show("Пароль был введен неверно. Пожалуйста повторите попытку.");
            }
            return trueAdmin;
        }
    }
}
