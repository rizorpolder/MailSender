using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLibrary.Data
{
    public partial class SpamDataBase
    {
        static SpamDataBase() => System.Data.Entity.Database.SetInitializer(new SpamDataBaseInitializer());


    }

    class SpamDataBaseInitializer:DropCreateDatabaseAlways<SpamDataBase>  //DropCreateDatabaseIfModelChanges<SpamDatabase> для обновления модели и обновления структуры базы на сервере
    {
        protected override void Seed(SpamDataBase context)
        {
            base.Seed(context);
            if(context.Emails.Any())
            {
                context.Emails.AddOrUpdate(
                    new Email { Title = "Письмо 1", Body ="Текст письма 1" },
                    new Email { Title = "Письмо 2", Body = "Текст письма 2" },
                    new Email { Title = "Письмо 3", Body = "Текст письма 3" },
                    new Email { Title = "Письмо 4", Body = "Текст письма 4" },
                    new Email { Title = "Письмо 5", Body = "Текст письма 5" }
                    );
                context.SaveChanges();
            }
            if (!context.Recipients.Any())
            {
                context.Recipients.AddOrUpdate(
                     new Recepient { Name = "Ivanov", Email = "ivanov@mail.ru" },
                     new Recepient { Name = "Petrov", Email = "ivanov@mail.ru" },
                     new Recepient { Name = "Sidorov", Email = "ivanov@mail.ru" }

                    );
                context.SaveChanges();
                1:02:39


            }
        }
    }
}
   