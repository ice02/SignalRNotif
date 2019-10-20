using SignalRNotif.ServiceClient;
using SignalRNotif.Models;
using SignalRNotif.MainUI.Settings;

namespace SignalRNotif.MainUI.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
        }

        public NotificationViewModel Notification
        {
            get
            {
                NotifMessageHubConect connectHub = null;

                try
                {
                    string serviceAddress = SettingsManager.Instance.ReadSettings().ServiceAddress;

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
                var settingsManager = SettingsManager.Instance;

                return new SettingsViewModel(settingsManager);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}