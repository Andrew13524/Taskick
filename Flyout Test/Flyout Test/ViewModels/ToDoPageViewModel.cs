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
using Taskick.Services.DataStorage;

namespace Taskick.ViewModels
{
    class ToDoPageViewModel : BaseViewModel
    {
        ObservableCollection<Goal> goals = GoalDataStore.GoalList;
        public ObservableCollection<Goal> Goals
        {
            get => goals;
            set
            {
                goals = value;
                OnPropertyChanged(nameof(Goals));
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

            GoalDataStore.UpdateGoalList();

            Goals = GoalDataStore.GoalList;

            if (Goals.Count > 0) IsGoalListNull = false;
            else                 IsGoalListNull = true;

            IsBusy = false;
        }

        public ICommand GoToAddGoalPageCommand { get; }
        public async void GoToAddGoalPage()
        {
            if (OpenedPage != Page.ToDoPage)
                return;

            AddGoalPageViewModel.SaveState = SaveState.ADD;
            await Application.Current.MainPage.Navigation.PushAsync(new AddGoalPage());
        }

        public void OnAppearing()
        {
            OpenedPage = Page.ToDoPage;
            IsBusy = true;
        }
    }
}
