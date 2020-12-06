using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportClubDB
{
    public class ViewModelAdminMain : BaseNotifyClass
    {
        Admin admin;

        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; RaiseProperty(); } }

        public SimpleCommand OpenTrainers { get; set; }
        public SimpleCommand OpenMyEvents { get; set; }
        public SimpleCommand OpenClients { get; set; }
        public SimpleCommand OpenEditMyProfile { get; set; }
        public SimpleCommand Exit { get; set; }
        public ViewModelAdminMain(Admin admin, Frame frame)
        {
            this.admin = admin;
            OpenTrainers = new SimpleCommand(() =>
            {
                CurrentPage = new TrainersDataGridPage(new ViewModelTrainersList());
            });
            OpenMyEvents = new SimpleCommand(() =>
            {
                CurrentPage = new AdminEventsPage(new ViewModelAdminEventsPage(admin));
            });
            OpenEditMyProfile = new SimpleCommand(() =>
            {
                CurrentPage = new AdminProfilePage(new ViewModelEditAdmin(admin));
            });
            Exit = new SimpleCommand(() =>
            {
                frame.GoBack();
            });
        }
    }
}
