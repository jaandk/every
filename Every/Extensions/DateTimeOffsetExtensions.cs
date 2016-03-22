using System;

namespace Every.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        private const int DaysInWeek = 7;

        public static DateTimeOffset AddWeeks(this DateTimeOffset dateTimeOffset, int weeks)
        {
            return dateTimeOffset.AddDays(weeks * DaysInWeek);
        }
    }
}
