using System;
using Xamarin.Forms.Xaml;
using Taskick.ViewModels;
using Taskick.Services;
using Xamarin.Forms;
using Taskick.Models;
using System.Linq;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Taskick.Services.DataStorage;

namespace Taskick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage
    {
        private readonly ToDoPageViewModel _viewModel;
        public ToDoPage()          
        { 
            InitializeComponent();
            BindingContext = _viewModel = new ToDoPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) return;              // If selection null or already completed, do not execute

            GoalDataStore.SelectedGoalId = (e.CurrentSelection[0] as Goal).Id; // Selecting goal

            if (!GoalDataStore.GoalList[GoalDataStore.GetGoalIndex()].IsCompleted)
            {
                AddGoalPageViewModel.SaveState = SaveState.UPDATE;        // Opening edit state of AddGoalPage
                await Navigation.PushModalAsync(new AddGoalPage());
            }
            
            ((CollectionView)sender).SelectedItem = null;  // Deselecting goal
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkedGoal = sender as CheckBox;

            foreach (Goal goal in GoalDataStore.GoalList)
            {
                if (checkedGoal.ClassId == goal.Id)
                {

                    new GoalDataStore(goal, SaveState.COMPLETE);        // Completing the selected goal & updating values

                    _viewModel.UpdateUserInfo();

                    return;
                }
            }
        }
    }
}