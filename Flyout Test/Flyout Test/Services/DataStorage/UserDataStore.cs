using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Taskick.Models;

namespace Taskick.Services.DataStorage
{
    public class UserDataStore : IDataStore<User>
    {
        public static User CurrentUser = new User();

        private static readonly string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.txt");

        public UserDataStore(User user, SaveState saveState)
        {
            switch (saveState)
            {
                case SaveState.ADD:
                    {
                        AddItem(user);
                        break;
                    }
                case SaveState.UPDATE:
                    {
                        UpdateItem(user);
                        break;
                    }
                case SaveState.DELETE:
                    {
                        DeleteItem(user);
                        break;
                    }
                case SaveState.COMPLETE:
                    {
                        throw new NotSupportedException();
                    }
            }
            SaveToFile();
        }
        public void AddItem(User user) // Used when creating new user
        {
            CurrentUser = new User
            {
                Name = user.Name
            };
        }
        public void UpdateItem(User user)
        {
            CurrentUser.Name = user.Name;
            CurrentUser.Level = user.Level;
            CurrentUser.Experience = user.Experience;
            CurrentUser.RequiredExperience = user.RequiredExperience;
            CurrentUser.LevelPercentage = user.LevelPercentage;
            CurrentUser.Steps = user.Steps;
        }
        public void DeleteItem(User item)
        {
            throw new NotImplementedException();
        }

        public static void SaveToFile()
        {
            File.WriteAllText(_path, $"{CurrentUser.Name}\n{CurrentUser.Level}\n{CurrentUser.Experience}\n" +
                                     $"{CurrentUser.RequiredExperience}\n{CurrentUser.LevelPercentage}\n{CurrentUser.Steps}");
        }
        public static void LoadFromFile()
        {
            if (!File.Exists(_path))
                return;

            string[] lines = File.ReadAllLines(_path);

            for (int i = 0; i < lines.Length; i += 6)
            {
                CurrentUser.Name = lines[i];
                CurrentUser.Level = Convert.ToInt32(lines[i + 1]);
                CurrentUser.Experience = Convert.ToInt32(lines[i + 2]);
                CurrentUser.RequiredExperience = Convert.ToInt32(lines[i + 3]);
                CurrentUser.LevelPercentage = Convert.ToDouble(lines[i + 4]);
                CurrentUser.Steps = Convert.ToInt32(lines[i + 5]);
            }
        }

        public static void UpdateLevel(double experience)
        {
            CurrentUser.Experience += (int)experience;

            while (CurrentUser.Experience >= CurrentUser.RequiredExperience) // Checks if user has enough experience to lvl
            {                                                                // If so, subtract experience value and ++lvl
                CurrentUser.Experience -= CurrentUser.RequiredExperience;
                CurrentUser.Level++;

                // Multiplying required experience to lvl up by 1.5, and rounding to the nearest 50
                CurrentUser.RequiredExperience = (int)Math.Floor((CurrentUser.RequiredExperience * 1.5) / 50) * 50;
            }

            CurrentUser.LevelPercentage = (double)CurrentUser.Experience / CurrentUser.RequiredExperience;

            new UserDataStore(CurrentUser, SaveState.UPDATE);
        }
    }
}
