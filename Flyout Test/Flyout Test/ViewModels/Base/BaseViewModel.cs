using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Taskick.Models;
using Taskick.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

public enum SaveState { ADD, EDIT, DELETE, COMPLETE }
public enum Page { ToDoPage, WalkingPage, StatsPage, WelcomePage, AddGoalPage }

namespace Taskick.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static Page OpenedPage;

        private string _displayedUsername;
        public string DisplayedUsername 
        {
            get => _displayedUsername;
            set
            {
                _displayedUsername = value;
                OnPropertyChanged(nameof(DisplayedUsername));
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

        public string Username
        {
            get => Preferences.Get(nameof(Username), null);
            set
            {
                Preferences.Set(nameof(Username), value);
                OnPropertyChanged(nameof(Username));
            }
        }
        public int Level
        {
            get => Preferences.Get(nameof(Level), 0);
            set
            {
                Preferences.Set(nameof(Level), value);
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Experience
        {
            get => Preferences.Get(nameof(Experience), 0);
            set
            {
                Preferences.Set(nameof(Experience), value);
                OnPropertyChanged(nameof(Experience));
            }
        }
        public int RequiredExperience
        {
            get => Preferences.Get(nameof(RequiredExperience), 0);
            set
            {
                Preferences.Set(nameof(RequiredExperience), value);
                OnPropertyChanged(nameof(RequiredExperience));
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
        private bool _isLogggedIn = false;
        public bool IsLoggedIn
        {
            get => Preferences.Get(nameof(_isLogggedIn), false);
            set
            {
                Preferences.Set(nameof(_isLogggedIn), value);
            }
        }

        public BaseViewModel()
        {
            DisplayedUsername = Username;
            DisplayedLevel = $"Level {Level}";
            DisplayedExperience = $"{Experience}/{RequiredExperience}";
        }

        public void UpdateUserInfo(string username, int level, int experience, int requiredExperience, double levelPercentage)
        {
            Username = username;
            Level = level;
            Experience = experience;
            RequiredExperience = requiredExperience;
            LevelPercentage = levelPercentage;

            DisplayedUsername = Username;
            DisplayedLevel = $"Level {Level}";
            DisplayedExperience = $"{Experience}/{RequiredExperience}";
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
