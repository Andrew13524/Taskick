using System.Collections.ObjectModel;
using Taskick.Services;
using Taskick.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Android.Content.Res;
using Flyout_Test.Views;
using System.Threading.Tasks;

namespace Taskick.ViewModels
{
    class ToDoPageViewModel : BaseViewModel
    {
        ObservableCollection<Goal> goalList = DataStore.GoalList;
        public ObservableCollection<Goal> GoalList { get { return goalList; } }

        public ICommand GoToAddGoalPageCommand { get; }

        public ToDoPageViewModel()
        {
            this.GoToAddGoalPageCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new AddGoalPage("Add"));
            });

            goalList = DataStore.GoalList; // To refresh the list
        }
    }
}
