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
            OpenedPage = Page.StatsPage;
        }
    }
}
