using System;
using System.Linq;

namespace Every.Builders
{
    public class PluralBuilder
    {
        internal JobConfiguration Configuration { get; set; }

        internal PluralBuilder(JobConfiguration config)
        {
            Configuration = config;
        }


        public JobBuilder Seconds
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddSeconds(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddMinutes(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddHours(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public AtBuilder Days
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddDays(Configuration.N);

                return new AtBuilder(Configuration);
            }
        }


        public NthDayOfWeekBuilder st(DayOfWeek day)
        {
            if (Configuration.N % 10 != 1)
                throw new ArgumentOutOfRangeException("n", "N should end in 1.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder nd(DayOfWeek day)
        {
            if (Configuration.N % 10 != 2)
                throw new ArgumentOutOfRangeException("n", "N should end in 2.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder rd(DayOfWeek day)
        {
            if (Configuration.N % 10 != 3)
                throw new ArgumentOutOfRangeException("n", "N should end in 3.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder th(DayOfWeek day)
        {
            if (Configuration.N % 10 < 4)
                throw new ArgumentOutOfRangeException("n", "N should end in a number greater than or equal to 4.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }
    }
}
