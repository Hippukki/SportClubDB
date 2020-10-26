using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SportClubDB
{
    public class Trainer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ImageSource Photo { get; set; }
        public string Post { get; set; }
        public List<Clients> clients;
    }
}
