using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MailSenderLibrary
{
    public class AsyncSaveViewModel : INotifyPropertyChanged
    {
       

        public event PropertyChangedEventHandler PropertyChanged;


        // Мгогопоточный PropertyChanged для пользовательского интерфейса.
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            var handlers = PropertyChanged;
            if (handlers is null) return;

            var e = new PropertyChangedEventArgs(PropertyName);
            var invocationList = handlers.GetInvocationList();

            foreach(var d in invocationList)
                switch(d.Target)
                {
                    default:
                        d.DynamicInvoke(this, e);
                        break;
                    case DispatcherObject dispatcherObject when dispatcherObject.Dispatcher.CheckAccess():
                        dispatcherObject.Dispatcher.Invoke(d, this, e);
                        
                        break;

                }


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value)) return false;
            field = value;

            OnPropertyChanged(Property);
            return true;
        }
    }
}
