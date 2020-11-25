using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace SportClubDB
{
    public class DB
    {
        public static MySqlConnection connection = null;
        static DB()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Database = "sportclubdb";
            sb.UserID = "Hippukki";
            sb.Password = "mysqlgymdb";
            sb.CharacterSet = "UTF8";
            connection = new MySqlConnection(sb.ToString());
        }

        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void MySqlCommand(string command)
        {
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(command, connection))
                {
                    mc.ExecuteNonQuery();
                }
                CloseConnection();
            }
        }

    }
}
