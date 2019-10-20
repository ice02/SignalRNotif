using System;
using System.Threading.Tasks;
using SignalRNotif.Models;
using SignalRNotif.ServiceClient.EventArgs;

namespace SignalRNotif.ServiceClient
{
    public interface INotifMessageHubConect
    {
        event EventHandler<NotifMessageEventArgs> ProcessMessage;

        void Dispose();
        Task SendMessage(NotificationMessage message);
    }
}