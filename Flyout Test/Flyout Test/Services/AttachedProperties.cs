using System.Threading.Tasks;
using Taskick.Models;
using Xamarin.Forms;

namespace Taskick.Services
{
    public static class AttachedProperties
    {
        private static int _currentLevel = User.Level;

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

            while (User.Level > _currentLevel)
            {
                await progressBar.ProgressTo(1, 1000, Easing.SinOut);
                await progressBar.ProgressTo(0, 500, Easing.Linear);
                _currentLevel++;
            }
                
            await progressBar .ProgressTo((double)progress, 1000, Easing.SinOut);
        }
    }
}
