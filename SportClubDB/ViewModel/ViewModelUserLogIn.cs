using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SportClubDB
{
    public class ViewModelUserLogIn : BaseNotifyClass
    {
        Trainer trainer;
        Admin admin;

        private string login;
        private string password;

        public string Login { get => login; set { login = value; RaiseProperty(); } }
        public string Password { get => password; set { password = value; RaiseProperty(); } }

        public SimpleCommand LogIn { get; set; }

        public ViewModelUserLogIn( Frame frame)
        {

            LogIn = new SimpleCommand(() =>
            {
                if (Login != null)
                {
                    if (Password != null)
                    {
                        trainer = new Trainer().GetTrainerByLoginAndPassword(Login, Password);
                        admin = new Admin().GetAdminByLoginAndPassword(Login, Password);
                        if(admin.Login != Login && admin.Password != Password)
                        {
                            if(trainer.Login != Login && trainer.Password != Password)
                            {
                                MessageBox.Show("Такого пользователя не существует!");
                            }else
                                frame.Navigate(new TrainerMainPage(new ViewModelTrainerMain(trainer, frame)));
                        }
                        else
                            frame.Navigate(new AdminMainPage(new ViewModelAdminMain(admin, frame)));
                    }
                    else
                        MessageBox.Show("Пожалуйста, введите пароль!");
                }
                else
                    MessageBox.Show("Пожалуйста, введите логин!");

            });
        }

    }
}
