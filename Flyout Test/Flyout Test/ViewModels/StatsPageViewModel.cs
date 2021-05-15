using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.ViewModels
{
    class StatsPageViewModel : BaseViewModel
    {
        public StatsPageViewModel()
        {

        }
        public void OnAppearing()
        {
            OpenedFlyoutPage = OpenedPage.StatsPage;
            //IsToDoPageOpen = true;
        }
        public void OnDisappearing()
        {
            //IsStatsPageOpen = false;
        }
    }
}
