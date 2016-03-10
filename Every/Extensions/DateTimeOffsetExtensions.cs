using System;

namespace Every.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset AddWeeks(this DateTimeOffset dateTimeOffset, int weeks)
        {
            return dateTimeOffset.AddDays(weeks * 7);
        }
    }
}
