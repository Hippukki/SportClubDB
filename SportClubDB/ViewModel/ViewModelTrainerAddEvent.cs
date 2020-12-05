using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelTrainerAddEvent
    {
        Event Event;
        Trainer trainer;
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SimpleCommand Save { get; set; }

        public ViewModelTrainerAddEvent(Trainer trainer)
        {
            this.trainer = trainer;
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
                        Event.IdUser = trainer.ID;
                        Event.CreateEventForTrainer();
                    }
                }
            });
        }
    }
}
