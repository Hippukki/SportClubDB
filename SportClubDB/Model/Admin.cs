
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
        public Post Post { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Phone Phone { get; set; }

        public void CreateAdmin()
        {
            string add = "Insert Into administrator" +
                   "(id, name, surname, id_post, login, password, id_phone) " +
                   "Values(0, '"+Name+"', '"+Surname+"', '"+Post.ID+"', '"+Login+"', '"+Password+"', '"+Phone.ID+"')";
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
                "surname = '"+Surname+ "', " +
                "id_post = '" + Post.ID + "', " +
                "login = '" + Login + "', " +
                "password = '" + Password + "'" +
                "id_phone = '"+Phone.ID+"' Where id = '"+ID+"'";
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
                        Post post = new Post();
                        Phone phone = new Phone();
                        post.ID = dr.GetInt32("id_post");
                        phone.ID = dr.GetInt32("id_phone");
                        admins.Add(new Admin
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("name"),
                            Surname = dr.GetString("surname"),
                            Post = post,
                            Phone = phone
                        }) ;
                    }
                CloseConnection();
            }
            return admins;
        }
    }
}
