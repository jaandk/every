using System;

namespace Every
{
    public class DaysBuilder : JobBuilder
    {
        internal DaysBuilder(JobConfiguration configuration)
            : base(configuration)
        {
        }


        public JobBuilder At(TimeSpan at)
        {
            var now = DateTime.Now.TimeOfDay;

            if (now > at)
                Configuration.Delay = (long)(new TimeSpan(24, 0, 0).TotalMilliseconds - (now - at).TotalMilliseconds);
            else
                Configuration.Delay = (long)((at - now).TotalMilliseconds);

            return new JobBuilder(Configuration);
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0)
        {
            return At(new TimeSpan(hours, minutes, seconds));
        }
    }
}
