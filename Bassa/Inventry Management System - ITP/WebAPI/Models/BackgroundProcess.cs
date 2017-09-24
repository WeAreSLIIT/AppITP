using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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
        }

        #region Background Process of make all online apps to offline

        private static bool CounterOnlineStatusProcessRunning = false;
        private static List<Counter> CheckingOnlineCounters = new List<Counter>();
        private static List<Counter> LastOnlineCounters = new List<Counter>();

        private static void InitializingCountersList()
        {
            CheckingOnlineCounters = new UnitOfWork().Counters.Search(c => c.Disabled == false).ToList();
        }

        private static void CounterOnlineStatus()
        {
            InitializingCountersList();

            if (!(CheckingOnlineCounters == null || CheckingOnlineCounters.Count == 0))
            {
                System.Timers.Timer Timer = new System.Timers.Timer();

                Timer.Elapsed += (s, e) =>
                {
                    Debug.WriteLine("Background Process - CounterOnlineStatus Called");

                    LastOnlineCounters.Clear();

                    CheckingOnlineCounters.Where(c => c.Online == true).ToList()
                        .ForEach((Counter c) =>
                        {
                            Counter OldCounter = new Counter()
                            {
                                CounterID = c.CounterID,
                                BranchID = c.BranchID,
                                BranchCounterNo = c.BranchCounterNo
                            };
                            LastOnlineCounters.Add(OldCounter);

                            c.Online = false;
                            Debug.WriteLine("Set all online counters to offline");
                        });
                };

                Timer.Interval = 10 * 1000;
                Timer.Enabled = true;
                CounterOnlineStatusProcessRunning = true;
            }
            else
                CounterOnlineStatusProcessRunning = false;
        }

        public static bool? CheckCounterIsOnline(long CounterID)
        {
            Counter ResultCounter = CheckingOnlineCounters.SingleOrDefault(c => c.CounterID == CounterID);

            if (ResultCounter == null)
                return null;

            if (ResultCounter.Online)
                return true;

            Counter PreviousCounters = LastOnlineCounters.SingleOrDefault(c => c.CounterID == CounterID);

            if (PreviousCounters == null)
                return false;

            return true;
        }

        public static bool? CheckCounterIsOnline(long BranchID, long CounterNo)
        {
            Counter ResultCounter = CheckingOnlineCounters.SingleOrDefault(c => c.BranchID == BranchID && c.BranchCounterNo == CounterNo);

            if (ResultCounter == null)
                return null;

            return CheckCounterIsOnline(ResultCounter.CounterID);
        }

        public static void RefreshCounterOnlineStatus()
        {
            if (CounterOnlineStatusProcessRunning)
                InitializingCountersList();
            else
                CounterOnlineStatus();
        }

        #endregion
    }
}