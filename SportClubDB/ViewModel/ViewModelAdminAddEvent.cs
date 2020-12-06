using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelAdminAddEvent
    {
        Event Event;
        Admin admin;
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SimpleCommand Save { get; set; }

        public ViewModelAdminAddEvent(Admin admin)
        {
            this.admin = admin;
            Save = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Description != null)
                    {
                        Event = new Event();
                        Event.Name = Name;
                        Event.Description = Description;
                        Event.Date = Date.Date.ToString();
                        Event.IdUser = admin.ID;
                        Event.CreateEventForAdmin();
                        MessageBox.Show("Событие было успешно созданно!");
                    }
                }
            });
        }
    }
}
