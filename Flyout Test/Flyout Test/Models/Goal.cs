using Flyout_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Taskick.Scripts
{
    public class Goal : BaseViewModel
    {
        private static int _goalID = 0;
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Difficulty { get; set; }
        public ICommand ButtonCommand { get; private set; }
        public string GoalTitle // Just for testing
        {
            get { return $"{Name} {DueDate} {Difficulty}"; }
        }
        public Goal()
        {
            
        }
        public Goal(string name, DateTime dueDate, string difficulty)
        {
            Name = name;
            DueDate = dueDate;
            Difficulty = difficulty;

            _goalID++;
        }
    }
}
