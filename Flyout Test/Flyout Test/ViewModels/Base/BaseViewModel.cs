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
        public string Username
        {
            get => Preferences.Get(nameof(User.Name), null);
            set
            {
                Preferences.Set(nameof(User.Name), value);
                OnPropertyChanged(nameof(User.Name));
            }
        }
        public string Level
        {
            get => Preferences.Get(nameof(User.Level), null);
            set
            {
                Preferences.Set(nameof(User.Level), value);
                OnPropertyChanged(nameof(User.Level));
            }
        }
        public string Experience
        {
            get => Preferences.Get(nameof(User.Experience), null);
            set
            {
                Preferences.Set(nameof(User.Experience), value);
                OnPropertyChanged(nameof(User.Experience));
            }
        }
        public double LevelPercentage
        {
            get => Preferences.Get(nameof(User.LevelPercentage), 0.0);
            set
            {
                Preferences.Set(nameof(User.LevelPercentage), value);
                OnPropertyChanged(nameof(User.LevelPercentage));
            }
        }

        private bool _isLogggedIn = false;
        public bool IsLoggedIn
        {
            get => Preferences.Get(nameof(_isLogggedIn), false);
            set
            {
                Preferences.Set(nameof(_isLogggedIn), value);
            }
        }
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
