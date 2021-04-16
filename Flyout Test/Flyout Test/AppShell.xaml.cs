using System;
using Taskick.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Taskick.ViewModels;
using Flyout_Test.Views;
using System.ComponentModel;

namespace Flyout_Test
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddGoalPage), typeof(AddGoalPage));
            
            PropertyChanged += Shell_PropertyChanged;
        }
        private void Shell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FlyoutIsPresented"))
                if (FlyoutIsPresented) OnFlyoutOpened();
                else OnFlyoutClosed();
        }
        public void OnFlyoutOpened()
        {
            
            BindingContext = new AppShellViewModel(); // each time the flyout menu is opened, refresh user values
        }
        public void OnFlyoutClosed()
        {

        }
    }
}
