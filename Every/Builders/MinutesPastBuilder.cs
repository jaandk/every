namespace Every.Builders
{
    public class MinutesPastBuilder
    {
        internal JobConfiguration Configuration { get; set; }

        internal MinutesPastBuilder(JobConfiguration configuration)
        {
            Configuration = configuration;
        }


        public JobBuilder MinutesPastTheHour => new JobBuilder(Configuration);
    }
}
