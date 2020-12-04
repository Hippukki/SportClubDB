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
        public SimpleCommand OpenMySchedule { get; set; }
        public SimpleCommand OpenTrainersSchedule { get; set; }
        public SimpleCommand OpenClients { get; set; }
        public SimpleCommand OpenEditMyProfile { get; set; }
        public SimpleCommand OpenAddGym { get; set; }
        public ViewModelAdminMain(Admin admin)
        {
            this.admin = admin;
            OpenTrainers = new SimpleCommand(() =>
            {
                CurrentPage = new TrainersDataGridPage();
            });
            OpenMySchedule = new SimpleCommand(() =>
            {

            });
            OpenTrainersSchedule = new SimpleCommand(() =>
            {

            });
            OpenClients = new SimpleCommand(() =>
            {

            });
            OpenEditMyProfile = new SimpleCommand(() =>
            {
                CurrentPage = new AdminProfilePage(new ViewModelEditAdmin(admin));
            });
            OpenAddGym = new SimpleCommand(() =>
            {

            });
        }
    }
}
