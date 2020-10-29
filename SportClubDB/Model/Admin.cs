using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportClubDB
{
    public class Admin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Post Post { get; set; }
        public ImageSource Photo { get; set; }

        public void CreateAdmin()
        {
            string add;
        }
        public void RemoveAdmin()
        {
            string remove;
        }
    }
}
