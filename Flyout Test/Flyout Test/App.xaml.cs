using Flyout_Test.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Flyout_Test
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            // For testing purposes, clearing preferences on each startup            
            Preferences.Clear();
            // On Startup, go to Welcome Page
            MainPage = new NavigationPage(new WelcomePage());          
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
