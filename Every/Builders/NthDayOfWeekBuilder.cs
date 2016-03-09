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
                Parameters.CalculateNext = (job) =>
                {
                    //var now = Parameters.Next.AddMonths(1);
                    //Parameters.Next = new DateTime(now.Year, now.Month, 1, now.Hour, now.Minute, now.Second).AddDays(-1);

                    //while (Parameters.Next.DayOfWeek != Parameters.DayOfWeek)
                    //    Parameters.Next = Parameters.Next.AddDays(1);

                    return GetNthDayOfMonth(Parameters.Next.AddMonths(1), Parameters.Nth); //Parameters.Next.AddWeeks(Parameters.Nth - 1);
                };

                return new AtBuilder(Parameters);
            }
        }

        internal NthDayOfWeekBuilder(JobParameters jobParams)
            : base(jobParams)
        {
            //var now = Parameters.Next;
            //Parameters.Next = new DateTime(now.Year, now.Month, 1, now.Hour, now.Minute, now.Second).AddDays(-1);

            //while (Parameters.Next.DayOfWeek != Parameters.DayOfWeek)
            //    Parameters.Next = Parameters.Next.AddDays(1);

            Parameters.Next = GetNthDayOfMonth(Parameters.Next, Parameters.Nth);//Parameters.Next.AddWeeks(Parameters.Nth - 1);

            Parameters.CalculateNext = (job) => job.Next.AddWeeks(Parameters.Nth);
        }

        private DateTime GetNthDayOfMonth(DateTime now, int nth)
        {
            now = new DateTime(now.Year, now.Month, 1, now.Hour, now.Minute, now.Second).AddDays(-1);

            while (now.DayOfWeek != Parameters.DayOfWeek)
                now = now.AddDays(1);

            return now.AddWeeks(Parameters.Nth - 1);
        }
    }
}
