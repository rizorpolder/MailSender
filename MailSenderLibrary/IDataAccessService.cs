
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace MailSenderLibrary
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        int CreateRecipient(Recipient recipient);
        int RemoveRecipient(Recipient recipient);

    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        private RecipientsDataContext _DataBaseContext;


        public DataAccessServiceFromDB()
        {
            _DataBaseContext = new RecipientsDataContext();
        }
        public ObservableCollection<Recipient> GetRecipients()
        {
            return new ObservableCollection<Recipient>(_DataBaseContext.Recipient.ToArray());
        }

        public int CreateRecipient(Recipient recipient)
        {
           
                _DataBaseContext.Recipient.InsertOnSubmit(recipient);
                _DataBaseContext.SubmitChanges();
                return recipient.Id;
           
        }

        public int RemoveRecipient(Recipient recipient)
        {
                _DataBaseContext.Recipient.DeleteOnSubmit(recipient);
                _DataBaseContext.SubmitChanges();
                return recipient.Id;
          
        } 
    }
}
