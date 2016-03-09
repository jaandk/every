using System;

namespace Every
{
    public class JobParameters
    {
        public long N { get; set; }
        public int Nth { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek[] DaysOfWeek { get; set; }

        public Func<Job, DateTime> CalculateNext { get; set; }
        public DateTime Next { get; set; }

        internal JobParameters(long n = 1)
        {
            N = n;

            Next = DateTime.Now;
        }

        internal JobParameters(DayOfWeek[] daysOfWeek)
            : this()
        {
            DaysOfWeek = daysOfWeek;
        }

        internal JobParameters(int nth, DayOfWeek dayOfWeek)
            : this()
        {
            Nth = nth;
            DayOfWeek = dayOfWeek;
        }
    }
}
