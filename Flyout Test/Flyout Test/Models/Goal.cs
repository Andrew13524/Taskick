﻿using System;

namespace Taskick.Models
{
    public class Goal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Difficulty { get; set; }
        public int ExpValue { get { return GetExpValue(Difficulty); } }
        public bool IsCompleted { get; set; }
        public bool IsEnabled { get { return !IsCompleted; } } // Determines checkbox can be clicked or not
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
        public int GetExpValue(string difficulty)
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
