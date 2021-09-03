using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Taskick.Models;
using Taskick.Services;
using Taskick.Services.DataStorage;
using Xamarin.Essentials;
using Xamarin.Forms;

public enum Page { ToDoPage, WalkingPage, StatsPage, WelcomePage, AddGoalPage }

namespace Taskick.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static Page OpenedPage;

        private string _displayedName;
        public string DisplayedName 
        {
            get => _displayedName;
            set
            {
                _displayedName = value;
                OnPropertyChanged(nameof(DisplayedName));
            }
        }
        private string _displayedLevel;
        public string DisplayedLevel
        {
            get => _displayedLevel;
            set
            {
                _displayedLevel = value;
                OnPropertyChanged(nameof(DisplayedLevel));
            }
        }
        private string _displayedExperience;
        public string DisplayedExperience
        {
            get => _displayedExperience;
            set
            {
                _displayedExperience = value;
                OnPropertyChanged(nameof(DisplayedExperience));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        private int _experience;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }
        private int _requiredExperience;
        public int RequiredExperience
        {
            get => _requiredExperience;
            set
            {
                _requiredExperience = value;
                OnPropertyChanged(nameof(RequiredExperience));
            }
        }
        private double _levelPercentage;
        public double LevelPercentage
        {
            get => _levelPercentage;
            set
            {
                _levelPercentage = value;
                OnPropertyChanged(nameof(LevelPercentage));
            }
        }
        private int _steps;
        public int Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }
        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private bool _hasAccount = false;
        public bool HasAccount
        {
            get => Preferences.Get(nameof(_hasAccount), false);
            set
            {
                Preferences.Set(nameof(_hasAccount), value);
            }
        }

        public BaseViewModel()
        {
            DisplayedName = UserDataStore.CurrentUser.Name;
            DisplayedLevel = $"Level {UserDataStore.CurrentUser.Level}";
            DisplayedExperience = $"{UserDataStore.CurrentUser.Experience}/{UserDataStore.CurrentUser.RequiredExperience}";

            Steps = UserDataStore.CurrentUser.Steps;
        }

        public void UpdateUserInfo()
        {
            Name = UserDataStore.CurrentUser.Name;
            Level = UserDataStore.CurrentUser.Level;
            Experience = UserDataStore.CurrentUser.Experience;
            RequiredExperience = UserDataStore.CurrentUser.RequiredExperience;
            LevelPercentage = UserDataStore.CurrentUser.LevelPercentage;
            Steps = UserDataStore.CurrentUser.Steps;

            DisplayedName = UserDataStore.CurrentUser.Name;
            DisplayedLevel = $"Level {UserDataStore.CurrentUser.Level}";
            DisplayedExperience = $"{UserDataStore.CurrentUser.Experience}/{UserDataStore.CurrentUser.RequiredExperience}";
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
