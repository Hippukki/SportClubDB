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

        string name;
        string surname;
        string lastname;
        int phoneid;
        string number;

        public string Name { get => name; set { name = value; RaiseProperty(); } }
        public string Surname { get => surname; set { surname = value; RaiseProperty(); } }
        public string Lastname { get => lastname; set { lastname = value; RaiseProperty(); } }
        public int PhoneId { get => phoneid; set { phoneid = value; RaiseProperty(); } }
        public string Number { get => number; set { number = value; RaiseProperty(); } }

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
            });
        }
    }
}
