using System;

namespace Every.Builders
{
    public class AfterSingularBuilder : BuilderBase
    {
        internal AfterSingularBuilder(JobConfiguration config)
            : base(config)
        {
        }

        public JobBuilder Second()
        {
            Configuration.First = DateTimeOffset.Now.AddSeconds(1);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Minute()
        {
            Configuration.First = DateTimeOffset.Now.AddMinutes(1);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Hour()
        {
            Configuration.First = DateTimeOffset.Now.AddHours(1);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Day()
        {
            Configuration.First = DateTimeOffset.Now.AddDays(1);

            return new JobBuilder(Configuration);
        }
    }
}
