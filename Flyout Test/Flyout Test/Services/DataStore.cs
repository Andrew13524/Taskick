using System.Collections.ObjectModel;
using Taskick.Models;
using System.Collections.Generic;

namespace Taskick.Services
{
    public class DataStore
    {

        private static ObservableCollection<Goal> goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList { get { return goalList; } }


        private static string selectedGoalID;
        public static string SelectedGoalID => selectedGoalID;


        private static List<Goal> completedGoals = new List<Goal>();
        public static List<Goal> CompletedGoals { get { return completedGoals; } }


        private static int selectedGoalIndex => GetGoalIndex();
        public static int SelectedGoalIndex { get { return selectedGoalIndex; } }

        public DataStore()
        {

        }  
        public DataStore (string selectedGoalId) => selectedGoalID = selectedGoalId;
        public DataStore(Goal goal, string mode)
        {
            if (mode == "Add") goalList.Add(goal);
            else if (mode == "Complete")
            {
                foreach (Goal completedGoal in CompletedGoals) // Check if exp for completed goal has already been added
                {
                    if (completedGoal.Id == goal.Id)
                    {
                        return;
                    }
                }
                User.UpdateLevel(goal.ExpValue);
                new User();
                completedGoals.Add(goal);
            }
        }

        public void ChangeGoal(Goal changedGoal) => goalList[SelectedGoalIndex] = changedGoal;
        public static int GetGoalIndex()
        {
            foreach (Goal goal in goalList)
            {
                if (selectedGoalID == goal.Id)
                {
                    return goalList.IndexOf(goal); 
                }
            }
            return 0;
        }
    }
}
