namespace Every
{
    public class PluralBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal PluralBuilder(JobConfiguration configuration)
        {
            Configuration = configuration;
        }


        public JobBuilder Seconds()
        {
            Configuration.IntervalInSeconds = Configuration.N;

            return new JobBuilder(Configuration);
        }

        public JobBuilder Minutes()
        {
            Configuration.IntervalInSeconds = Configuration.N * 60;

            return new JobBuilder(Configuration);
        }

        public JobBuilder Hours()
        {
            Configuration.IntervalInSeconds = Configuration.N * 60 * 60;

            return new JobBuilder(Configuration);
        }

        public DaysBuilder Days()
        {
            Configuration.IntervalInSeconds = Configuration.N * 60 * 60 * 24;

            return new DaysBuilder(Configuration);
        }
    }
}
