using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelAdminEditEvent
    {
        Event edit;

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SimpleCommand Save { get; set; }

        public ViewModelAdminEditEvent(Event edit)
        {
            this.edit = edit;
            Name = edit.Name;
            Description = edit.Description;
            Date = Convert.ToDateTime(edit.Date);

            Save = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Description != null)
                    {
                        edit.Name = Name;
                        edit.Description = Description;
                        edit.Date = Date.Date.ToString();
                        edit.UpdateEventForAdmin();
                        MessageBox.Show("Событие было успешно изменено!");
                    }
                }
            });
        }
    }
}
