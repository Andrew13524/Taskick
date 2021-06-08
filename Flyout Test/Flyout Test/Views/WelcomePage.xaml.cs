using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskick.ViewModels;

namespace Taskick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private readonly WelcomePageViewModel _viewModel;
        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WelcomePageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}