using System.Collections.ObjectModel;
using MailSenderLibrary;


namespace MailSenderLibrary
{
    public class Senders
    {
        public static ObservableCollection<Sender> Items =
            new ObservableCollection<Sender>(new[]
            {
                new Sender{Name = "Ivanov",Email = "Ivanov@server.org", Password = PasswordEncoder.Encode("Password1")},
                new Sender{Name = "Petrov",Email = "Petrov@server.org", Password = PasswordEncoder.Encode("Password2")},
                new Sender{Name = "Sidorov",Email = "Sidorov@server.org", Password = PasswordEncoder.Encode("Password3")},
            });
      
    }

    public class Sender
    {
        public string Name {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
