using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Flyout_Test
{
    public class User
    {        
        public string Name { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }

        public int RequiredExperience = 250;       

        public User (string name)
        {
            Name = name;
            Level = 1;
            Experience = 0;
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
                    // LevelPercentage() used to calulate the percentage of the user progress
                    // (exp / required exp) before proceeding to the next level (used for progress bar)
        public double LevelPercentage()
        {
            return this.Experience / this.RequiredExperience;
        }
    }
}
