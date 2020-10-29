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
        public Post Post { get; set; }
        public List<Client> clients;

        public void CreateTrainer()
        {
            string add;
        }
        public void RemoveTrainer()
        {
            string remove;
        }
        public List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            return trainers;
        }
    }
}
