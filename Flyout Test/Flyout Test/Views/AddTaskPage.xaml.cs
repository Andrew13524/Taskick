using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskick.Scripts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public DateTime DueDate;
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
                var MyAppsFirstPage = new ToDoPage(taskName.Text, DueDate, difficultySelector.SelectedItem.ToString());
                //Application.Current.MainPage.Navigation.PushAsync(MyAppsFirstPage);
                //Application.Current.MainPage = new ToDoPage(taskName.Text, DueDate, difficultySelector.SelectedItem.ToString());
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.Navigation.PushAsync(MyAppsFirstPage);
                //Application.Current.MainPage.Navigation.
            }
            else
                return;
            
        }
    }
}