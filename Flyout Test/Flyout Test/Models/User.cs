using System;

namespace Taskick.Models
{
    public class User
    {              
        public int RequiredExperience = 250;
        public string Name { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }
        public double LevelPercentage { get; set; }
        public User(string name)
        {
            Name = name;
            Level = 1;
            Experience = 0;      // (exp / required exp) before proceeding to the next level (used for progress bar)
            LevelPercentage = Experience / RequiredExperience;
        }
        public void UpdateLevel(double experience)
        {
            this.Experience += experience;
            if (Experience >= RequiredExperience) // Checks if user has enough experience to lvl
            {                                     // If so, subtract experience value and ++lvl
                this.Experience -= RequiredExperience;
                this.Level++;

                // Multiplying required experience to lvl up by 1.5, and rounding to the nearest 50
                RequiredExperience = Convert.ToInt32(Math.Floor((RequiredExperience * 1.5) / 50) * 50);
            }
        }
    }
}
