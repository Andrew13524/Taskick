using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Taskick.Models;
using System.Collections.ObjectModel;
using Taskick.Services;

namespace Taskick.ViewModels
{
    class AppShellViewModel : BaseViewModel
    {
        public string Name                              // Username, level exp and so on set as preferences
        {                                               // so that this information is stored and saved after even if the 
            get => Preferences.Get(nameof(Name), null); // user closes the application
            set
            {                                           // OnPropertyChanged() called to always update any changed values
                Preferences.Set(nameof(Name), value);
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Level
        {
            get => Preferences.Get(nameof(Level), null);
            set
            {
                Preferences.Set(nameof(Level), value);
                OnPropertyChanged(nameof(Level));
            }
        }
        public string Experience
        {
            get => Preferences.Get(nameof(Experience), null);
            set
            {
                Preferences.Set(nameof(Experience), value);
                OnPropertyChanged(nameof(Experience));
            }
        }
        public double LevelPercentage
        {
            get => Preferences.Get(nameof(LevelPercentage), 0.0);
            set
            {
                Preferences.Set(nameof(LevelPercentage), value);
                OnPropertyChanged(nameof(LevelPercentage));
            }
        }
        public AppShellViewModel()
        {
            Name =              $"{DataStore.CurrentUser.Name}";
            Level =             $"Level {DataStore.CurrentUser.Level}";
            Experience =        $"{DataStore.CurrentUser.Experience} / {DataStore.CurrentUser.RequiredExperience}";
            LevelPercentage =   DataStore.CurrentUser.LevelPercentage;
        }    
    }
}
