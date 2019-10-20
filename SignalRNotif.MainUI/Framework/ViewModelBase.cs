using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalRNotif.MainUI.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool Set<T>(
            string propertyName,
            ref T field,
            T newValue = default(T))
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            var oldValue = field;
            field = newValue;

            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
