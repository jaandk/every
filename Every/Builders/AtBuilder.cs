using System;

namespace Every.Builders
{
    public class AtBuilder : JobBuilder
    {
        internal AtBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder At(TimeSpan at)
        {
            var first = Configuration.First;
            Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, at.Hours, at.Minutes, at.Seconds, first.Offset);

            return new JobBuilder(Configuration);
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0)
        {
            return At(new TimeSpan(hours, minutes, seconds));
        }
    }
}
