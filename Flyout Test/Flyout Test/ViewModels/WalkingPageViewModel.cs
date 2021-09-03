using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Taskick.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Taskick.ViewModels
{
    class WalkingPageViewModel : BaseViewModel
    {
        private bool _isWalking;
        public bool IsWalking
        {
            get => Preferences.Get(nameof(_isWalking), false);
            set
            {
                Preferences.Set(nameof(_isWalking), value);
                OnPropertyChanged(nameof(IsWalking));
            }
        }

        public WalkingPageViewModel()
        {
            RefreshCommand = new Command(RefreshCommandExecute);
            StartWalkCommand = new Command(StartWalkCommandExecute);
            StopWalkCommand = new Command(StopWalkCommandExecute);
        }

        public ICommand StartWalkCommand { get; }
        public void StartWalkCommandExecute()
        {
            DependencyService.Get<IAndroidService>().StartService();
            IsWalking = true;
        }
        public ICommand StopWalkCommand { get; }
        public void StopWalkCommandExecute()
        {
            DependencyService.Get<IAndroidService>().StopService();
            IsWalking = false;
        }
        public ICommand RefreshCommand { get; }
        public void RefreshCommandExecute()
        {
            IsBusy = true;

            UpdateUserInfo();

            IsBusy = false;
        }

        public void OnAppearing()
        {
            OpenedPage = Page.WalkingPage;
            IsBusy = true;
        }
    }
}
