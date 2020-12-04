using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelEditAdmin
    {
        Admin admin;
        Phone phone;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }

        public SimpleCommand Save { get; set; }
        public ViewModelEditAdmin(Admin admin)
        {
            this.admin = admin;
            phone = new Phone();
            Name = admin.Name;
            Surname = admin.Surname;
            Lastname = admin.Lastname;
            Login = admin.Login;
            Password = admin.Password;
            Number = phone.GetNumberById(admin.IdPhone);

            Save = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Surname != null)
                    {
                        if (Lastname != null)
                        {
                            if (Login != null)
                            {
                                if (Password != null)
                                {
                                    if (Number != null)
                                    {
                                        admin.Name = Name;
                                        admin.Surname = Surname;
                                        admin.Lastname = Lastname;
                                        admin.Login = Login;
                                        admin.Password = Password;
                                        phone.ID = admin.IdPhone;
                                        phone.Number = Number;
                                        phone.UpdatePhone();
                                        admin.UpdateAdmin();
                                        MessageBox.Show("Ваши данные были успешно обновлены!");

                                    }
                                    else
                                        MessageBox.Show("Пожалуйста, введите номер мобильного телефона!");
                                }
                                else
                                    MessageBox.Show("Пожалуйста, введите пароль!");
                            }
                            else
                                 MessageBox.Show("Пожалуйста, введите логин!");
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
