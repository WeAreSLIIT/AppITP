using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceHandlingApplication.Model
{
    public static class TimeManager
    {
        private static DateTime _initialDateTime;

        public static DateTime InitialDateTime
        {
            get { return _initialDateTime; }
        }
        
        private static DateTime _systemDateAndTime;

        public static DateTime SystemDateAndTime
        {
            get { return _systemDateAndTime; }
        }

        private static long _timeStamp;

        public static long TimeStamp
        {
            get { return _timeStamp; }
        }

        static TimeManager()
        {
            _initialDateTime = new DateTime(1970, 1, 1, 0, 0, 0);
        }

        public static void StartTime(long TimeStamp)
        {
            _timeStamp = TimeStamp;
        }
    }
}
