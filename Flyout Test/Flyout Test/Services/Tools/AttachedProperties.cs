using System.Threading.Tasks;
using Taskick.Models;
using Taskick.Services.DataStorage;
using Xamarin.Forms;

namespace Taskick.Services
{
    public static class AttachedProperties
    {
        private static int _currentLevel = UserDataStore.CurrentUser.Level;

        public static BindableProperty AnimatedProgressProperty =
           BindableProperty.CreateAttached("AnimatedProgress",
                                           typeof(double),
                                           typeof(ProgressBar),
                                           0.0d,
                                           BindingMode.OneWay,
                                           propertyChanged: async (b, o, n) =>
                                           await ProgressBarProgressChanged((ProgressBar)b, (double)n));

        private static async Task ProgressBarProgressChanged(ProgressBar progressBar, double progress)
        {
            ViewExtensions.CancelAnimations(progressBar);

            while (UserDataStore.CurrentUser.Level > _currentLevel)
            {
                await progressBar.ProgressTo(1, 500, Easing.SinOut);
                await progressBar.ProgressTo(0, 500, Easing.Linear);
                _currentLevel++;
            }
                
            await progressBar.ProgressTo((double)progress, 1000, Easing.SinOut);
        }
    }
}
