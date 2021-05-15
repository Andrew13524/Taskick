using Taskick.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalkingPage : ContentPage
    {
        private readonly WalkingPageViewModel _viewModel;
        public WalkingPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WalkingPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }
    }
}