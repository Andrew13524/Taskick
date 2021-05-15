using System.Collections.ObjectModel;
using Taskick.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms.Internals;

namespace Taskick.Services
{
    public class DataStore
    {

        private readonly static ObservableCollection<Goal> _goalList = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> GoalList => _goalList;

        public static string SelectedGoalId;
        public static int SelectedGoalIndex => GetGoalIndex();

        readonly static List<Goal> _completedGoals = new List<Goal>();

        private static string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Goals.txt");
        private static Assembly _assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataStore)).Assembly;

        public DataStore(Goal goal, SaveState saveState)
        {
            switch (saveState)
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
                case SaveState.DELETE:
                    {
                        DeleteGoal(goal);
                        break;
                    }
                case SaveState.COMPLETE:
                    {
                        CompleteGoal(goal);
                        break;
                    }
            }
            SaveToFile();
        }

        public void AddGoal(Goal newGoal) => GoalList.Add(newGoal);
        public void EditGoal(Goal editedGoal) => GoalList[SelectedGoalIndex] = editedGoal;
        public void DeleteGoal(Goal deletedGoal)
        {
            foreach (Goal goal in GoalList)
            {
                if (deletedGoal.Id == goal.Id)
                {
                    GoalList.Remove(goal);
                    return;
                }
            }
        }
        public void CompleteGoal(Goal completedGoal)
        {
            foreach(Goal goal in _completedGoals)
            {
                if (completedGoal.Id == goal.Id) return; // If exp already added, return
            }
            User.UpdateLevel(completedGoal.ExpValue);

            _completedGoals.Add(completedGoal);
        }
        
        public static void UpdateGoalList()
        {
            RemoveCompletedGoals();
            SortDatesAscending();
            GetIsDueDateVisible();
            IsGoalLate();
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
                        if (GoalList[i].DisplayedDueDate == GoalList[j].DisplayedDueDate)
                        {
                            GoalList[j].IsDisplayedDueDateVisible = false;
                        }
                    }
                }
            }
        }
        public static void IsGoalLate()
        {
            foreach(Goal goal in GoalList)
            {
                if (goal.DueDate < DateTime.Today) goal.IsLate = true;
                else goal.IsLate = false;
            }
        }

        public static void LoadFromFile()
        {
            GoalList.Clear();

            string[] lines = File.ReadAllLines(_path);

            for (int i = 0; i < lines.Length; i+=3)
            {
                string Title = lines[i];
                DateTime DueDate = Convert.ToDateTime(lines[i + 1]);
                string Difficulty = lines[i + 2];

                GoalList.Add(new Goal(Title, DueDate, Difficulty));
            }
        }
        public static void SaveToFile()
        {
            string content = null;

            foreach (Goal goal in GoalList)
            {
                if(!goal.IsCompleted) content += ($"{goal.Title}\n{goal.DueDate}\n{goal.Difficulty}\n");
            }

            File.WriteAllText(_path, content);
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
