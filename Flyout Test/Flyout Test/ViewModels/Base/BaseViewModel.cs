using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Taskick.Models;
using Taskick.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

public enum SaveState { ADD, EDIT, COMPLETE }

namespace Taskick.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
