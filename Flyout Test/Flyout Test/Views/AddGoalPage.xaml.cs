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
    public partial class AddGoalPage
    {
        DateTime DueDate;
        string GoalTitle;
        string Difficulty;

        public static List<Goal> Goals = new List<Goal>();
        public AddGoalPage()
        {
            InitializeComponent();
        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            DueDate = dueDatePicker.Date;
        }
        private void AddGoalButton_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(goalName.Text) && DueDate != null && difficultySelector.SelectedItem != null)
            {
                GoalTitle = goalName.Text;
                Difficulty = difficultySelector.SelectedItem.ToString();

                Goals.Add(new Goal(GoalTitle, DueDate, Difficulty));

                Application.Current.MainPage = new AppShell(Goals);
            }
            else

                return;

        }
    }
}