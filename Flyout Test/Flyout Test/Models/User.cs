using System;
using Taskick.ViewModels;
using Xamarin.Essentials;

namespace Taskick.Models
{
    public class User : BaseViewModel
    {             
        public static string Name { get; set; }
        public static string Level { get { return $"Level {_level}"; } }
        public static string Experience { get { return $"{_experience}/{_requiredExperience}"; } }
        public static double LevelPercentage { get { return _experience / _requiredExperience; } } // Used for progress bar

        private static int _level { get; set; }
        private static double _experience { get; set; }
        private static double _requiredExperience = 250;
               
        
        public User()
        {

        }
        public User(string name)
        {
            Name = name;
            _level = 1;
            _experience = 0;      
        }
        public static void UpdateLevel(double experience)
        {
            _experience += experience;
            
            while (_experience >= _requiredExperience) // Checks if user has enough experience to lvl
            {                                          // If so, subtract experience value and ++lvl
                _experience -= _requiredExperience;
                _level++;

                // Multiplying required experience to lvl up by 1.5, and rounding to the nearest 50
                _requiredExperience = Convert.ToInt32(Math.Floor((_requiredExperience * 1.5) / 50) * 50);
            }
        }
    }
}
