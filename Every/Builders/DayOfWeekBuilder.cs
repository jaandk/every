using System;
using System.Linq;

namespace Every
{
    public class DayOfWeekBuilder : JobBuilder
    {
        internal DayOfWeekBuilder(JobParameters jobParams)
            : base(jobParams)
        {
            while (!Parameters.DaysOfWeek.Contains(Parameters.Next.DayOfWeek))
                Parameters.Next = Parameters.Next.AddDays(1);

            Parameters.CalculateNext = (job) =>
            {
                var next = Parameters.Next;

                do
                    next = next.AddDays(1);
                while (!job.Parameters.DaysOfWeek.Contains(next.DayOfWeek));

                return next;
            };
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
