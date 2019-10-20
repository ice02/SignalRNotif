﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SignalRNotif.WPFClient.Converters
{
    public class NotConectedBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = bool.Parse(value?.ToString() ?? "false");

            SolidColorBrush result = null;

            if (boolValue)
            {
                result = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF242425"));
            }
            else
            {
                result = Brushes.DarkRed;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
