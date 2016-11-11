using System;

namespace Every.Builders
{
    public class AtBuilder : JobBuilder
    {
        internal AtBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public UtcBuilder At(int hours, int minutes = 0, int seconds = 0)
        {
            var first = Configuration.First;
            Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, hours, minutes, seconds, first.Offset);

            return new UtcBuilder(Configuration);
        }

        public UtcBuilder At(TimeSpan at) => At(at.Hours, at.Minutes, at.Seconds);
    }
}
