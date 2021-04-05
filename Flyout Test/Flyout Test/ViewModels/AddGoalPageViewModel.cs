using System;
using Taskick.Services;
using Taskick.Models;
using Xamarin.Forms;
using Flyout_Test.Views;
using System.Windows.Input;

enum Mode { Add, Edit }

namespace Taskick.ViewModels
{
    class AddGoalPageViewModel : BaseViewModel
    {
        Goal goal = new Goal();
        public Goal Goal { get { return goal; } }

        string addGoalButtonText;
        public string AddGoalButtonText { get { return addGoalButtonText; } }

        bool isDeleteButtonVisible;
        public bool IsDeleteButtonVisible { get { return isDeleteButtonVisible; } }

        public static Mode State;

        public AddGoalPageViewModel()
        {

        }
        public AddGoalPageViewModel(string mode)
        {
            if (mode == "Add")
            {
                State = Mode.Add;

                addGoalButtonText = "Add Task";

                goal.Name = "Enter text here";
                goal.DueDate = DateTime.Now;
                goal.Difficulty = "Easy";
                isDeleteButtonVisible = false;
            }
            else if (mode == "Edit")
            {
                State = Mode.Edit;

                addGoalButtonText = "Save";
                var index = DataStore.SelectedGoalIndex;
                goal = DataStore.GoalList[index];
                isDeleteButtonVisible = true;
            }

            DeleteCommand = new Command(DeleteGoal);
            SaveCommand = new Command<Goal>(SaveGoal);
        }
        public Command<Goal> SaveCommand { get; }
        public async void SaveGoal(Goal selectedGoal)
        {
            if (State == Mode.Add)
            {
                new DataStore(selectedGoal, "Add");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else if (State == Mode.Edit)
            {
                DataStore ds = new DataStore();
                ds.ChangeGoal(selectedGoal);
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
        public ICommand DeleteCommand { get; }

        public async void DeleteGoal()
        {
            foreach (Goal goal in DataStore.GoalList)
            {
                if (DataStore.SelectedGoalID == goal.Id)
                {
                    DataStore.GoalList.Remove(goal);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    return;
                }
            }
        }
    }
}
