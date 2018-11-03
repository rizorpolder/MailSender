using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLibrary
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        int CreateRecipient(Recipient recipient);

    }

    public class DataAccessServiceFromDB:IDataAccessService
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
    }
}
