using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSenderLibrary
{
    public partial class Recipient :IDataErrorInfo
    {
        Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");
        //partial void OnEmailChanging(string value)
        //{
        //    if (!(myReg.Equals(value))) throw new Exception("Неверный формат Email.");
        //    if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value), "Передана пустая строка");
            
        //}

        //partial void OnNameChanging(string value)
        //{
        //    if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value), "Передана пустая строка");
        //}

    string IDataErrorInfo.this[string property_name]
        {
            get
            {
                switch(property_name)
                {
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email) || !(myReg.IsMatch(Email)))
                            return "Неккоректное значение Email";
                        break;
                }
                return "";
            }
        }

        string IDataErrorInfo.Error => "";
    }
   
}
