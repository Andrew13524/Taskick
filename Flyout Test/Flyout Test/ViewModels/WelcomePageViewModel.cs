using Flyout_Test;
using Taskick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Taskick.ViewModels
{
    class WelcomePageViewModel : BaseViewModel
    {
        public string FirstName
        {
            get => Preferences.Get(nameof(FirstName), "Enter your first name");
            set
            {
                Preferences.Set(nameof(FirstName), value);
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => Preferences.Get(nameof(LastName), "Enter your last name");
            set
            {
                Preferences.Set(nameof(LastName), value);
                OnPropertyChanged(nameof(LastName));
            }
        }

        public WelcomePageViewModel()
        {
            GoToMainPageCommand = new Command(GoToMainPage);
        }
        public ICommand GoToMainPageCommand { get; }
        public void GoToMainPage()
        {
            User.Name = $"{FirstName + LastName}";
            Application.Current.MainPage = new AppShell();
        }    
    }
}
