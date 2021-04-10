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


        private static List<DateTime> goalDates = new List<DateTime>();
        public static List<DateTime> GoalDates => SortAscending(goalDates); // Displaying goal dates in order


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

        public void AddGoal(Goal newGoal)
        {
            goalList.Add(newGoal);
        }
        public void EditGoal(Goal editedGoal) => goalList[SelectedGoalIndex] = editedGoal;
        public void CompleteGoal(Goal completedGoal)
        {
            User.UpdateLevel(completedGoal.ExpValue);
        }
        public static void UpdateGoalList()
        {
            for (int i = 0; i < GoalList.Count; i++)
            {
                if (GoalList[i].IsCompleted)        // If completed, remove from list
                {
                    GoalList.RemoveAt(i--);
                }
            }
        }
        public static int GetGoalIndex()
        {
            foreach (Goal goal in goalList)
            {
                if (SelectedGoalId == goal.Id)
                {
                    return goalList.IndexOf(goal); 
                }
            }
            return 0;
        }
        static List<DateTime> SortAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }
    }
}
