using System;

namespace Every
{
    public class DayOfWeekBuilder : JobBuilder
    {
        internal DayOfWeekBuilder(JobConfiguration configuration)
            : base(configuration)
        {
        }


        public JobBuilder At(TimeSpan at)
        {
            throw new NotImplementedException();
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0)
        {
            return At(new TimeSpan(hours, minutes, seconds));
        }
    }
}
