using System;
using Xamarin.Essentials;
using Taskick.ViewModels;

namespace Taskick.Models
{
    public class Goal : BaseModel
    {
        private string _id;
        public string Id 
        { 
            get => _id; 
            set => _id = value; 
        }
        private string _title;
        public string Title 
        {
            get => _title;
            set => _title = value;
        }
        private string _description = null;
        public string Description
        {
            get => _description;
            set
            {
                if (value == String.Empty)
                    IsDescriptionEmpty = true;
                else
                    IsDescriptionEmpty = false;

                _description = value;
                return;
            }
        }
        private DateTime _dueDate;
        public DateTime DueDate 
        {
            get => _dueDate;
            set => _dueDate = value;
        }
        private string _difficulty;
        public string Difficulty 
        {
            get => _difficulty;
            set => _difficulty = value;
        }
        public int ExpValue => GetExpValue();
        public string DisplayedDueDate => GetDateName(DueDate);

        private bool _isDescriptionEmpty;
        public bool IsDescriptionEmpty
        {
            get => _isDescriptionEmpty;
            set => _isDescriptionEmpty = value;
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
        public Goal(string title, string description, DateTime dueDate, string difficulty)
        {
            Title = title;
            Description = description;
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
            if (date < DateTime.Today)
                return "Due";
            else if (date.ToString("yyyy") == DateTime.Today.ToString("yyyy")) // if current year
            {
                if (date == DateTime.Today) // if today
                    return "Today";
                else if (Convert.ToInt32(date.ToString("dd")) == Convert.ToInt32(DateTime.Today.ToString("dd")) + 1) // if tommorow
                    return "Tomorrow";
                else if (Convert.ToInt32(date.ToString("dd")) < Convert.ToInt32(DateTime.Today.ToString("dd")) + 7) // if this week
                    return date.ToString("dddd");

                return date.ToString("MMMM d");
            }
            else
                return date.ToString("MMMM d, yyyy");
        }       
    }
}
