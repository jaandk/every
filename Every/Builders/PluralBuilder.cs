using System;

namespace Every.Builders
{
    public class PluralBuilder : BuilderBase
    {
        internal PluralBuilder(JobConfiguration config)
            : base(config)
        {
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

        public HoursBuilder Hours
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddHours(Configuration.N);

                return new HoursBuilder(Configuration);
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
                throw new ArgumentOutOfRangeException("n", $"One does not write '{Configuration.N}st'.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder nd(DayOfWeek day)
        {
            if (Configuration.N % 10 != 2)
                throw new ArgumentOutOfRangeException("n", $"One does not write '{Configuration.N}nd'.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder rd(DayOfWeek day)
        {
            if (Configuration.N % 10 != 3)
                throw new ArgumentOutOfRangeException("n", $"One does not write '{Configuration.N}rd'.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }

        public NthDayOfWeekBuilder th(DayOfWeek day)
        {
            if (Configuration.N % 10 < 4)
                throw new ArgumentOutOfRangeException("n", $"One does not write '{Configuration.N}th'.");

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }
    }
}
