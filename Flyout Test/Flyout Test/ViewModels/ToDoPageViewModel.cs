using System.Collections.ObjectModel;
using Taskick.Services;
using Taskick.Models;

namespace Taskick.ViewModels
{
    class ToDoPageViewModel : BaseViewModel
    {
        ObservableCollection<Goal> goalList = DataStore.GoalList;
        public ObservableCollection<Goal> GoalList { get { return goalList; } }

        public ToDoPageViewModel()
        {
            goalList = DataStore.GoalList; // To refresh the list
        }
    }
}
