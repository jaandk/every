using Every.Builders;
using System;

namespace Every
{
    /// <summary>
    /// Base class for creating jobs.
    /// </summary>
    public static class Ever
    {
        /// <summary>
        /// Creates a singular job (every second, every minute, ...).
        /// </summary>
        /// <returns></returns>
        public static SingularBuilder y()
        {
            return new SingularBuilder(new JobConfiguration());
        }

        /// <summary>
        /// Creates a plural job (every n seconds, every n minutes, ...).
        /// </summary>
        /// <param name="n">The amount of units (seconds, minutes, ...).</param>
        /// <returns></returns>
        public static PluralBuilder y(long n)
        {
            if (n < 2)
                throw new ArgumentOutOfRangeException(nameof(n), "Cannot be less than 2.");

            return new PluralBuilder(new JobConfiguration(n));
        }

        /// <summary>
        /// Creates a day-of-week job (every monday, every friday and saturday, ...).
        /// </summary>
        /// <param name="daysOfWeek">The day(s) of the week.</param>
        /// <returns></returns>
        public static DayOfWeekBuilder y(params DayOfWeek[] daysOfWeek)
        {
            return new DayOfWeekBuilder(new JobConfiguration(daysOfWeek));
        }

        /// <summary>
        /// Creates a nth day-of-week job (every second monday, every first wednesday of the month, ...).
        /// </summary>
        /// <param name="nth">The interval between days.</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        public static NthDayOfWeekBuilder y(int nth, DayOfWeek dayOfWeek)
        {
            if (nth < 1)
                throw new ArgumentOutOfRangeException(nameof(nth), "Cannot be less than 2.");

            return new NthDayOfWeekBuilder(new JobConfiguration(nth, dayOfWeek));
        }
    }
}
