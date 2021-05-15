using System;
using Taskick.Services;
using Taskick.Models;
using Taskick.ViewModels;
using Xamarin.Forms.Xaml;

namespace Taskick.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGoalPage 
    {
        private readonly AddGoalPageViewModel _viewModel;
        
        public AddGoalPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AddGoalPageViewModel();
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