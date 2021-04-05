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
        //static int goalChecked = 0;
        //public static int GoalChecked 
        //{ 
        //    get 
        //    {
        //        return goalChecked;
        //    }
        //    set
        //    {
        //        if (goalChecked < 3) goalChecked = value; // This is terrible
        //        else goalChecked = 1;                      // FIX AT SOME POINT !!!!!
        //    }
        //}
        public ToDoPage()
        {
            InitializeComponent();
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
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
                    if (goal.IsCompleted)
                    {
                        new DataStore(goal, "Complete");
                        //new AppShellViewModel();
                    }
                    return;
                }
            }
        }
    }
}