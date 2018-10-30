using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace MailSenderLibrary
{
	public class User //:INotifyPropertyChanged
	{
        //public event PropertyChangedEventHandler PropertyChanged;
        
        private string Email;
        public string email
        {
            get { return Email; }
            set
            {
                this.Email = value;
                //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(this.Email));
            }
        }

        public User(string email)
        {
            this.email = email;
        }
   
	}
}
