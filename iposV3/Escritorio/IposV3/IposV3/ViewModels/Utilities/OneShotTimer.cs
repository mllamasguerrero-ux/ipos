using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels.utilities
{
    public class OneShotTimer
    {

        private volatile Action _callback;
        private OneShotTimer(Action callback, long msTime)
        {
            _callback = callback;
            var timer = new System.Threading.Timer(TimerProc);
            timer.Change(msTime, System.Threading.Timeout.Infinite);
        }

        private void TimerProc(object? state)
        {
            try
            {
                // The state object is the Timer object. 
                ((System.Threading.Timer?)state)?.Dispose();
                _callback.Invoke();
            }
            catch (Exception ex)
            {
                // Handle unhandled exceptions
                Console.WriteLine(ex.Message);
            }
        }

        public static OneShotTimer Start(Action callback, TimeSpan time)
        {
            return new OneShotTimer(callback, Convert.ToInt64(time.TotalMilliseconds));
        }
        public static OneShotTimer Start(Action callback, long msTime)
        {
            return new OneShotTimer(callback, msTime);
        }
    }
}
