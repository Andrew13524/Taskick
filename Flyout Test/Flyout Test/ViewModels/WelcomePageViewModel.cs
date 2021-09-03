using Flyout_Test;
using Taskick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Taskick.Services.DataStorage;

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
            if (!HasAccount)
            {
                if ($"{FirstName} {LastName}".Length > 17)
                {
                    await App.Current.MainPage.DisplayAlert("Warning", "Name is too long", "Ok");
                    return;
                }

                new UserDataStore(new User { Name = $"{FirstName} {LastName}" },
                                  SaveState.ADD);
                HasAccount = true;
            }
            Application.Current.MainPage = new AppShell();
        }   
        public void OnAppearing()
        {
            OpenedPage = Page.WelcomePage;
        }
    }
}
