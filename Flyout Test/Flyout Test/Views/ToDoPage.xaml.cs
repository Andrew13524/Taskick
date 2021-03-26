using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskick.Scripts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Taskick.ViewModels;
using Xamarin.Essentials;
using System.Windows.Input;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage
    {
        public ICommand ButtonCommand { get; private set; }
        public ToDoPage()
        {
            InitializeComponent();
        }
        
        private async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}