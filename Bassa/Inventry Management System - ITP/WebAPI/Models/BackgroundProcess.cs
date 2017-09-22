using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebAPI.Models
{
    public static class BackgroundProcess
    {
        public static void CallBackgroundProcesses()
        {
            Debug.WriteLine("CallBackgroundProcesses Started");

            try
            {
                Thread CounterOnlineStatusThread = new Thread(CounterOnlineStatus);
                CounterOnlineStatusThread.Start();
            }
            catch { }

            Debug.WriteLine("CallBackgroundProcesses Over");
        }

        #region Background Process of make all online apps to offline

        public static bool CountersChanged;
        public static List<Counter> CheckingOnlineCounters = new List<Counter>();

        public static void CounterOnlineStatus()
        {
            System.Timers.Timer Timer = new System.Timers.Timer();
            Timer.Elapsed += SetOnlineAppsToOffline;
            Timer.Interval = 10 * 1000;
            Timer.Enabled = true;

            Thread.Sleep(15000);
            Debug.WriteLine("CounterOnlineStatus ended");
        }

        private static void SetOnlineAppsToOffline(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine("Called");
        }



        #endregion
    }
}