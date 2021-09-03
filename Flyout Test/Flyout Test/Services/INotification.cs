using Android.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.Services
{
    public interface INotification
    {
        Notification ReturnNotif();
    }
}
