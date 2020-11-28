using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportClubDB
{
    public class ViewModelUserLogIn : BaseNotifyClass
    {
        private Page currentPage;
        Trainer trainer;
        Admin admin;

        public string Login { get; set; }
        public string Password { get; set; }

        public SimpleCommand LogIn { get; set; }
        public Page CurrentPage { get => currentPage; set { currentPage = value; RaiseProperty(); } }

        public ViewModelUserLogIn()
        {
            trainer = new Trainer().GetTrainerByLoginAndPassword(Login, Password);
            admin = new Admin().GetAdminByLoginAndPassword(Login, Password);
            var user = CompareUsers(admin, trainer);

            LogIn = new SimpleCommand(() =>
            {
                if (user == admin)
                    CurrentPage = new AdminMainPage(new ViewModelAdminMain(user));
                else if (user == trainer)
                    CurrentPage = new TrainerMainPage( new ViewModelTrainerMain(user));

            });
        }

        public object CompareUsers(Admin admin, Trainer trainer)
        {
            if (admin.Login == Login && admin.Password == Password)
                return admin;
            else
                return trainer;
        }

    }
}
