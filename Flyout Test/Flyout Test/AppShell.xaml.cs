using Flyout_Test.ViewModels;
using Flyout_Test.Views;
using System;
using Taskick.Scripts;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskick.ViewModels;

namespace Flyout_Test // BindingContext = new AppShellViewModel();
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        public AppShell(string username) // Used for when user first enters their name on Welcome Page
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel(username);            
        }       
        public AppShell(List<Goal> goals) // Used for when user enters task
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel(goals);            
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
