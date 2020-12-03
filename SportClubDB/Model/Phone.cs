using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class Phone : DB
    {
        public long ID { get; set; }
        public string Number { get; set; }

        public void CreatePhone()
        {
            string add = "Insert Into phone" +
                   "(id, number) " +
                   "Values(0, '" + Number + "')";
            MySqlCommand(add);
        }
        public void UpdatePhone()
        {
            string update = "Update phone Set number = '" + Number + "' Where id = '" + ID + "'";
            MySqlCommand(update);
        }
        public void RemovePhone()
        {
            string remove = "Delete from phone where id = '" + ID + "'";
            MySqlCommand(remove);
        }
        public List<Phone> GetAllPhone()
        {
            List<Phone> phones = new List<Phone>();
            string sql = "select * from phone";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        phones.Add(new Phone
                        {
                            ID = dr.GetInt32("id"),
                            Number = dr.GetString("number")
                        }) ;
                    }
                CloseConnection();
            }
            return phones;
        }
        
        public int GetPhoneId(string value)
        {
            int IDphone = 0;
            string sql = $"select id from phone where number like '{value}'";
            if (OpenConnection())
            {
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                    while (dr.Read())
                    {
                        IDphone = dr.GetInt32("id");
                    }
                CloseConnection();
            }
            return IDphone;
        }
        public string GetNumberById(long id)
        {
            string Number = "";
            List<Phone> phones = GetAllPhone();
            foreach(Phone phone in phones)
            {
                if (phone.ID == id)
                    Number = phone.Number;
            }return Number;
        }
    }
}

   
