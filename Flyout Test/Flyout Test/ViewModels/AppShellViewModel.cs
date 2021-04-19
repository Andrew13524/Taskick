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
        public AppShellViewModel()
        {
            if (!IsLoggedIn)
            {
                Username = User.Name;
                Level = $"Level {User.Level}";
                Experience = $"{User.Experience}/{User.RequiredExperience}";
                LevelPercentage = User.LevelPercentage;
                IsLoggedIn = true;
            }
        }
    }
}
