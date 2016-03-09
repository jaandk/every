namespace Every
{
    public class SingularBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal SingularBuilder(JobConfiguration jobConfiguration)
        {
            Configuration = jobConfiguration;
        }


        public JobBuilder Second
        {
            get
            {
                Configuration.IntervalInSeconds = 1;

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Minute
        {
            get
            {
                Configuration.IntervalInSeconds = 60;

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Hour
        {
            get
            {
                Configuration.IntervalInSeconds = 60 * 60;

                return new JobBuilder(Configuration);
            }
        }

        public DaysBuilder Day
        {
            get
            {
                Configuration.IntervalInSeconds = 60 * 60 * 24;

                return new DaysBuilder(Configuration);
            }
        }
    }
}
