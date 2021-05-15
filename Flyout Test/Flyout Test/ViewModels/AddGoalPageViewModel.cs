using System;
using Taskick.Services;
using Taskick.Models;
using Xamarin.Forms;
using Taskick.Views;
using System.Windows.Input;
using Xamarin.Essentials;
using Java.Sql;

namespace Taskick.ViewModels
{
    class AddGoalPageViewModel : BaseViewModel
    {
        public static SaveState SaveState;
        public string SaveButtonText { get; set; }
        public bool IsDeleteButtonVisible { get; set; }
        
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private DateTime _dueDate;
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        private string _difficulty;
        public string Difficulty
        {
            get => _difficulty;
            set
            {
                _difficulty = value;
                OnPropertyChanged(nameof(Difficulty));
            }
        }



        public AddGoalPageViewModel()
        {
            switch (SaveState)
            {
                case SaveState.ADD: // Setting labels, dates, and difficulties upon page opening
                    {
                        Title = "Enter text here";
                        DueDate = DateTime.Today;
                        Difficulty = "Easy";
                        SaveButtonText = "Add Goal";
                        IsDeleteButtonVisible = false;
                        break;
                    }
                case SaveState.EDIT:
                    {
                        Title = DataStore.GoalList[DataStore.GetGoalIndex()].Title; 
                        DueDate = DataStore.GoalList[DataStore.GetGoalIndex()].DueDate;
                        Difficulty = DataStore.GoalList[DataStore.GetGoalIndex()].Difficulty;
                        SaveButtonText = "Save";
                        IsDeleteButtonVisible = true;
                        break;
                    }
            }

            SaveCommand = new Command(SaveButtonCommandExecute);
            DeleteCommand = new Command(DeleteCommandExecute);
        }

        public ICommand SaveCommand { get; }
        public void SaveButtonCommandExecute()
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                switch (SaveState)
                {
                    case SaveState.ADD:       // If adding a goal, execute AddGoal command with new instance of a goal object
                        {
                            AddGoal(new Goal(Title, DueDate, Difficulty));
                            break;
                        }
                    case SaveState.EDIT:      // If editing a goal, execute EditGoal command with the currently selected goal object ID
                        {
                            EditGoal(new Goal()
                            {
                                Id = DataStore.SelectedGoalId,
                                Title = Title,
                                DueDate = DueDate,
                                Difficulty = Difficulty
                            });
                            break;
                        }
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("", "Please Enter a Title", "Ok");
            }
        }

        public async void AddGoal(Goal newGoal)
        {
            new DataStore(newGoal, SaveState.ADD);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void EditGoal(Goal editedGoal)
        {
            new DataStore(editedGoal, SaveState.EDIT);
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public ICommand DeleteCommand { get; }
        public async void DeleteCommandExecute()
        {
            new DataStore(new Goal()        // Deleting selected goal from Datastore
            {
                Id = DataStore.SelectedGoalId,
                Title = Title,
                DueDate = DueDate,
                Difficulty = Difficulty
            },
            SaveState.DELETE);

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        public void OnAppearing()
        {
            //IsAddGoalPageOpen = true;
        }
        public void OnDisappearing()
        {
            //IsAddGoalPageOpen = false;
        }
    }
}
