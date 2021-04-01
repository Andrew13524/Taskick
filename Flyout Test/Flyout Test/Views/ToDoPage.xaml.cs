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
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var test = GoalCollectionView.SelectedItem;
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            var selectedGoalId = (e.CurrentSelection[0] as Goal).Id;

            new DataStore(selectedGoalId);

            await Navigation.PushModalAsync(new AddGoalPage("Edit"));

            ((CollectionView)sender).SelectedItem = null; // Deselecting goal
        }
        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage("Add"));
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            GoalCollectionView.SelectedItem = this;
            DisplayAlert((GoalCollectionView.SelectedItem as Goal).Name, "Test", "OK");
        }
    }
}