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
                Configuration.CalculateNext = job => GetNthDayOfMonthForDate(job.Next.AddMonths(1));

                return new AtBuilder(Configuration);
            }
        }

        internal NthDayOfWeekBuilder(JobConfiguration config)
            : base(config)
        {
            Configuration.First = GetNthDayOfMonthForDate(Configuration.First);

            Configuration.CalculateNext = job => job.Next.AddWeeks(Configuration.N);
        }


        private DateTime GetNthDayOfMonthForDate(DateTime now)
        {
            now = new DateTime(now.Year, now.Month, 1, now.Hour, now.Minute, now.Second).AddDays(-1);

            while (now.DayOfWeek != Configuration.DayOfWeek)
                now = now.AddDays(1);

            return now.AddWeeks(Configuration.N - 1);
        }
    }
}
