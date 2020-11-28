using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelAddAdmin : BaseNotifyClass
    {
        Admin admin;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Phone phone { get; set; }
        public string Number { get; set; }

        public SimpleCommand AddUser { get; set; }

        public ViewModelAddAdmin()
        {
            AddUser = new SimpleCommand(() =>
            {
                admin = new Admin();
                admin.Name = Name;
                admin.Surname = Surname;
                admin.Login = Login;
                admin.Password = Password;
                phone = new Phone();
                phone.Number = Number;
                phone.CreatePhone();
                admin.IdPhone = phone.GetPhoneId(Number);
                admin.CreateAdmin();
            });
        }
    }
}
