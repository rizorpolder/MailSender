using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSenderLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel
{
    public class MainWindowViewModel:ViewModelBase
    {
        private readonly IDataAccessService _DataAccessService;
        private string Title = "Заголовок";

        public string title { get => Title; set => Set(ref Title, value); }

        public ObservableCollection<Recipient> Recipients { get; private set; }

        private Recipient _CurrentRecipient = new Recipient();
        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public ICommand UpdateCommand { get; }

        public ICommand UpdateRecipient { get; }

        public ICommand CreateRecipient { get; }
        public MainWindowViewModel(IDataAccessService DataAccessService)
        {
            _DataAccessService = DataAccessService;
            //Recipients = _DataAccessService.GetRecipients();
            UpdateCommand = new RelayCommand(OnUpdateCommandExecuted, UpdateDataCommandCanExecute);
            UpdateRecipient = new RelayCommand<Recipient>(OnUpadteRecipientExecuted, UpdateRecipientCanExecute);
            CreateRecipient = new RelayCommand<Recipient>(OnCreateRecipientExecuted);
        }
        private void OnUpdateCommandExecuted()
        {
            Recipients = _DataAccessService.GetRecipients();
            RaisePropertyChanged(nameof(Recipients));
        }

        public bool UpdateDataCommandCanExecute()
        {
            return true;
        }
        private bool UpdateRecipientCanExecute(Recipient recipient) => recipient != null || _CurrentRecipient!=null;

        private void OnCreateRecipientExecuted(Recipient recipient)
        {
            CurrentRecipient = new Recipient();
        }
        private void OnUpadteRecipientExecuted(Recipient recipient)
        {
            if (_DataAccessService.CreateRecipient(recipient) > 0)
                Recipients.Add(recipient);
        } 2:17

    }
}




