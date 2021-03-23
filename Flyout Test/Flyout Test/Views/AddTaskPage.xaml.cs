using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskick.Scripts;
using Taskick.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage
    {
        public DateTime DueDate;
        public string GoalTitle;
        public string Difficulty;
        
        public AddTaskPage()
        {
            InitializeComponent();            
        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            DueDate = dueDatePicker.Date;
        }
        private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            if (taskName.Text.Length > 0 && DueDate != null && difficultySelector.SelectedItem.ToString() != null)
            {
                GoalTitle = taskName.Text;
                Difficulty = difficultySelector.SelectedItem.ToString();
                Application.Current.MainPage = new AppShell(GoalTitle, DueDate, Difficulty);
            }
            else
            
                return;
            
        }
    }
}