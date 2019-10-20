using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRNotif.Models;

namespace SignalRNotif.ServiceClient.EventArgs
{
    public class NotifMessageEventArgs
    {
        public NotificationMessage NotificationMessage { get; private set; }

        public NotifMessageEventArgs(NotificationMessage notificationMessage)
        {
            NotificationMessage = notificationMessage;
        }
    }
}
