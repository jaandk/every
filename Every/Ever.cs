using Every.Builders;
using System;

namespace Every
{
    /// <summary>
    /// Starting point for creating recurring jobs.
    /// </summary>
    public static class Ever
    {
        /// <summary>
        /// Creates a singular job (every second, every minute, ...).
        /// </summary>
        public static SingularBuilder y()
        {
            return new SingularBuilder(new JobConfiguration());
        }

        /// <summary>
        /// Creates a plural job (every n seconds, every n minutes, ...) or an ordinal job (every nth Friday, ...).
        /// </summary>
        /// <param name="n">The amount of units (seconds, minutes, ...) or the ordinal number.</param>
        public static PluralBuilder y(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException(nameof(n), "Cannot be less than 1.");

            return new PluralBuilder(new JobConfiguration(n));
        }

        /// <summary>
        /// Creates a day-of-week job (every Monday, every Friday and Saturday, ...).
        /// </summary>
        /// <param name="daysOfWeek">The day(s) of the week.</param>
        /// <returns></returns>
        public static DayOfWeekBuilder y(params DayOfWeek[] daysOfWeek)
        {
            return new DayOfWeekBuilder(new JobConfiguration(daysOfWeek));
        }
    }
}
