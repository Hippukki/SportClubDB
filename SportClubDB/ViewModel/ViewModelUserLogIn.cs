using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportClubDB
{
    public class ViewModelUserLogIn
    {
        Frame mainframe;
        Trainer trainer;
        Admin admin;

        public string Login { get; set; }
        public string Password { get; set; }

        public SimpleCommand LogIn { get; set; }

        public ViewModelUserLogIn( Frame mainframe)
        {
            this.mainframe = mainframe;
            trainer = new Trainer().GetTrainerByLoginAndPassword(Login, Password);
            admin = new Admin().GetAdminByLoginAndPassword(Login, Password);
            var user = CompareUsers(admin, trainer);

            LogIn = new SimpleCommand(() =>
            {
                if (user == admin)
                    return;
                else if (user == trainer)
                    mainframe.Navigate(new TrainerMainPage(ViewModelTrainerMain(user)));

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
