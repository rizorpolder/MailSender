using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MailSenderLibrary
{
    public class Scheduler
    {

        DispatcherTimer timer = new DispatcherTimer();
        MailService mailSender = new MailService(); // проверит в методичке EmailSendServiceClass
        DateTime dtSend;

        IQueryable<Recipient> emails;

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

        public void SendEmails(DateTime dtSend, MailService mailSender, IQueryable<Recipient> recipients)
        {
            this.mailSender = mailSender;
            this.dtSend = dtSend;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(dtSend.ToShortTimeString()==DateTime.Now.ToShortTimeString())
            {
                mailSender.SendMail(emails);
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }
    }
}
