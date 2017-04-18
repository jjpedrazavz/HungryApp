using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HungryApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected bool SetProperty<T>(ref T stored, T value, [CallerMemberName]string propertyName = "")
        {
            if (Object.Equals(stored, value))
            {
                return false;
            }

            stored = value;
            OnPropertyChange(propertyName);
            return true;

        }

        private void OnPropertyChange([CallerMemberName]string propertyName="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
