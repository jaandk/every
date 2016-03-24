using System;

namespace Every.Builders
{
    public class SingularBuilder
    {
        internal JobConfiguration Configuration { get; set; }

        internal SingularBuilder(JobConfiguration config)
        {
            Configuration = config;
        }


        public JobBuilder Second
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddSeconds(1);

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Minute
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddMinutes(1);

                return new JobBuilder(Configuration);
            }
        }

        public HourBuilder Hour
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddHours(1);

                return new HourBuilder(Configuration);
            }
        }

        public AtBuilder Day
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddDays(1);

                return new AtBuilder(Configuration);
            }
        }
    }
}
