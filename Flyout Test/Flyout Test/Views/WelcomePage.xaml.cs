using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskick.Models;
using Taskick.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {    
        public WelcomePage()
        {
            InitializeComponent();
        }
        private async void DoneButton_Clicked(object sender, EventArgs e)
        {
            // If user enters first and last name, open AppShell
            if ((!string.IsNullOrWhiteSpace(firstName.Text) && !string.IsNullOrWhiteSpace(lastName.Text)) && firstName.Text != "Enter your first name" && lastName.Text != "Enter your last name")
            {
                if (firstName.Text.Length + lastName.Text.Length <= 17) // 18
                {
                    User.Name = $"{firstName.Text} {lastName.Text}";
                    Application.Current.MainPage = new AppShell();
                }
                else await DisplayAlert("", "Sorry, the name you entered is too long", "OK");               
            }
            else await DisplayAlert("", "Please enter your full name", "OK");


        }
    }
}