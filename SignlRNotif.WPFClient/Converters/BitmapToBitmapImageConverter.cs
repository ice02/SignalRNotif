using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace SignalRNotif.WPFClient.Converters
{
    public class BitmapToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                var imageBrush = (ImageBrush)Application.Current.Resources["SettingsLogoPrincipalBrush"];

                return imageBrush;
            }

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            string path = value.ToString();
            logo.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            logo.EndInit();

            var result = new ImageBrush (logo);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }



        private BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    }
}
