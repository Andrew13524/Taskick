using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Taskick.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Taskick.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        public BaseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
