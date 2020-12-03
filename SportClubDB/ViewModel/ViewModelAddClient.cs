using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportClubDB
{
    public class ViewModelAddClient : BaseNotifyClass
    {
        Client client;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public Phone phone { get; set; }
        public int IdPhone { get; set; }
        public string Number { get; set; }

        public SimpleCommand CreateClient { get; set; }

        public ViewModelAddClient(Client client, Trainer trainer)
        {
            this.client = client;
            CreateClient = new SimpleCommand(() =>
            {
                if (Name != null)
                {
                    if (Surname != null)
                    {
                        if (Lastname != null)
                        {
                            if (Number != null)
                            {
                                client.Name = Name;
                                client.Surname = Surname;
                                client.Lastname = Lastname;
                                client.IdTrainer = trainer.ID;
                                phone = new Phone();
                                phone.Number = Number;
                                phone.CreatePhone();
                                client.IdPhone = phone.GetPhoneId(Number);
                                client.CreateClient();
                                MessageBox.Show("Клиент был успешно добавлен!");
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
