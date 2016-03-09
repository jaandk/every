using System;

namespace Every
{
    public class DaysBuilder : JobBuilder
    {
        internal DaysBuilder(long intervalInSeconds, long delay = 0)
            : base(intervalInSeconds, delay)
        {
        }


        public JobBuilder At(TimeSpan at)
        {
            var now = DateTime.Now.TimeOfDay;

            if (now > at)
                Delay = (long)(new TimeSpan(24, 0, 0).TotalMilliseconds - (now - at).TotalMilliseconds);
            else
                Delay = (long)((at - now).TotalMilliseconds);

            return new JobBuilder(IntervalInSeconds, Delay);
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0)
        {
            return At(new TimeSpan(hours, minutes, seconds));
        }
    }
}
