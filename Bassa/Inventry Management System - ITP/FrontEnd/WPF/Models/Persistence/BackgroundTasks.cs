using Models.APICall;
using System.Threading;

namespace Models.Persistence
{
    public static class BackgroundTasks
    {
        private static bool SystemTimeCounter;
        private static bool ServerConnectionChecker;
        private static System.Timers.Timer SystemTimeCountTimer;
        private static System.Timers.Timer ServerConnectionCheckTimer;

        static BackgroundTasks()
        {
            SystemTimeCounter = false;
            ServerConnectionChecker = false;
        }


        public static void StartBackGroundTasks()
        {
            StartSystemTimeCounter();
            StartServerConnectionChecker();
        }

        private static void StartSystemTimeCounter()
        {
            if (!BackgroundTasks.SystemTimeCounter)
            {
                try
                {
                    Thread TimerThread = new Thread(() =>
                    {
                        SystemTimeCountTimer = new System.Timers.Timer();
                        SystemTimeCountTimer.Interval = 1 * 1000;
                        SystemTimeCountTimer.Elapsed += (s, e) =>
                        {
                            InventryMangementSystemDbContext.ServerDateTime.Time++;
                        };
                        SystemTimeCountTimer.Enabled = true;

                        BackgroundTasks.SystemTimeCounter = true;
                    });

                    TimerThread.Start();
                }
                catch { }
            }
        }

        private static void StartServerConnectionChecker()
        {
            if (!BackgroundTasks.ServerConnectionChecker)
            {
                try
                {
                    Thread TimerThread = new Thread(() =>
                    {
                        ServerConnectionCheckTimer = new System.Timers.Timer();
                        ServerConnectionCheckTimer.Interval = 5 * 1000;
                        ServerConnectionCheckTimer.Elapsed += async (s, e) =>
                        {                            
                            await new ServerConnectionAPICall().CheckServerStatus();
                        };
                        ServerConnectionCheckTimer.Enabled = true;

                        BackgroundTasks.ServerConnectionChecker = true;
                    });

                    TimerThread.Start();
                }
                catch { }
            }
        }
    }
}
