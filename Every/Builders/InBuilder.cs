using System;
using System.Linq;

namespace Every.Builders
{
    public class InBuilder : JobBuilder
    {
        internal InBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder In(TimeSpan utcOffset)
        {
            Configuration.First = new DateTimeOffset(Configuration.First.DateTime, utcOffset);

            return new JobBuilder(Configuration);
        }

        public JobBuilder In(string cityName)
        {
            var timeZone = TimeZoneInfo.GetSystemTimeZones().Where(tz => tz.DisplayName.ToLower().Contains(cityName.ToLower())).FirstOrDefault();

            if (timeZone == null)
                throw new TimeZoneNotFoundException($"No time zone found for '{cityName}'.");

            return In(timeZone.BaseUtcOffset);
        }
    }
}
