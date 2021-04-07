using System;
using Taskick.ViewModels;
using Xamarin.Essentials;

namespace Taskick.Models
{
    public class Goal : BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Difficulty { get; set; }
        public int ExpValue { get { return GetExpValue(); } }

        public bool IsCompleted
        {
            get
            {
                return Preferences.Get(nameof(IsCompleted) + Id, false);
            }
            set
            {                                   // If completed, cannot be uncompleted
                if (this.IsCompleted == true) Preferences.Set(nameof(IsCompleted) + Id, true); 
                else                          Preferences.Set(nameof(IsCompleted) + Id, value);
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        public Goal()
        {
            
        }
        public Goal(string name, DateTime dueDate, string difficulty)
        {
            AssignValues(name, dueDate, difficulty);
            Id = Guid.NewGuid().ToString();
        }
        public Goal(string name, DateTime dueDate, string difficulty, string id)
        {
            AssignValues(name, dueDate, difficulty);
            Id = id;
        }
        public void AssignValues(string name, DateTime dueDate, string difficulty)
        {
            Name = name;
            DueDate = dueDate;
            Difficulty = difficulty;
            IsCompleted = false;
        }
        public int GetExpValue()
        {
            if (!string.IsNullOrEmpty(Difficulty))
            {
                if (Difficulty == "Easy") return 100;
                else if (Difficulty == "Medium") return 200;
                else if (Difficulty == "Hard") return 350;
                else if (Difficulty == "Extreme") return 500;
            }
            return 0;
        }
    }
}
