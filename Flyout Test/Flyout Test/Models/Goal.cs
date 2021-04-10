using System;
using Xamarin.Essentials;
using Taskick.ViewModels;

namespace Taskick.Models
{
    public class Goal : BaseModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Difficulty { get; set; }

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {                                   // If completed, cannot be uncompleted
                if (!_isCompleted) _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public int ExpValue => GetExpValue();

        public string DisplayedDate => GetDateName(DueDate);
        public bool IsDisplayedDateVisible = true; // setting true for testing purposes
        
        public Goal()
        {
            
        }
        public Goal(string title, DateTime dueDate, string difficulty)
        {
            AssignValues(title, dueDate, difficulty);
            Id = Guid.NewGuid().ToString();
        }
        public Goal(string title, DateTime dueDate, string difficulty, string id)
        {
            AssignValues(title, dueDate, difficulty);
            Id = id;
        }

        public void AssignValues(string title, DateTime dueDate, string difficulty)
        {
            Title = title;
            DueDate = dueDate;
            Difficulty = difficulty;
            IsCompleted = false;
        }
        public int GetExpValue()
        {
            return Difficulty switch
            {
                "Easy" => 100,
                "Medium" => 200,
                "Hard" => 350,
                "Extreme" => 500,
                _ => 0,
            };
        }
        public static string GetDateName(DateTime date)
        {
            if (Convert.ToInt32(date.ToString("yyyy")) == Convert.ToInt32(DateTime.Today.ToString("yyyy")))
            {
                return date.ToString("MMMM d");
            }
            else
            {
                return date.ToString("MMMM d, yyyy");
            }
        }
        //public bool GetIsDueDateVisible(DateTime dateTime)
        //{
        //    for (int i = 0; i < DataStore.GoalList.Count - 1; i++)
        //    {
        //        if (dateTime == DataStore.GoalList[i].DueDate)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
