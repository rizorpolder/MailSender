﻿using MailSenderLibrary;
using System.Linq;

namespace MailSenderLibrary
{
    /// <summary>База данных</summary>
    public class DataBase
    {
        private readonly RecipientsDataContext _Recipients = new RecipientsDataContext();

        public IQueryable<Recipient> Recipients => _Recipients.Recipient;
    }
}
