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
            OpenedPage = Page.WalkingPage;
        }
    }
}
