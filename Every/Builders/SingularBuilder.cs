namespace Every.Builders
{
    public class SingularBuilder : BuilderBase
    {
        internal SingularBuilder(JobConfiguration config)
            : base(config)
        {
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

        public HoursBuilder Hour
        {
            get
            {
                Configuration.CalculateNext = job => job.Next.AddHours(1);

                return new HoursBuilder(Configuration);
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
