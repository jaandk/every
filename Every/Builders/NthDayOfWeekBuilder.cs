using Every.Extensions;
using System;

namespace Every.Builders
{
    public class NthDayOfWeekBuilder : JobBuilder
    {
        internal NthDayOfWeekBuilder(JobConfiguration config)
            : base(config)
        {
            Configuration.CalculateNext = next => next.AddWeeks(Configuration.N);
        }


        public AtBuilder OfTheMonth
        {
            get
            {
                Configuration.CalculateNext = next =>
                {
                    next = next.AddMonths(1);
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
