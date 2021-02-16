using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMotorPool.Pool
{
    public interface INotificationSystem
    {
        void ShowSystem(string message);

        void ShowConsole(string message);
    }
}
