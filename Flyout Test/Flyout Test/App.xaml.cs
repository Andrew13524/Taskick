using Flyout_Test.Services;
using Flyout_Test.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            
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
