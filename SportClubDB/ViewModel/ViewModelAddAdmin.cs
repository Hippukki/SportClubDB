using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelAddAdmin : BaseNotifyClass
    {
        Admin admin;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Phone phone { get; set; }
        public string Number { get; set; }

        public SimpleCommand AddUser { get; set; }

        public ViewModelAddAdmin()
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
                                admin = new Admin();
                                admin.Name = Name;
                                admin.Surname = Surname;
                                admin.Lastname = Lastname;
                                admin.Login = Login;
                                admin.Password = Password;
                                phone = new Phone();
                                phone.Number = Number;
                                phone.CreatePhone();
                                admin.IdPhone = phone.GetPhoneId(Number);
                                admin.CreateAdmin();
                                MessageBox.Show("Пользователь был успешно создан!");
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
