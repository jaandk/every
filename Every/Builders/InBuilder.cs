using System;

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

        public JobBuilder In(int hours, int minutes) => In(new TimeSpan(hours, minutes, 0));
    }
}
