using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelEditClient : BaseNotifyClass
    {
        Client edit;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public long PhoneId { get; set; }
        public long Number { get; set; }

        public SimpleCommand Save { get; set; }
        public ViewModelEditClient(Client edit)
        {
            this.edit = edit;
            Name = edit.Name;
            Surname = edit.Surname;
            Lastname = edit.Lastname;
            Number = edit.IdPhone;
            Phone editphone = new Phone();
            PhoneId = editphone.GetPhoneId(Number.ToString());

            Save = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Surname != null)
                    {
                        if (Lastname != null)
                        {
                            if (Number != 0)
                            {
                                edit.Name = Name;
                                edit.Surname = Surname;
                                edit.Lastname = Lastname;
                                edit.IdPhone = PhoneId;
                                editphone.ID = PhoneId;
                                editphone.Number = Number.ToString();
                                edit.UpdateClient();
                                editphone.UpdatePhone();                                                                
                                MessageBox.Show("Данные клиента были успешно обновлены");
                            }
                            else
                                MessageBox.Show("Пожалуйста, введите номер мобильного телефона!");
                        }
                        else
                            MessageBox.Show("Пожалуйста, введите отчество!");
                    }
                    else
                        MessageBox.Show("Пожалуйста, введите фамилию!");
                }
                else
                    MessageBox.Show("Пожалуйста, введите имя!");
            });
        }
    }
}
