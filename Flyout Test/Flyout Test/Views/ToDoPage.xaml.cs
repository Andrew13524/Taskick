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
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;
            if ((e.CurrentSelection[0] as Goal).IsCompleted) // If goal already completed, do not execute
                return;

            new DataStore((e.CurrentSelection[0] as Goal).Id);
            
            await Navigation.PushModalAsync(new AddGoalPage("Edit"));

            ((CollectionView)sender).SelectedItem = null; // Deselecting goal
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkedGoal = sender as CheckBox;

            foreach (Goal goal in DataStore.GoalList)
            {
                if (checkedGoal.ClassId == goal.Id)
                {
                    new DataStore(goal, "Complete");    // Completing the selected goal
                    return;
                }
            }
        }
    }
}