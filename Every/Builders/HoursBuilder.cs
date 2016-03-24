using System;

namespace Every.Builders
{
    public class HoursBuilder : JobBuilder
    {
        internal HoursBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder OnTheHour
        {
            get
            {
                var first = Configuration.First;
                Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, first.Hour, 0, 0, first.Offset);

                return new JobBuilder(Configuration);
            }
        }
    }
}
