using System;
using System.Collections.ObjectModel;
using Taskick.Models;

namespace Taskick.Services
{
    public class DataStore
    {
        private static ObservableCollection<Goal> goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList { get { return goalList; } }

        static string selectedGoalID;
        public static string SelectedGoalID { get { return selectedGoalID; } }

        private static int selectedGoalIndex => GetSelectedGoalIndex();
        public static int SelectedGoalIndex { get { return selectedGoalIndex; } }

        public DataStore()
        {
            
        }
        public DataStore(Goal newGoal)
        {
           goalList.Add(newGoal);
        }
        public DataStore (string selectedGoalId)
        {
            selectedGoalID = selectedGoalId;
        }
        public void ChangeGoal(Goal changedGoal)
        {
            foreach(Goal goal in goalList)
            {
                if(changedGoal.Id == goal.Id)
                {               
                    goalList[SelectedGoalIndex] = changedGoal;
                    break;
                }
            }
        }
        public static int GetSelectedGoalIndex()
        {
            foreach (Goal goal in goalList)
            {
                if (selectedGoalID == goal.Id)
                {
                    return goalList.IndexOf(goal); ;
                }
            }
            return 0;
        }
    }
}
