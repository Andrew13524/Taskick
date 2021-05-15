using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.ViewModels
{
    class WalkingPageViewModel : BaseViewModel
    {
        public WalkingPageViewModel()
        {

        }
        public void OnAppearing()
        {
            OpenedFlyoutPage = OpenedPage.WalkingPage;
            //IsWalkingPageOpen = true;
        }
        public void OnDisappearing()
        {
            //IsWalkingPageOpen = false;
        }
    }
}
