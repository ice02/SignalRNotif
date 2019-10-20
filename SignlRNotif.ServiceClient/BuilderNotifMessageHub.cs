using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRNotif.Models;

namespace SignalRNotif.ServiceClient
{
    public class BuilderNotifMessageHubConnect
    {
        public static NotifMessageHubConect CreateMLMessageHub(string address, IUserInfo userInfo = null, bool isDefaultConnect = true)
        {
            HubConnection conexionHub = new HubConnection(address, isDefaultConnect);
            IHubProxy proxyHub = conexionHub.CreateHubProxy("NotifMessageHub");

            try
            {
                var result = new NotifMessageHubConect(conexionHub, proxyHub, userInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
