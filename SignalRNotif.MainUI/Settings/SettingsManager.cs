using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRNotif.MainUI.Settings
{
    public class SettingsManager
    {
        private static SettingsManager instance;

        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsManager();
                }
                return instance;
            }
        }

        internal void WriteSettings(SettingsInfo settingsInfo)
        {
            throw new NotImplementedException();
        }

        internal SettingsInfo ReadSettings()
        {
            throw new NotImplementedException();
        }
    }
}
