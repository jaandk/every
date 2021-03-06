﻿namespace Every.Builders
{
    public class SingularBuilder : BuilderBase
    {
        internal SingularBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public FromBuilder Second
        {
            get
            {
                Configuration.CalculateNext = next => next.AddSeconds(1);

                return new FromBuilder(Configuration);
            }
        }

        public FromBuilder Minute
        {
            get
            {
                Configuration.CalculateNext = next => next.AddMinutes(1);

                return new FromBuilder(Configuration);
            }
        }

        public HoursBuilder Hour
        {
            get
            {
                Configuration.CalculateNext = next => next.AddHours(1);

                return new HoursBuilder(Configuration);
            }
        }

        public AtBuilder Day
        {
            get
            {
                Configuration.CalculateNext = next => next.AddDays(1);

                return new AtBuilder(Configuration);
            }
        }

        public DayOfWeekBuilder Weekday
        {
            get
            {
                return new DayOfWeekBuilder(new JobConfiguration(new[] { Mon.day, Tues.day, Wednes.day, Thurs.day, Fri.day }));
            }
        }
    }
}
