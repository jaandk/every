using Every.Extensions;
using System;

namespace Every.Builders
{
    public class NthDayOfWeekBuilder : JobBuilder
    {
        internal NthDayOfWeekBuilder(JobConfiguration config)
            : base(config)
        {
            Configuration.CalculateNext = job => job.Next.AddWeeks(Configuration.N);
        }


        public AtBuilder OfTheMonth
        {
            get
            {
                Configuration.CalculateNext = job =>
                {
                    var next = job.Next.AddMonths(1);
                    next = new DateTimeOffset(next.Year, next.Month, 1, next.Hour, next.Minute, next.Second, next.Offset);

                    while (next.DayOfWeek != Configuration.DayOfWeek)
                        next = next.AddDays(1);

                    return next.AddWeeks(Configuration.N - 1);
                };

                return new AtBuilder(Configuration);
            }
        }
    }
}
