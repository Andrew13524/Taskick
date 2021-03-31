using System;
using System.Collections.ObjectModel;
using Taskick.Models;

namespace Taskick.Services
{
    public class DataStore
    {
        private static ObservableCollection<Goal> goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList { get { return goalList; } }

        static Goal selectedGoal;
        public static Goal SelectedGoal { get { return selectedGoal; } }

        private static int selectedGoalIndex => GetSelectedGoalIndex();
        public static int SelectedGoalIndex { get { return selectedGoalIndex; } }

        public DataStore()
        {
            
        }
        public DataStore(Goal newGoal, bool inList) // Whever you want to add new goal to static observable list, or as selected goal
        {
            if (inList) goalList.Add(newGoal);
            else selectedGoal = newGoal;
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
                if (selectedGoal.Id == goal.Id)
                {
                    return goalList.IndexOf(goal); ;
                }
            }
            return 0;
        }
    }
}
