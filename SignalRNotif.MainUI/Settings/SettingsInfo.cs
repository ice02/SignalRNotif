using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRNotif.MainUI.Settings
{
    public class SettingsInfo
    {
        public string ServiceAddress { get; internal set; }
        public int SecondsVisibilityBallonTime { get; internal set; }
        public bool ShowBallonWithNotificationsOpen { get; internal set; }
    }
}
