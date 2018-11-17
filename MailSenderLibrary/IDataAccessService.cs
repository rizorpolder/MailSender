
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace MailSenderLibrary
{

    /// <summary>
    /// интерфейс доступа к БД
    /// </summary>
    public interface IDataAccessService
    {
        //ObservableCollection<Recipient> GetRecipients();
        //int CreateRecipient(Recipient recipient);
        //int RemoveRecipient(Recipient recipient);

    }



    public class DataAccessServiceFromDB : IDataAccessService
    {
        //private RecipientsDataContext _DataBaseContext;


        public DataAccessServiceFromDB()
        {
            //_DataBaseContext = new RecipientsDataContext();
        }


        /// <summary>
        /// Выгрузка информации из БД по Recipient в Коллекцию
        /// </summary>
        /// <returns></returns>
        //    public ObservableCollection<Recipient> GetRecipients()
        //    {
        //        return null; /*new ObservableCollection<Recipient>(_DataBaseContext.Recipient.ToArray()); // из БД в массив, который в коллекцию*/
        //    }



        //    /// <summary>
        //    /// Создание получателя в БД
        //    /// </summary>
        //    /// <param name="recipient">Получатель</param>
        //    /// <returns></returns>
        //    public int CreateRecipient(Recipient recipient)
        //    {

        //        //_DataBaseContext.Recipient.InsertOnSubmit(recipient);   // Отправка запроса в БД LINQ to MYSQL
        //        //_DataBaseContext.SubmitChanges();                       // обновляет БД в связи с изменениями
        //        //return recipient.Id;                                    //Возвращает ID созданного получателя
        //        return 0;
        //    }

        //    public int RemoveRecipient(Recipient recipient)                 // аналогично, только удаление
        //    {
        //            //_DataBaseContext.Recipient.DeleteOnSubmit(recipient);
        //            //_DataBaseContext.SubmitChanges();
        //            //return recipient.Id;
        //       return 0;
        //    } 
        //}
    }
}
