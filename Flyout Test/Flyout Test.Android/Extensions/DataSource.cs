using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;
using Taskick.Models;
using Taskick.Services;
using Taskick.Services.DataStorage;
using Taskick.ViewModels;
using Xamarin.Forms;

namespace Flyout_Test.Droid.Extensions
{
    [Service]
    public class DataSource : Service
    {

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public const int ServiceRunningNotifID = 9000;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Notification notif = DependencyService.Get<INotification>().ReturnNotif();
            StartForeground(ServiceRunningNotifID, notif);

            CountSteps();

            return StartCommandResult.Sticky;
        }
        public void CountSteps()
        {
            UserDataStore.CurrentUser.Steps += 1;
            new UserDataStore(UserDataStore.CurrentUser, SaveState.UPDATE);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }


    }
}
