

namespace FxApp.Base.Helpers
{
    using System;

    public static class HelperConverterUnixDate
    {
        private static readonly DateTime UnixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();

        public static DateTime DateTimeFromUnixTimestampSeconds(long seconds)
        {
            long sec = (long)(Math.Round(seconds / 1000d));
            return UnixEpoch.AddSeconds(sec);
        }

        public static long ConvertToUnixTime(DateTime datetime)
        {
            //DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - UnixEpoch).TotalSeconds;
            //return (long)datetime.Ticks;

        }

    }
}
