using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelAddTrainer
    {
        Trainer trainer;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Phone phone { get; set; }
        public string Number { get; set; }

        public SimpleCommand AddUser { get; set; }

        public ViewModelAddTrainer()
        {

            AddUser = new SimpleCommand(() =>
            {
                trainer = new Trainer();
                trainer.Name = Name;
                trainer.Surname = Surname;
                trainer.Login = Login;
                trainer.Password = Password;
                phone = new Phone();
                phone.Number = Number;
                phone.CreatePhone();
                trainer.IdPhone = phone.GetPhoneId(Number);
                trainer.CreateTrainer();
            });
        }
    }
}
