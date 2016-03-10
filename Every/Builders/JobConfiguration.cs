using System;

namespace Every.Builders
{
    public class JobConfiguration
    {
        public int N { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek[] DaysOfWeek { get; set; }

        public DateTimeOffset First { get; set; }
        public Func<Job, DateTimeOffset> CalculateNext { get; set; }

        internal JobConfiguration(int n = 1)
        {
            N = n;

            First = DateTimeOffset.Now;
        }

        internal JobConfiguration(DayOfWeek[] daysOfWeek)
            : this()
        {
            DaysOfWeek = daysOfWeek;
        }
    }
}
