using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using SignalRNotif.ServiceClient;
using SignalRNotif.WPFClient.Settings;
using SignalRNotif.Models;
using CommonServiceLocator;

namespace SignalRNotif.WPFClient.ViewModel
{

    public class ViewModelLocator
    {

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

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NotificationViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        public NotificationViewModel Notification
        {
            get
            {
                NotifMessageHubConect connectHub = null;

                try
                {
                    string serviceAddress = SettingsBuilder.BuildSettings().ReadSettings().ServiceAddress;

                    //string serviceAddress = "htpp://localhost:5";

                    var userInfo = new UserInfo { User = "Principal Client" };

                    connectHub = BuilderNotifMessageHubConnect.CreateMLMessageHub(serviceAddress, userInfo);
                }
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message + "--");
                }



                return new NotificationViewModel(connectHub);

                //return ServiceLocator.Current.GetInstance<NotificationViewModel>();
            }
        }



        public SettingsViewModel Settings
        {
            get
            {
                var settingsManager = SettingsBuilder.BuildSettings();

                return new SettingsViewModel(settingsManager);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}