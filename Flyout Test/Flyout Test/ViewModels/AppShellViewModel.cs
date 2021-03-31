using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Taskick.Models;
using System.Collections.ObjectModel;

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
        public string LevelPercentage
        {
            get => Preferences.Get(nameof(LevelPercentage), null);
            set
            {
                Preferences.Set(nameof(LevelPercentage), value);
                OnPropertyChanged(nameof(LevelPercentage));
            }
        }
        public AppShellViewModel(string username)
        {                                       
            User user = new User(username);    // Using input (firstName + lastName) from user and creating User object

            Name = user.Name;
            Level = "Level " + user.Level.ToString();
            Experience = user.Experience.ToString() + @"/" + user.RequiredExperience.ToString();
            LevelPercentage = user.LevelPercentage.ToString();
        }    
    }
}
