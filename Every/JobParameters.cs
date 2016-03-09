using System;

namespace Every
{
    public class JobParameters
    {
        public long N { get; set; }
        public DayOfWeek[] DaysOfWeek { get; set; }

        public Func<Job, DateTime> CalculateNext { get; set; }
        public DateTime Next { get; set; }

        internal JobParameters(int n = 1)
        {
            N = n;

            Next = DateTime.Now;
        }

        internal JobParameters(DayOfWeek[] daysOfWeek)
            : this()
        {
            DaysOfWeek = daysOfWeek;
        }
    }
}
