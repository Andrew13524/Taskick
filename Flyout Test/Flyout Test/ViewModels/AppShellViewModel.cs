using System;
using System.Collections.Generic;
using Taskick.Models;
using System.Collections.ObjectModel;
using Taskick.Services;
using Taskick.Services.DataStorage;

namespace Taskick.ViewModels
{
    class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel()
        {
            Name = UserDataStore.CurrentUser.Name;
            Level = UserDataStore.CurrentUser.Level;
            Experience = UserDataStore.CurrentUser.Experience;
            RequiredExperience = UserDataStore.CurrentUser.RequiredExperience;
            LevelPercentage = UserDataStore.CurrentUser.LevelPercentage;
            Steps = UserDataStore.CurrentUser.Steps;
        }
    }
}
