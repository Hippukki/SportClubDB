using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelAdminEventsPage : BaseNotifyClass
    {
        Admin admin;
        Event _event;
        Event selectedEvent;
        string description;

        public string Description { get => description; set { description = value; RaiseProperty(); } }
        public Event SelectedEvent
        {
            get => selectedEvent; set
            {
                selectedEvent = value; RaiseProperty();
                Description = selectedEvent.Description;
            }
        }
        public ObservableCollection<Event> Events { get; set; }

        public SimpleCommand AddEvent { get; set; }
        public SimpleCommand EditEvent { get; set; }
        public SimpleCommand RemoveEvent { get; set; }

        public ViewModelAdminEventsPage(Admin admin)
        {
            this.admin = admin;
            _event = new Event();
            Events = new ObservableCollection<Event>(_event.GetEventsForAdminById(admin.ID));
            AddEvent = new SimpleCommand(() =>
            {
                new AdminEventAddWindow(new ViewModelAdminAddEvent(admin)).ShowDialog();
            });
            EditEvent = new SimpleCommand(() =>
            {
                new AdminEventEditWindow(new ViewModelAdminEditEvent(SelectedEvent)).ShowDialog();
            });
            RemoveEvent = new SimpleCommand(() =>
            {
                SelectedEvent.RemoveEvent();
                Events.Remove(SelectedEvent);
            });


        }
    }
}
