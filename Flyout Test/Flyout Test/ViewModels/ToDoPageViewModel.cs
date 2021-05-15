using System.Collections.ObjectModel;
using Taskick.Services;
using Taskick.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Android.Content.Res;
using Taskick.Views;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using System;

namespace Taskick.ViewModels
{
    class ToDoPageViewModel : BaseViewModel
    {
        ObservableCollection<Goal> goals = DataStore.GoalList;
        public ObservableCollection<Goal> Goals
        {
            get => goals;
            set
            {
                goals = value;
                OnPropertyChanged(nameof(Goals));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        private bool _isGoalListNull = true;
        public bool IsGoalListNull
        {
            get => _isGoalListNull;
            set
            {
                _isGoalListNull = value;
                OnPropertyChanged(nameof(IsGoalListNull));
            }
        }

        public ToDoPageViewModel()
        {
            LoadGoalsCommand = new Command(LoadGoals);
            GoToAddGoalPageCommand = new Command(GoToAddGoalPage);
        }

        public ICommand LoadGoalsCommand { get; }
        private void LoadGoals()
        {
            IsBusy = true;

            DataStore.UpdateGoalList();

            Goals = DataStore.GoalList;

            if (Goals.Count > 0) IsGoalListNull = false;
            else                 IsGoalListNull = true;

            IsBusy = false;
        }

        public ICommand GoToAddGoalPageCommand { get; }
        public async void GoToAddGoalPage()
        {
            AddGoalPageViewModel.SaveState = SaveState.ADD;
            await Application.Current.MainPage.Navigation.PushAsync(new AddGoalPage());
        }

        public void OnAppearing()
        {
            //IsToDoPageOpen = true;
            OpenedFlyoutPage = OpenedPage.ToDoPage;
            IsBusy = true;
        }
        public void OnDisappearing()
        {
            //IsToDoPageOpen = true;
        }
    }
}
