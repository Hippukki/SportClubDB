using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelTrainerEvents : BaseNotifyClass
    {
        Trainer trainer;
        Event _event;
        Event selectedEvent;
        string description;

        public string Description { get => description; set { description = value; RaiseProperty(); } }
        public Event SelectedEvent { get => selectedEvent; set { selectedEvent = value; RaiseProperty();
                Description = selectedEvent.Description; } }
        public ObservableCollection<Event> Events { get; set; }

        public SimpleCommand AddEvent { get; set; }
        public SimpleCommand EditEvent { get; set; }
        public SimpleCommand RemoveEvent { get; set; }

        public ViewModelTrainerEvents(Trainer trainer)
        {
            this.trainer = trainer;
            _event = new Event();
            Events = new ObservableCollection<Event>(_event.GetEventsForTrainerById(trainer.ID));
            AddEvent = new SimpleCommand(() =>
            {
                new TrainerAddEvent(new ViewModelTrainerAddEvent(trainer)).ShowDialog();
            });
            EditEvent = new SimpleCommand(() =>
            {
                new TrainerEventEdit(new ViewModelTrainerEventEdit(SelectedEvent)).ShowDialog();
            });
            RemoveEvent = new SimpleCommand(() =>
            {
                SelectedEvent.RemoveEvent();
                Events.Remove(SelectedEvent);
            });
        }

    }
}
