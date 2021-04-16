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
        public AppShellViewModel()
        {
            Username =        User.Name;
            Level =           $"Level {User.Level}";
            Experience =      $"{User.Experience}/{User.RequiredExperience}";
            LevelPercentage = User.LevelPercentage;
        }
    }
}
