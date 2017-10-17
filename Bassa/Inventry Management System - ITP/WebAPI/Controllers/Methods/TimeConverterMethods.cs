using System;

namespace WebAPI.Controllers.Methods
{
    public class TimeConverterMethods
    {
        private static readonly DateTime _initialStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //private static readonly TimeZoneInfo _initialTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time");

        public static long GetCurrentTimeInLong()
        {
            //DateTime Now = TimeZoneInfo.ConvertTime(DateTime.Now, _initialTimeZone);
            //return (long)Now.Subtract(_initialStartDate).TotalSeconds;
            return (long)DateTime.UtcNow.Subtract(_initialStartDate).TotalSeconds + (long)(5.5 * 60 * 60);
        }
    }
}