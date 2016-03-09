namespace Every
{
    public class PluralBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal PluralBuilder(JobConfiguration configuration)
        {
            Configuration = configuration;
        }


        public JobBuilder Seconds
        {
            get
            {
                Configuration.IntervalInSeconds = Configuration.N;

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Configuration.IntervalInSeconds = Configuration.N * 60;

                return new JobBuilder(Configuration);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Configuration.IntervalInSeconds = Configuration.N * 60 * 60;

                return new JobBuilder(Configuration);
            }
        }

        public DaysBuilder Days
        {
            get
            {
                Configuration.IntervalInSeconds = Configuration.N * 60 * 60 * 24;

                return new DaysBuilder(Configuration);
            }
        }
    }
}
