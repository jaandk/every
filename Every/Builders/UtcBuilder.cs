using System;

namespace Every.Builders
{
    public class UtcBuilder : JobBuilder
    {
        internal UtcBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder Utc(TimeSpan utcOffset)
        {
            Configuration.First = new DateTimeOffset(Configuration.First.DateTime, utcOffset);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Utc(int hours = 0, int minutes = 0) => Utc(new TimeSpan(hours, minutes, 0));
    }
}
