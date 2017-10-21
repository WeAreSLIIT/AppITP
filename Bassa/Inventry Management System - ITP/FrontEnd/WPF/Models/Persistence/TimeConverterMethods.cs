using System;

namespace Models.Persistence
{
    public class TimeConverterMethods
    {
        private static readonly DateTime _initialStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //private static readonly TimeZoneInfo _initialTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time");

        public static long GetCurrentTimeInLong()
        {
            return InventryMangementSystemDbContext.ServerDateTime.Time;
        }

        public static DateTime GetCurrentTimeInDateTime()
        {
            return _initialStartDate.AddSeconds(TimeConverterMethods.GetCurrentTimeInLong());
        }

        public static long GetCurrentDateInLong()
        {
            DateTime NowDate = TimeConverterMethods.GetCurrentTimeInDateTime();
            return TimeConverterMethods.GetCustomTimeInLong(NowDate);
        }

        private static long GetCustomTimeInLong(DateTime CustomDateTime)
        {
            return (long)new DateTime(CustomDateTime.Year, CustomDateTime.Month, CustomDateTime.Day, 0, 0, 0)
                .Subtract(_initialStartDate).TotalSeconds;
        }
    }
}
