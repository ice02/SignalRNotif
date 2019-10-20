using SignalRNotif.MainUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SignalRNotif.MainUI
{
  
    public partial class SettingsView : Window
    {
        private Storyboard unloadMovie;

        private SettingsViewModel viewModel;

        public SettingsView()
        {
            InitializeComponent();

            unloadMovie = (Storyboard)Resources["UnLoadAnimation"];

            viewModel = new SettingsViewModel();

            viewModel.SavedSettings += (sender, e) => CloseWithAnimation();

            MouseDown += (sender, e) =>
            {
                this.DragMove();
                e.Handled = false;
            };

            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CloseWithAnimation();
        }


        private void CloseWithAnimation()
        {
            unloadMovie.Completed += (sender, e) =>
            {
                Close();
            };

            unloadMovie.Begin();
        }
    }
}
