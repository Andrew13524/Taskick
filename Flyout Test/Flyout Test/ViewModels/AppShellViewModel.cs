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
    }
}
