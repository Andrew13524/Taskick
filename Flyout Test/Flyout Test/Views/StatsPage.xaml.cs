using Taskick.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        private readonly StatsPageViewModel _viewModel;
        public StatsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new StatsPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}