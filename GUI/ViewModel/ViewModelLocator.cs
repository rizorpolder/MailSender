using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLibrary;

namespace GUI.ViewModel
{

    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<IDataAccessService,DataAccessServiceFromDB> ();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

       



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

    }
}