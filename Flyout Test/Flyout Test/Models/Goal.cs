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
        private bool _isLate = false;
        public bool IsLate 
        { 
            get => _isLate; 
            set
            {
                _isLate = value;
                if (IsLate)
                {
                    DateColor = "#f05454"; // Red
                    BlueColor = "#f05454"; // Red
                }
                else
                {
                    DateColor = "#2196f3"; // Blue
                    BlueColor = "#2196f3"; // Blue
                }
            }
        }

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {                                   // If completed, cannot be uncompleted
                if (!_isCompleted)
                {
                    _isCompleted = value;

                    if (IsLate)
                    {
                        ExpBackgroundColor = "#883535"; // RedPressedColor
                        BlueColor = "#883535"; // RedPressedColor
                    }
                    else
                    {
                        ExpBackgroundColor = "#1a5889"; // BluePressedColor
                        BlueColor = "#1a5889"; // BluePressedColor
                    }
                    
                    GreyColor = "#6c6c6c"; // GreyPressedColor
                    DarkColor = "#1d1d1d"; // DarkPressedColor

                    OnPropertyChanged(nameof(IsCompleted));
                }
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
            if(date == DateTime.Today)
            {
                return "Today";
            }
            else if (date < DateTime.Today)
            {
                return "Late";
            }
            else if (Convert.ToInt32(date.ToString("yyyy")) == Convert.ToInt32(DateTime.Today.ToString("yyyy")))
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
