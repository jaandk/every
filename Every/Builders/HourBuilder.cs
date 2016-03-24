using System;

namespace Every.Builders
{
    public class HourBuilder : JobBuilder
    {
        internal HourBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder OnTheHour
        {
            get
            {
                var first = Configuration.First;
                Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, first.Hour, 0, 0, first.Offset);

                if (Configuration.First < DateTimeOffset.Now)
                    Configuration.First = Configuration.First.AddHours(1);

                return new JobBuilder(Configuration);
            }
        }
    }
}
