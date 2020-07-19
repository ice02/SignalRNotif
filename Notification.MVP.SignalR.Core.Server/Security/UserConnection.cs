using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.MVP.SignalR.Core.Server.Security
{   
    public class UserConnection
    {
        public string UserName { set; get; }
        public string ConnectionID { set; get; }
    }
}
