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
        private bool _isToDoPageOpen = false;
        public bool IsToDoPageOpen
        {
            get => _isToDoPageOpen;
            set
            {
                _isToDoPageOpen = value;
                OnPropertyChanged(nameof(IsToDoPageOpen));
            }
        }
        private bool _isWalkingPageOpen = false;
        public bool IsWalkingPageOpen
        {
            get => _isWalkingPageOpen;
            set
            {
                _isWalkingPageOpen = value;
                OnPropertyChanged(nameof(IsWalkingPageOpen));
            }
        }
        private bool _isStatsPageOpen = false;
        public bool IsStatsPageOpen
        {
            get => _isStatsPageOpen;
            set
            {
                _isStatsPageOpen = value;
                OnPropertyChanged(nameof(IsStatsPageOpen));
            }
        }

        public AppShellViewModel()
        {
            OpenPage();

            if (!IsLoggedIn)
            {
                UpdateUserInfo(User.Name, User.Level, User.Experience, User.RequiredExperience, User.LevelPercentage);
                IsLoggedIn = true;
            }
            else
            {
                User.Name = Username;
                User.Level = Level;
                User.Experience = Experience;
                User.RequiredExperience = RequiredExperience;
                User.LevelPercentage = LevelPercentage;
            }
        }
        public void OpenPage()
        {
            switch (OpenedFlyoutPage)
            {
                case OpenedPage.ToDoPage:
                    {
                        IsToDoPageOpen = true;
                        IsWalkingPageOpen = false;
                        IsStatsPageOpen = false;
                        break;
                    }
                case OpenedPage.WalkingPage:
                    {
                        IsToDoPageOpen = false;
                        IsWalkingPageOpen = true;
                        IsStatsPageOpen = false;
                        break;
                    }
                case OpenedPage.StatsPage:
                    {
                        IsToDoPageOpen = false;
                        IsWalkingPageOpen = false;
                        IsStatsPageOpen = true;
                        break;
                    }
            }
        }
    }
}
