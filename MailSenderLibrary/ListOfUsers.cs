using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace MailSenderLibrary
{
    public class ListOfUsers
    {
        Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}"); // регулярное выражение e-mail для добавления - удаления
        //public event PropertyChangedEventHandler PropertyChanged;

       
        public List<User> users { get; set; }

        public ListOfUsers()
        {
            users = new List<User>()
            {
                new User("123@email.com"),
                new User("321@email.com"),
                new User("152@email.com")
            };
        }

        /// <summary>
        /// добавление пользователя в список 
        /// с проверкой на соответствие формату
        /// </summary>
        /// <param name="email"></param>
        public void Add(User user)
        {
           users.Add(user);
        }

        /// <summary>
        /// Удаление пользователя из списка
        /// с проверкой на соответствие формату
        /// </summary>
        /// <param name="email"></param>
        public void Remove(User user)
        {   
            users.Remove(user);
        }
    }
}
