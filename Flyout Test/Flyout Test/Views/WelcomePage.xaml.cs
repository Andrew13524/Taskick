using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void DoneButton_Clicked(object sender, EventArgs e)
        {           
                // If user enters first and last name, open AppShell
            if (firstName.Text.Length > 0 && lastName.Text.Length > 0)
                Application.Current.MainPage = new AppShell(firstName.Text + " " + lastName.Text);
            else
                return; // Create warning "Please enter your name."           
        }
    }
}