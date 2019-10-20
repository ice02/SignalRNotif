﻿namespace SignalRNotif.WPFClient.Settings
{
    public interface ISettingsManager
    {
        SettingsInfo ReadSettings();
        void WriteSettings(SettingsInfo settingsInfo);
    }
}