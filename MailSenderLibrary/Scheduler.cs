using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MailSenderLibrary
{
    public class Scheduler
    {

        DispatcherTimer timer = new DispatcherTimer();
        MailService mailSender;                          // Экземпляр класса отправления писем
        ObservableCollection<DateTime> dtSend;           // Коллекция дат для отправки 

        ObservableCollection<Recipient> emails;          // список получателей

        /// <summary>
        /// Метод возвращающий время и дату в строковом представлении
        /// </summary>
        /// <param name="strSendTime">строка</param>
        /// <returns></returns>
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch
            { }
            return tsSendTime;
        }

        /// <summary>
        /// Непосредственная отправка писем
        /// </summary>
        /// <param name="dtSend">время отправки</param>
        /// <param name="mailSender"> Класс отправщика почты</param>
        /// <param name="recipients"> получатели</param>
        public void SendEmails(ObservableCollection<DateTime> dtSend, MailService mailSender, ObservableCollection<Recipient> recipients)
        {
            this.mailSender = mailSender;
            this.dtSend = dtSend;
            timer.Tick += Timer_Tick;                    // подписка на событие Timer_Tick c проверкой каждую секунду
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            
        }
        

        /// <summary>
        /// Событие Timer_Tick, каждый вызов события проверяется текущее время с указанным в коллекции, если оно совпадает - вызывается метод отправки письма всему списку
        /// </summary>
       
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (DateTime date in dtSend)
            {
                if (date.ToShortTimeString() == DateTime.Now.ToShortTimeString())
                {
                    mailSender.SendMails(emails);
                    timer.Stop();
                    MessageBox.Show("Письма отправлены");
                }
            }
        }
    }
}
