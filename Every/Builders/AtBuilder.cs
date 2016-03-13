using System;

namespace Every.Builders
{
    public class AtBuilder : JobBuilder
    {
        internal AtBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public InBuilder At(int hours, int minutes, int seconds = 0)
        {
            var first = Configuration.First;
            Configuration.First = new DateTimeOffset(first.Year, first.Month, first.Day, hours, minutes, seconds, first.Offset);

            return new InBuilder(Configuration);
        }

        public InBuilder At(TimeSpan at)
        {
            return At(new TimeSpan(at.Hours, at.Minutes, at.Seconds));
        }
    }
}
