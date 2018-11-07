using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSenderLibrary
{
    public class SMTP
    {

       public static  Dictionary<string, int> servers=
       
            servers = new Dictionary<string, int>()
        {
           {"smtp.yandex.ru", 465} ,
           {"smtp.gmail.com",465},
           {"smpt.mail.ru",465}
        };
        
        public int GetSMPT(string value)
        {
            return servers[value];
        }
    }
  
}