using System;

namespace Every
{
    public static class Eve
    {
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
            var configuration = new JobConfiguration(JobType.DayOfWeek)
            {
                DaysOfWeek = daysOfWeek
            };

            return new DayOfWeekBuilder(configuration);
        }
    }
}
