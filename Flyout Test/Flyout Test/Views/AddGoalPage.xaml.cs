using System;
using Taskick.Services;
using Taskick.Models;
using Taskick.ViewModels;
using Xamarin.Forms.Xaml;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGoalPage 
    {
        public AddGoalPage(string mode)
        {
            InitializeComponent();
            BindingContext = new AddGoalPageViewModel(mode);
        }
        private async void AddGoalButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(goalName.Text) && dueDatePicker.Date != null && difficultySelector.SelectedItem != null)
            {                
                if (AddGoalPageViewModel.State == Mode.Add) // If adding a goal, execute save command with new instance of a goal object
                {
                    ((AddGoalPageViewModel)BindingContext).SaveCommand.Execute(new Goal()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = goalName.Text,
                        DueDate = dueDatePicker.Date,
                        Difficulty = difficultySelector.SelectedItem.ToString()
                    });

                    await Navigation.PopAsync();
                }                   
                else if (AddGoalPageViewModel.State == Mode.Edit) // If editing a goal, execute save command with the currently selected goal object ID
                {
                    ((AddGoalPageViewModel)BindingContext).SaveCommand.Execute(new Goal()
                    {
                        Id = DataStore.SelectedGoalID,
                        Name = goalName.Text,
                        DueDate = dueDatePicker.Date,
                        Difficulty = difficultySelector.SelectedItem.ToString()
                    });
                    
                    await Navigation.PopModalAsync();
                }                                  
            }
            else
                await DisplayAlert("Empty field", "Please fill in the fields.", "Ok");
        }
        async void OnDeleteButton_CLicked(object sender, EventArgs e)
        {
            ((AddGoalPageViewModel)BindingContext).DeleteCommand.Execute(DataStore.SelectedGoalID);
            await Navigation.PopModalAsync();
        }
    }
}