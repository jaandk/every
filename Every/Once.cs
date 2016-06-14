using Every.Builders;
using System;

namespace Every
{
    /// <summary>
    /// Base class for creating one-off jobs.
    /// </summary>
    public static class Once
    {
        public static AfterSingularBuilder AfterOne
        {
            get
            {
                var jobConfig = new JobConfiguration();
                jobConfig.CalculateNext = (next) => DateTimeOffset.MaxValue;

                return new AfterSingularBuilder(jobConfig);
            }
        }

        public static AfterPluralBuilder After(int n)
        {
            var jobConfig = new JobConfiguration(n);
            jobConfig.CalculateNext = (next) => DateTimeOffset.MaxValue;

            return new AfterPluralBuilder(jobConfig);
        }
    }
}
