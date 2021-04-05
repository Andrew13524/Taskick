using Flyout_Test;
using System;
using System.Collections.ObjectModel;
using Taskick.Models;
using Xamarin.Forms;
using Taskick.Services;
using Taskick.Models;
using Flyout_Test.Views;
using System.Windows.Input;
using System.Collections.Generic;

namespace Taskick.Services
{
    public class DataStore
    {
        static User currentUser = new User();
        public static User CurrentUser { get { return currentUser; } }


        private static ObservableCollection<Goal> goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList { get { return goalList; } }


        static string selectedGoalID;
        public static string SelectedGoalID => selectedGoalID;


        private static List<Goal> completedGoals = new List<Goal>();
        public static List<Goal> CompletedGoals { get { return completedGoals; } }


        private static int selectedGoalIndex => GetGoalIndex();
        public static int SelectedGoalIndex { get { return selectedGoalIndex; } }

        public DataStore()
        {

        }
        public DataStore(User user) => currentUser = user;
        public DataStore(Goal goal, string mode)
        {
            if (mode == "Add") goalList.Add(goal);
            else if (mode == "Complete")
            {
                foreach (Goal completedGoal in CompletedGoals)
                {
                    if (completedGoal.Id == goal.Id)
                    {
                        return;
                    }
                }
                currentUser.UpdateLevel(goal.ExpValue);
                Application.Current.MainPage = new AppShell();
                completedGoals.Add(goal);
            }
        }
        public DataStore (string selectedGoalId) => selectedGoalID = selectedGoalId;
        public DataStore(Goal goal, int exp)
        {
            if (SelectedGoalID != goal.Id) // Checks if goal EXP has already been added or not
            {
                currentUser.UpdateLevel(exp); // Adding exp to user
                Application.Current.MainPage = new AppShell();

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
