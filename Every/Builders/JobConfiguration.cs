using System;

namespace Every.Builders
{
    public class JobConfiguration
    {
        public long N { get; set; }
        public int Nth { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek[] DaysOfWeek { get; set; }

        public Func<Job, DateTime> CalculateNext { get; set; }
        public DateTime Next { get; set; }

        internal JobConfiguration(long n = 1)
        {
            N = n;

            Next = DateTime.Now;
        }

        internal JobConfiguration(DayOfWeek[] daysOfWeek)
            : this()
        {
            DaysOfWeek = daysOfWeek;
        }

        internal JobConfiguration(int nth, DayOfWeek dayOfWeek)
            : this()
        {
            Nth = nth;
            DayOfWeek = dayOfWeek;
        }
    }
}
