using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MailSenderLibrary
{
    /// <summary>Рассылка почты</summary>
    public class MailService
    {
        private string _Login;
        private string _Password;

        private string _ServerAddress = "smtp.yandex.ru";
        private int _Port = 25;

        private string _Body;
        private string _Subject;


        /// <summary>
        /// Конструктор класса MailService
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        public MailService(string Login, string Password)
        {
           // (_Login, _Password) = (Login, Password); // подчеркивает ошибка
            _Login = Login;
            _Password = Password;
        }
        


        /// <summary>
        /// Отправка почты одному получателю
        /// </summary>
        /// <param name="Email">Адрес получателя</param>
        /// <param name="Name">Адрес отправителя</param>
        public void SendMail(string Email, string Name)
        {
            try
            {
                using (var message = new MailMessage(Name, Email)
                {
                    Subject = _Subject,
                    Body = _Body,
                    IsBodyHtml = false
                })
                {
                    using (var client = new SmtpClient(_ServerAddress, _Port) // переменные объявленные выше. Возможно в sendMail нужно передать в т.ч. и адресс\порт
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_Login, _Password)
                    })
                    {
                          client.Send(message);
                    } 
                }
            }
            catch (Exception error)
            {
                Trace.WriteLine(error.ToString());
                throw new InvalidOperationException("Ошибка отправки почты", error);
            }
        }

        /// <summary>
        /// Отправка почты списку получателей
        /// </summary>
        /// <param name="recipients"> Список получателей</param>
        public void SendMails(ObservableCollection<Recipient> recipients)
        {
            foreach (Recipient recepient in recipients)
            {
                SendMail(recepient.Email, recepient.Name); // обращение к методу выше
            }
        }
    }
}
