using System.Collections.ObjectModel;
using Taskick.Models;
using System.Collections.Generic;
using System;

namespace Taskick.Services
{
    public class DataStore
    {
        public static SaveState SaveState;


        private static ObservableCollection<Goal> goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList => goalList;


        public static string SelectedGoalId;
        public static int SelectedGoalIndex => GetGoalIndex(); 

        public DataStore(Goal goal)
        {
            switch (SaveState)
            {
                case SaveState.ADD:
                    {
                        AddGoal(goal);
                        break;
                    }
                case SaveState.EDIT:
                    {
                        EditGoal(goal);
                        break;
                    }
                case SaveState.COMPLETE:
                    {
                        CompleteGoal(goal);
                        break;
                    }
            }
        }

        public void AddGoal(Goal newGoal) => GoalList.Add(newGoal);
        public void EditGoal(Goal editedGoal) => GoalList[SelectedGoalIndex] = editedGoal;
        public void CompleteGoal(Goal completedGoal) => User.UpdateLevel(completedGoal.ExpValue);
        
        public static void UpdateGoalList()
        {
            RemoveCompletedGoals();
            SortDatesAscending();
            GetIsDueDateVisible();
        }
        public static void RemoveCompletedGoals()
        {
            for (int i = 0; i < GoalList.Count; i++)
            {
                if (GoalList[i].IsCompleted)        // If completed, remove from list
                {
                    GoalList.RemoveAt(i--);
                }
            }
        }
        public static void SortDatesAscending()
        {
            var sortedList = new List<Goal>();

            foreach (Goal goal in GoalList)
            {
                sortedList.Add(goal);
            }

            sortedList.Sort((x, y) => DateTime.Compare(x.DueDate, y.DueDate));

            GoalList.Clear();

            foreach (Goal goal in sortedList)
            {
                GoalList.Add(goal);
            }
        }
        public static void GetIsDueDateVisible()
        {
            foreach(Goal goal in GoalList)
            {
                goal.IsDisplayedDueDateVisible = true; // Reseting IsDisplayedDueDateVisible each time
            }
            for (int i = 0; i <= GoalList.Count - 1; i++)
            {
                if (GoalList[i].IsDisplayedDueDateVisible)
                {
                    for (int j = i+1; j <= GoalList.Count - 1; j++)
                    {
                        if (GoalList[i].DueDate == GoalList[j].DueDate)
                        {
                            GoalList[j].IsDisplayedDueDateVisible = false;
                        }
                    }
                }
            }
        }

        public static int GetGoalIndex()
        {
            foreach (Goal goal in GoalList)
            {
                if (SelectedGoalId == goal.Id)
                {
                    return GoalList.IndexOf(goal); 
                }
            }
            return 0;
        }       
    }
}
