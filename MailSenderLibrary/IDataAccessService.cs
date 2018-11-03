
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
            try
            {
                _DataBaseContext.Recipient.InsertOnSubmit(recipient);
                _DataBaseContext.SubmitChanges();
                return recipient.Id;
            }
            catch (System.InvalidOperationException)
            {

                MessageBox.Show("Пользователь уже есть в базе данных");
                return 0;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Не все поля заполнены");
                return 0;
            }
            //catch
        }

        public int RemoveRecipient(Recipient recipient)
        {
            try {
                _DataBaseContext.Recipient.DeleteOnSubmit(recipient);
                _DataBaseContext.SubmitChanges();
                return recipient.Id;
            }
            catch (System.InvalidOperationException)
            {

                MessageBox.Show("Нет такого пользователя");
                return 0;
            }
        } 
    }
}
