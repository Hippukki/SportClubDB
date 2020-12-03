using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelEditTrainer
    {
        Trainer trainer;
        Phone phone;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }

        public SimpleCommand Save { get; set; }
        public ViewModelEditTrainer(Trainer trainer)
        {
            phone = new Phone();
            this.trainer = trainer;
            Name = trainer.Name;
            Surname = trainer.Surname;
            Lastname = trainer.Lastname;
            Login = trainer.Login;
            Password = trainer.Password;
            Number = phone.GetNumberById(trainer.IdPhone);

            Save = new SimpleCommand(() =>
            {
                trainer.Name = Name;
                trainer.Surname = Surname;
                trainer.Lastname = Lastname;
                trainer.Login = Login;
                trainer.Password = Password;
                phone.ID = trainer.IdPhone;
                phone.Number = Number;
                phone.UpdatePhone();
                trainer.UpdateTrainer();
                MessageBox.Show("Ваши данные были успешно обновлены!");
            });
        }
    }
}
