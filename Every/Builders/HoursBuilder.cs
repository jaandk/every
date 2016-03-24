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
                AtInternal(0);

                return new JobBuilder(Configuration);
            }
        }


        public MinutesPastBuilder At(int minutesPast)
        {
            AtInternal(minutesPast);

            return new MinutesPastBuilder(Configuration);
        }


        private void AtInternal(int minutesPast)
        {
            var first = Configuration.First;
            Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, first.Hour, minutesPast, 0, first.Offset);
        }
    }
}
