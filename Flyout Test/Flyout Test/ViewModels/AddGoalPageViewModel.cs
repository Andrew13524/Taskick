using System;
using Taskick.Services;
using Taskick.Models;
using Xamarin.Forms;

enum Mode { Add, Edit }

namespace Taskick.ViewModels
{
    class AddGoalPageViewModel : BaseViewModel
    {
        Goal selectedGoal = new Goal();
        public Goal SelectedGoal { get { return selectedGoal; } }

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
                selectedGoal.Name = "Enter text here";
                selectedGoal.DueDate = DateTime.Now;
                selectedGoal.Difficulty = "Easy";
                isDeleteButtonVisible = false;
            }
            else if (mode == "Edit")
            {
                State = Mode.Edit;

                addGoalButtonText = "Save";
                var index = DataStore.SelectedGoalIndex;
                selectedGoal = DataStore.GoalList[index];
                isDeleteButtonVisible = true;
            }

            OnPropertyChanged(addGoalButtonText);
            UpdateGoal();

            DeleteCommand = new Command<string>(DeleteGoal);
            SaveCommand = new Command<Goal>(SaveGoal);
        }
        public Command<Goal> SaveCommand { get; }
        public void SaveGoal(Goal selectedGoal)
        {
            if(State == Mode.Add) new DataStore(selectedGoal);
            
            else if(State == Mode.Edit)
            {
                DataStore ds = new DataStore();
                ds.ChangeGoal(selectedGoal);                   
            }
        }
        public Command<string> DeleteCommand { get; }

        public void DeleteGoal(string selectedGoalID)
        {
            foreach (Goal goal in DataStore.GoalList)
            {
                if (selectedGoalID == goal.Id)
                {
                    DataStore.GoalList.Remove(goal);
                    return;
                }
            }
        }
        public void UpdateGoal()
        {
            OnPropertyChanged(selectedGoal.Name);
            OnPropertyChanged(selectedGoal.DueDate.ToString());
            OnPropertyChanged(selectedGoal.Difficulty);
        }
    }
}
