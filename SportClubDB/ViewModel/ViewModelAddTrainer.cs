using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelAddTrainer
    {
        Trainer trainer;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Phone phone { get; set; }
        public string Number { get; set; }

        public SimpleCommand AddUser { get; set; }

        public ViewModelAddTrainer()
        {

            AddUser = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Surname != null)
                    {
                        if (Lastname != null)
                        {
                            if (Number != null)
                            {
                                if (Login != null)
                                {
                                    if (Password != null)
                                    {
                                        trainer = new Trainer();
                                        trainer.Name = Name;
                                        trainer.Surname = Surname;
                                        trainer.Lastname = Lastname;
                                        trainer.Login = Login;
                                        trainer.Password = Password;
                                        phone = new Phone();
                                        phone.Number = Number;
                                        phone.CreatePhone();
                                        trainer.IdPhone = phone.GetPhoneId(Number);
                                        trainer.CreateTrainer();
                                        MessageBox.Show("Пользователь был успешно создан!");
                                    }
                                    else
                                        MessageBox.Show("Пожалуйста, введите пароль!");
                                }
                                else
                                    MessageBox.Show("Пожалуйста, введите логин!");

                            }
                            else
                                MessageBox.Show("Пожалуйста, введите номер мобильного телефона!");
                        }
                        else
                            MessageBox.Show("Пожалуйста, введите отчество!");
                    }
                    else
                        MessageBox.Show("Пожалуйста, введите фамилию!");
                }
                else
                    MessageBox.Show("Пожалуйста, введите имя!");
            });
        }
    }
}
