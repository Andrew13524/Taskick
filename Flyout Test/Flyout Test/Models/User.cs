using System;
using Taskick.ViewModels;
using Xamarin.Essentials;

namespace Taskick.Models
{
    public class User
    {
        public string Name { get; set; }
        public double LevelPercentage { get; set; } // Used for progress bar

        private int _level = 1;
        public int Level
        {
            get => _level;
            set => _level = value;
        }

        private int _experience = 0;
        public int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        private int _requiredExperience = 250;
        public int RequiredExperience 
        {
            get => _requiredExperience;
            set => _requiredExperience = value;
        }

        private int _steps = 0;
        public int Steps
        {
            get => _steps;
            set => _steps = value;
        }
    }
}
