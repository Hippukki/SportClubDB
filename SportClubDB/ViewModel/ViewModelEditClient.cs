using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubDB
{
    public class ViewModelEditClient : BaseNotifyClass
    {
        Client edit;
        Phone editphone;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public int PhoneId { get; set; }
        public string Number { get; set; }

        public SimpleCommand Save { get; set; }
        public ViewModelEditClient(Client edit)
        {
            this.edit = edit;
            Name = edit.Name;
            Surname = edit.Surname;
            Lastname = edit.Lastname;
            Number = edit.IdPhone.ToString();
            editphone = new Phone();
            PhoneId = editphone.GetPhoneId(Number);

            Save = new SimpleCommand(() =>
            {
                edit.Name = Name;
                edit.Surname = Surname;
                edit.Lastname = Lastname;
                editphone.ID = PhoneId;
                editphone.Number = Number;
                editphone.UpdatePhone();
                edit.IdPhone = PhoneId;
                edit.UpdateClient();
                RaiseProperty();
            });
        }
    }
}
