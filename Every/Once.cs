using Every.Builders;
using System;

namespace Every
{
    /// <summary>
    /// Starting point for creating one-off jobs.
    /// </summary>
    public static class Once
    {
        /// <summary>
        /// Creates a singular job (after one second, after one minute, ...).
        /// </summary>
        public static AfterSingularBuilder AfterOne
        {
            get
            {
                var jobConfig = new JobConfiguration();
                jobConfig.CalculateNext = (next) => DateTimeOffset.MaxValue;

                return new AfterSingularBuilder(jobConfig);
            }
        }

        /// <summary>
        /// Creates a plural job (after n seconds, after n minutes, ...).
        /// </summary>
        /// <param name="n">The amount of units (seconds, minutes, ...).</param>
        public static AfterPluralBuilder After(int n)
        {
            var jobConfig = new JobConfiguration(n);
            jobConfig.CalculateNext = (next) => DateTimeOffset.MaxValue;

            return new AfterPluralBuilder(jobConfig);
        }
    }
}
