using Every.Exceptions;
using Every.Utilities;
using System;

namespace Every.Builders
{
    public class PluralBuilder : BuilderBase
    {
        internal PluralBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public FromBuilder Seconds
        {
            get
            {
                Configuration.CalculateNext = next => next.AddSeconds(Configuration.N);

                return new FromBuilder(Configuration);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Configuration.CalculateNext = next => next.AddMinutes(Configuration.N);

                return new FromBuilder(Configuration);
            }
        }

        public HoursBuilder Hours
        {
            get
            {
                Configuration.CalculateNext = next => next.AddHours(Configuration.N);

                return new HoursBuilder(Configuration);
            }
        }

        public AtBuilder Days
        {
            get
            {
                Configuration.CalculateNext = next => next.AddDays(Configuration.N);

                return new AtBuilder(Configuration);
            }
        }


        public AtBuilder stOfTheMonth
        {
            get
            {
                return OrdinalOfTheMonth(GrammarChecker.St);
            }
        }

        public AtBuilder ndOfTheMonth
        {
            get
            {
                return OrdinalOfTheMonth(GrammarChecker.Nd);
            }
        }

        public AtBuilder rdOfTheMonth
        {
            get
            {
                return OrdinalOfTheMonth(GrammarChecker.Rd);
            }
        }

        public AtBuilder thOfTheMonth
        {
            get
            {
                return OrdinalOfTheMonth(GrammarChecker.Th);
            }
        }

        private AtBuilder OrdinalOfTheMonth(string ordinal)
        {
            GrammarChecker.CheckGrammar(Configuration.N, ordinal);

            var first = Configuration.First;
            first = new DateTimeOffset(first.Year, first.Month, Configuration.N, first.Hour, first.Minute, first.Second, first.Offset);

            if (first < DateTimeOffset.Now)
                first = first.AddMonths(1);

            Configuration.First = first;

            Configuration.CalculateNext = next =>
            {
                next = next.AddMonths(1);

                return next;
            };

            return new AtBuilder(Configuration);
        }


        public NthDayOfWeekBuilder st(DayOfWeek day) => Ordinal(day, GrammarChecker.St);

        public NthDayOfWeekBuilder nd(DayOfWeek day) => Ordinal(day, GrammarChecker.Nd);

        public NthDayOfWeekBuilder rd(DayOfWeek day) => Ordinal(day, GrammarChecker.Rd);

        public NthDayOfWeekBuilder th(DayOfWeek day) => Ordinal(day, GrammarChecker.Th);

        private NthDayOfWeekBuilder Ordinal(DayOfWeek day, string ordinal)
        {
            GrammarChecker.CheckGrammar(Configuration.N, ordinal);

            Configuration.DayOfWeek = day;
            return new NthDayOfWeekBuilder(Configuration);
        }
    }
}
