using System;

namespace Every.Builders
{
    public class AfterPluralBuilder : BuilderBase
    {
        internal AfterPluralBuilder(JobConfiguration config)
            : base(config)
        {
        }

        public JobBuilder Seconds()
        {
            Configuration.First = DateTimeOffset.Now.AddSeconds(Configuration.N);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Minutes()
        {
            Configuration.First = DateTimeOffset.Now.AddMinutes(Configuration.N);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Hours()
        {
            Configuration.First = DateTimeOffset.Now.AddHours(Configuration.N);

            return new JobBuilder(Configuration);
        }

        public JobBuilder Days()
        {
            Configuration.First = DateTimeOffset.Now.AddDays(Configuration.N);

            return new JobBuilder(Configuration);
        }
    }
}
