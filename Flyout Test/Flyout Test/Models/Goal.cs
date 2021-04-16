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
        public int ExpValue => GetExpValue();
        public string DisplayedDueDate => GetDateName(DueDate);

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {                                   // If completed, cannot be uncompleted
                if (!_isCompleted)
                {
                    _isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        private bool _isDisplayedDueDateVisible = true;
        public bool IsDisplayedDueDateVisible
        {
            get { return _isDisplayedDueDateVisible; }
            set 
            { 
                _isDisplayedDueDateVisible = value;
                OnPropertyChanged(nameof(IsDisplayedDueDateVisible));
            }
        }

        public Goal()
        {
            
        }
        public Goal(string title, DateTime dueDate, string difficulty)
        {
            Title = title;
            DueDate = dueDate;
            Difficulty = difficulty;
            Id = Guid.NewGuid().ToString();
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
    }
}
