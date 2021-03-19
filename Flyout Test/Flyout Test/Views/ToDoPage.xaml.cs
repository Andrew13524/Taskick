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
    public partial class ToDoPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }
        public ToDoPage(string title, DateTime dueDate, string difficulty)
        {
            InitializeComponent();

            Goal newGoal = new Goal(title, dueDate, difficulty);
                                                    // Makes labels on ToDoPage, with title, date, and diffuclty as set on AddTaskPage.
            CoolLabelStack.Children.Add(new Label { Text = newGoal.Title, TextColor = Color.FromHex("#77d065"), FontSize = 20 , FontAttributes = FontAttributes.Bold });
            CoolLabelStack.Children.Add(new Label { Text = newGoal.DueDate.ToString(), TextColor = Color.FromHex("#77d065"), FontSize = 20, FontAttributes = FontAttributes.Bold });
            CoolLabelStack.Children.Add(new Label { Text = newGoal.TaskDifficulty.ToString(), TextColor = Color.FromHex("#77d065"), FontSize = 20, FontAttributes = FontAttributes.Bold });

            // Go back to previous page...?
            Application.Current.MainPage.Navigation.PopAsync();
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }
    }
}