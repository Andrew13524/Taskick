using Taskick.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Taskick.Services;

[assembly: ExportFont("Asap-Bold.ttf",              Alias = "Asap-Bold")]
[assembly: ExportFont("Asap-BoldItalic.ttf",        Alias = "Asap-BoldItalic")]
[assembly: ExportFont("Asap-Italic.ttf",            Alias = "Asap-Italic")]
[assembly: ExportFont("Asap-Medium.ttf",            Alias = "Asap-Medium")]
[assembly: ExportFont("Asap-MediumItalic.ttf",      Alias = "Asap-MediumItalic")]
[assembly: ExportFont("Asap-Regular.ttf",           Alias = "Asap-Regular")]
[assembly: ExportFont("Asap-SemiBold.ttf",          Alias = "Asap-SemiBold")]
[assembly: ExportFont("Asap-SemiBoldItalic.ttf",    Alias = "Asap-SemiBoldItalic")]
namespace Flyout_Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Clearing Preferences for testing purposes
            //Preferences.Clear();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            // On Startup, go to Welcome Page
            MainPage = new NavigationPage(new WelcomePage());          
        }
        
        protected override void OnStart()
        {
            DataStore.LoadFromFile();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
