using Flyout_Test.ViewModels;
using Flyout_Test.Views;
using System;
using Taskick.Scripts;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private string _usernameProperty; // Variables binded to properties in XAML
        private string _levelProperty;
        private string _experienceProperty;
        private double _levelPercentageProperty;
        public string UsernameProperty
        {
            get { return _usernameProperty; }
            set
            {
                _usernameProperty = value;
                OnPropertyChanged(nameof(UsernameProperty));
            }
        }
        public string LevelProperty
        {
            get { return _levelProperty; }
            set
            {
                _levelProperty = value;
                OnPropertyChanged(nameof(LevelProperty));
            }
        }
        public string ExperienceProperty
        {
            get { return _experienceProperty; }
            set
            {
                _experienceProperty = value;
                OnPropertyChanged(nameof(ExperienceProperty));
            }
        }
        public double LevelPercentageProperty
        {
            get { return _levelPercentageProperty; }
            set
            {
                _levelPercentageProperty = value;
                OnPropertyChanged(nameof(LevelPercentageProperty));
            }
        }
        public AppShell()
        {
            InitializeComponent();
        }
        public AppShell(string username)
        {
            InitializeComponent();
            BindingContext = this;
                                                // Using input (firstName + lastName) from user and creating User object
            User user = new User(username);     // Then calling method SetupFlyoutHeader() to display the relevant User fields
            SetupFlyoutHeader(user);            // and other UI features (such as progress bar)

        }       

                    // SetupFlyoutHeader() only used for the first time
                    // the flyout header is created, afterwards, use UpdateFlyoutHeader()
        public void SetupFlyoutHeader(User user)
        {
            UsernameProperty = user.Name;
            UpdateFlyoutHeader(user);
        }

                    // UpdateFlyoutHeader() updates level, exp, and progress bar in the flyout header
        public void UpdateFlyoutHeader(User user)
        {
            LevelProperty = "Level " + user.Level.ToString();
            ExperienceProperty = user.Experience.ToString() + @"/" + user.RequiredExperience.ToString();
            LevelPercentageProperty = user.LevelPercentage();
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
