using System.Windows.Media;

namespace SportClubDB
{
    public class Clients
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Trainer Trainer { get; set; }
    }
}