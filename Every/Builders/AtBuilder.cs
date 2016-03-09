using System;

namespace Every.Builders
{
    public class AtBuilder : JobBuilder
    {
        internal AtBuilder(JobParameters jobParams)
            : base(jobParams)
        {
        }

        public JobBuilder At(TimeSpan at)
        {
            var next = Parameters.Next;
            Parameters.Next = new DateTime(next.Year, next.Month, next.Day, at.Hours, at.Minutes, at.Seconds, at.Milliseconds);

            return new JobBuilder(Parameters);
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0, int milliseconds = 0)
        {
            return At(new TimeSpan(0, hours, minutes, seconds, milliseconds));
        }
    }
}
