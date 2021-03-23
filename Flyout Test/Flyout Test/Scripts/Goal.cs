using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.Scripts
{
    public class Goal
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Difficulty { get; set; }

        public Goal(string title, DateTime dueDate, string difficulty)
        {
            Title = title;
            DueDate = dueDate;
            Difficulty = difficulty;
        }
    }
}
