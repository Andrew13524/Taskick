using Flyout_Test;
using Flyout_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Taskick.Scripts;

namespace Taskick.ViewModels
{
    class AppShellViewModel : BaseViewModel
    {
        public string UsernameProperty                              // Username, level exp and so on set as preferences
        {                                                           // so that this information is stored and saved even if the 
            get => Preferences.Get(nameof(UsernameProperty), null); // user closes the application
            set
            {
                Preferences.Set(nameof(UsernameProperty), value);
                OnPropertyChanged(nameof(UsernameProperty));
            }
        }
        public string LevelProperty
        {
            get => Preferences.Get(nameof(LevelProperty), null);
            set
            {
                Preferences.Set(nameof(LevelProperty), value);
                OnPropertyChanged(nameof(LevelProperty));
            }
        }
        public string ExperienceProperty
        {
            get => Preferences.Get(nameof(ExperienceProperty), null);
            set
            {
                Preferences.Set(nameof(ExperienceProperty), value);
                OnPropertyChanged(nameof(ExperienceProperty));
            }
        }
        public double LevelPercentageProperty
        {
            get => Preferences.Get(nameof(LevelPercentageProperty), 0);
            set
            {
                Preferences.Set(nameof(LevelPercentageProperty), value);
                OnPropertyChanged(nameof(LevelPercentageProperty));
            }
        }
        public string GoalTitle
        {
            get => Preferences.Get(nameof(GoalTitle), null);
            set
            {
                Preferences.Set(nameof(GoalTitle), value);
                OnPropertyChanged(nameof(GoalTitle));
            }
        }
        public DateTime DueDate
        {
            get => Preferences.Get(nameof(DueDate), DateTime.Now);
            set
            {
                Preferences.Set(nameof(DueDate), value);
                OnPropertyChanged(nameof(LevelPercentageProperty));
            }
        }
        public string Difficulty
        {
            get => Preferences.Get(nameof(Difficulty), null);
            set
            {
                Preferences.Set(nameof(Difficulty), value);
                OnPropertyChanged(nameof(Difficulty));
            }
        }
        public string Goal // Called to display goal and concatanates all required Goal info
        {
            get { return $"{GoalTitle} {DueDate} {Difficulty}"; }
        }
        public AppShellViewModel(string username)
        {                                       // Using input (firstName + lastName) from user and creating User object
            User user = new User(username);     // Then calling method SetupFlyoutHeader() to display the relevant User fields
            SetupFlyoutHeader(user);            // and other UI features (such as progress bar)
        }
        public AppShellViewModel(string goalTitle, DateTime dueDate, string difficulty)
        {
            Goal newGoal = new Goal(goalTitle, dueDate, difficulty);
            SetupToDoTasks(newGoal);
        }
                    
                    // SetupFlyoutHeader() is used to assign values to Flyout Header properties
        public void SetupFlyoutHeader(User user)
        {
            UsernameProperty = user.Name;
            LevelProperty = "Level " + user.Level.ToString();
            ExperienceProperty = user.Experience.ToString() + @"/" + user.RequiredExperience.ToString();
            LevelPercentageProperty = user.LevelPercentage();
        }
        public void SetupToDoTasks(Goal newGoal)
        {
            GoalTitle = newGoal.Title;
            DueDate = newGoal.DueDate;
            Difficulty = newGoal.Difficulty;
        }       
    }
}
