using System;
using Taskick.Services;
using Taskick.Models;
using Xamarin.Forms;
using Taskick.Views;
using System.Windows.Input;
using Xamarin.Essentials;
using Java.Sql;
using Taskick.Services.DataStorage;

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
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
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
                        Title = "Enter title here";
                        Description = "Enter description here";
                        DueDate = DateTime.Today;
                        Difficulty = "Easy";
                        SaveButtonText = "Add Quest";
                        IsDeleteButtonVisible = false;
                        break;
                    }
                case SaveState.UPDATE:
                    {
                        Title = GoalDataStore.GoalList[GoalDataStore.GetGoalIndex()].Title;
                        Description = GoalDataStore.GoalList[GoalDataStore.GetGoalIndex()].Description;
                        DueDate = GoalDataStore.GoalList[GoalDataStore.GetGoalIndex()].DueDate;
                        Difficulty = GoalDataStore.GoalList[GoalDataStore.GetGoalIndex()].Difficulty;
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
            if (OpenedPage != Page.AddGoalPage)
                return;

            if (!string.IsNullOrWhiteSpace(Title))
                {
                    switch (SaveState)
                    {
                        case SaveState.ADD:       // If adding a goal, execute AddGoal command with new instance of a goal object
                            {
                                AddGoal(new Goal(Title, Description, DueDate, Difficulty));
                                break;
                            }
                        case SaveState.UPDATE:      // If updating a goal, execute EditGoal command with the currently selected goal object ID
                            {
                                EditGoal(new Goal()
                                {
                                    Id = GoalDataStore.SelectedGoalId,
                                    Title = Title,
                                    Description = Description,
                                    DueDate = DueDate,
                                    Difficulty = Difficulty
                                });
                                break;
                            }
                    }
                }
        }

        public async void AddGoal(Goal newGoal)
        {
            new GoalDataStore(newGoal, SaveState.ADD);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void EditGoal(Goal editedGoal)
        {
            new GoalDataStore(editedGoal, SaveState.UPDATE);
            OpenedPage = Page.ToDoPage;
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public ICommand DeleteCommand { get; }
        public async void DeleteCommandExecute()
        {
            if (OpenedPage != Page.AddGoalPage)
                return;

            new GoalDataStore(new Goal()        // Deleting selected goal from Datastore
            {
                Id = GoalDataStore.SelectedGoalId,
                Title = Title,
                DueDate = DueDate,
                Difficulty = Difficulty
            },
            SaveState.DELETE);

            OpenedPage = Page.ToDoPage;
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        public void OnAppearing()
        {
            OpenedPage = Page.AddGoalPage;
        }
    }
}
