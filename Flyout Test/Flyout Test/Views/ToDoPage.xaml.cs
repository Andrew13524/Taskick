using System;
using Xamarin.Forms.Xaml;
using Taskick.ViewModels;
using Taskick.Services;
using Xamarin.Forms;
using Taskick.Models;
using System.Linq;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage
    {
        public ToDoPage()
        {
            InitializeComponent();
            BindingContext = new ToDoPageViewModel();
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingContext = new ToDoPageViewModel();
            Goal selectedGoal = new Goal();

            foreach(Goal currentGoal in e.CurrentSelection)
            {
                foreach (Goal goal in DataStore.GoalList)
                {
                    if (currentGoal.Id == goal.Id)
                    {
                        selectedGoal.Name = goal.Name;
                        selectedGoal.DueDate = goal.DueDate;
                        selectedGoal.Difficulty = goal.Difficulty;
                        selectedGoal.Id = goal.Id;
                    }
                }
            }
                             

            new DataStore(selectedGoal, false);

            await Navigation.PushModalAsync(new AddGoalPage("Edit"));
        }
        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage("Add"));
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
        }
    }
}