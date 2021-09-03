using System;
using System.Collections.Generic;
using System.Text;

namespace Taskick.Services
{
    public interface IAndroidService
    {
        void StartService();

        void StopService();
    }
}
