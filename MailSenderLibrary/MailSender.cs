using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MailSenderLibrary
{
   public class MailSender
    {
        Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}"); // регулярное выражение e-mail для добавления - удаления
       public string status = "offline";
        ListOfUsers ListOfUsers = new ListOfUsers();
        static SmtpClient client = null;
        static string Sender = null;
        public MailSender() { }

        #region SMTPClient
        /// <summary>
        /// Создать клиент SMTP для авторизации, 
        /// в последствии сам клиент используется как отправитель
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="password">Пароль</param>
        /// <param name="smtp">СМТП сервер</param>
        /// <param name="port">номер порта</param>
        /// <returns></returns>
        public SmtpClient Access(string sender, string password, string smtp, string port)
        {
            Sender = sender;
            client = new SmtpClient(smtp, Convert.ToInt32(port))
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(sender, password)
            };
            status = "Online";
           return client;
        }
        #endregion


        #region MessageSender
        /// <summary>
        /// Метод отправление почты
        /// </summary>
        /// <param name="recievers">Список получателей</param>
        /// <param name="Theme">Тема</param>
        /// <param name="Text">Сам текст</param>
        public void SendMessage(List<string> recievers, string Theme, string Text)
        {
            foreach (string t in recievers)
            {
                var email = new MailMessage(Sender, t)
                {
                    Subject = Theme,
                    Body = Text
                };
                if (client != null) client.Send(email);
            }
        }
        #endregion


        /// <summary>
        /// Добавление в список новых пользователей
        /// </summary>
        /// <param name="email"></param>
        public void Add(string email)
        {
            if (myReg.IsMatch(email))
            ListOfUsers.Add(new User(email));
            else throw new Exception("Неверный формат");
        }

        /// <summary>
        /// Удаление пользователя из списка
        /// </summary>
        /// <param name="email"></param>
        public void Remove(string email) // требует отладки
        {
            if (myReg.IsMatch(email))
            ListOfUsers.Remove(new User(email));
            else throw new Exception("Отсутствует в базе");
        }

    }
}
