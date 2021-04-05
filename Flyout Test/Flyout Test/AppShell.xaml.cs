using System;
using Taskick.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Taskick.ViewModels;
using Flyout_Test.Views;

namespace Flyout_Test 
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddGoalPage), typeof(AddGoalPage));

            BindingContext = new AppShellViewModel();
        }
    }
}
