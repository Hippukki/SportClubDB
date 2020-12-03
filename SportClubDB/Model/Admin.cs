
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Admin : DB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public int IdPost { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long IdPhone { get; set; }

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
            string update = "Update administrator Set name = '"+Name+"', " +
                "surname = '"+Surname+ "',  " +
                "lastname = '"+Lastname+"'"+
                "login = '" + Login + "', " +
                "password = '" + Password + "'" +
                "id_phone = '"+IdPhone+"' Where id = '"+ID+"'";
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
