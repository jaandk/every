using Every.Extensions;
using System;

namespace Every.Builders
{
    public class NthDayOfWeekBuilder : JobBuilder
    {
        public AtBuilder OfTheMonth
        {
            get
            {
                Parameters.CalculateNext = job => GetNthDayOfMonthForDate(job.Next.AddMonths(1), Parameters.Nth);

                return new AtBuilder(Parameters);
            }
        }

        internal NthDayOfWeekBuilder(JobConfiguration jobParams)
            : base(jobParams)
        {
            Parameters.Next = GetNthDayOfMonthForDate(Parameters.Next, Parameters.Nth);

            Parameters.CalculateNext = job => job.Next.AddWeeks(Parameters.Nth);
        }


        private DateTime GetNthDayOfMonthForDate(DateTime now, int nth)
        {
            now = new DateTime(now.Year, now.Month, 1, now.Hour, now.Minute, now.Second).AddDays(-1);

            while (now.DayOfWeek != Parameters.DayOfWeek)
                now = now.AddDays(1);

            return now.AddWeeks(Parameters.Nth - 1);
        }
    }
}
