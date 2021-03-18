using Flyout_Test.ViewModels;
using Flyout_Test.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Flyout_Test
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private string _usernameProperty; // Properties linked to XAML
        private string _levelProperty;
        private string _experienceProperty;
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
        public AppShell(string username)
        {
            InitializeComponent();
            BindingContext = this;

            User user = new User(username);
            SetupFlyoutHeader(user);
        }
        public void SetupFlyoutHeader(User user)
        {
            UsernameProperty = user.Name;
            LevelProperty = "Level " + user.Level.ToString();
            ExperienceProperty = user.Experience.ToString() + @"/" + user.RequiredExperience.ToString();
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
