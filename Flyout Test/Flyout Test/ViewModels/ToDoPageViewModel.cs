using System.Collections.ObjectModel;
using Taskick.Services;
using Taskick.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Android.Content.Res;
using Flyout_Test.Views;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace Taskick.ViewModels
{
    class ToDoPageViewModel : BaseViewModel
    {
        ObservableCollection<Goal> goals = DataStore.GoalList;
        public ObservableCollection<Goal> Goals => goals;

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

            goals = DataStore.GoalList;

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
            IsBusy = true;
        }
    }
}
