namespace Every
{
    public class SingularBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal SingularBuilder(JobConfiguration jobConfiguration)
        {
            Configuration = jobConfiguration;
        }


        public JobBuilder Second()
        {
            Configuration.IntervalInSeconds = 1;

            return new JobBuilder(Configuration);
        }

        public JobBuilder Minute()
        {
            Configuration.IntervalInSeconds = 60;

            return new JobBuilder(Configuration);
        }

        public JobBuilder Hour()
        {
            Configuration.IntervalInSeconds = 60 * 60;

            return new JobBuilder(Configuration);
        }

        public DaysBuilder Day()
        {
            Configuration.IntervalInSeconds = 60 * 60 * 24;

            return new DaysBuilder(Configuration);
        }
    }
}
