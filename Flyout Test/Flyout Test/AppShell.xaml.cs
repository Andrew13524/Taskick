using System;
using Taskick.Models;
using System.Collections.Generic;
using Xamarin.Forms;
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
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
