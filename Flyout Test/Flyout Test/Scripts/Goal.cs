using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.Scripts
{
    public class Goal
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard,
            Extreme
        }
        public Difficulty TaskDifficulty;
        public Goal(string title, DateTime dueDate, string difficulty)
        {
            Title = title;
            DueDate = dueDate;
            SetDifficulty(difficulty);
        }

                    // Based off what the user selected in the picker (combobox)
                    // SetDifficulty() sets difficulty to correct state
        public void SetDifficulty(string difficulty)
        {
            if (difficulty.Equals("Easy"))
                TaskDifficulty = Difficulty.Easy;
            else if (difficulty.Equals("Medium"))
                TaskDifficulty = Difficulty.Medium;
            else if (difficulty.Equals("Hard"))
                TaskDifficulty = Difficulty.Hard;
            else if (difficulty.Equals("Extreme"))
                TaskDifficulty = Difficulty.Extreme;
        }
    }
}
