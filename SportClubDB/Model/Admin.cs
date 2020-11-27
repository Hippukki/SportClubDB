
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
    public class Admin : DB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdPost { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdPhone { get; set; }

        public void CreateAdmin()
        {
            string add = "Insert Into administrator" +
                   "(id, name, surname, id_post, login, password, id_phone) " +
                   "Values(0, '"+Name+"', '"+Surname+"', 1, '"+Login+"', '"+Password+"', '"+IdPhone+"')";
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
                            IdPost = dr.GetInt32("id_post"),
                            IdPhone = dr.GetInt32("id_phone")
                        }) ;
                    }
                CloseConnection();
            }
            return admins;
        }
    }
}
