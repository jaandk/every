using System;

namespace Every.Builders
{
    public class AfterPluralBuilder : BuilderBase
    {
        internal AfterPluralBuilder(JobConfiguration config)
            : base(config)
        {
        }

        public JobBuilder Seconds
        {
            get
            {
                Configuration.First = DateTimeOffset.Now.AddSeconds(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Configuration.First = DateTimeOffset.Now.AddMinutes(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Configuration.First = DateTimeOffset.Now.AddHours(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Days
        {
            get
            {
                Configuration.First = DateTimeOffset.Now.AddDays(Configuration.N);

                return new JobBuilder(Configuration);
            }
        }
    }
}
