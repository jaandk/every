using System;
using System.Collections.Generic;

namespace Every
{
    public static class Eve
    {
        internal static Dictionary<Action<Job>, Job> Jobs { get; private set; }

        static Eve()
        {
            Jobs = new Dictionary<Action<Job>, Job>();
        }


        public static SingularBuilder ry()
        {
            var configuration = new JobConfiguration(JobType.FixedInterval)
            {
                N = 1
            };

            return new SingularBuilder(configuration);
        }

        public static PluralBuilder ry(int n)
        {
            var configuration = new JobConfiguration(JobType.FixedInterval)
            {
                N = n
            };

            return new PluralBuilder(configuration);
        }

        public static DayOfWeekBuilder ry(params DayOfWeek[] daysOfWeek)
        {
            var configuration = new JobConfiguration(JobType.Other)
            {
                DaysOfWeek = daysOfWeek
            };

            return new DayOfWeekBuilder(configuration);
        }
    }
}
