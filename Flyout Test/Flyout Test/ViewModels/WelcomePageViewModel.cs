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
        private string _firstName = "Enter your first name";
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName = "Enter your last name";
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public WelcomePageViewModel()
        {
            GoToMainPageCommand = new Command(GoToMainPage);
        }
        public ICommand GoToMainPageCommand { get; }
        public async void GoToMainPage()
        {
            if (!IsLoggedIn)
            {
                if ($"{FirstName} {LastName}".Length > 17)
                {
                    await App.Current.MainPage.DisplayAlert("Name is too long", null, "Ok");
                    return;
                }
                User.Name = $"{FirstName} {LastName}";
            }
            Application.Current.MainPage = new AppShell();
        }    
    }
}
