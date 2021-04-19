using System;
using Taskick.ViewModels;
using Xamarin.Essentials;

namespace Taskick.Models
{
    public static class User
    {
        public static string Name { get; set; }
        public static double LevelPercentage { get; set; } // Used for progress bar

        private static int _level = 1;
        public static int Level
        {
            get => _level;
            set => _level = value;
        }

        private static int _experience = 0;
        public static int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        private static int _requiredExperience = 250;
        public static int RequiredExperience 
        {
            get => _requiredExperience;
            set => _requiredExperience = value;
        }


        public static void UpdateLevel(double experience)
        {
            Experience += (int)experience;
            
            while (Experience >= RequiredExperience) // Checks if user has enough experience to lvl
            {                                          // If so, subtract experience value and ++lvl
                Experience -= RequiredExperience;
                Level++;

                // Multiplying required experience to lvl up by 1.5, and rounding to the nearest 50
                RequiredExperience = (int)Math.Floor((RequiredExperience * 1.5) / 50) * 50;
            }

            LevelPercentage = (double)Experience / RequiredExperience;
        }
    }
}
