namespace Every.Builders
{
    public class MinutesPastBuilder : BuilderBase
    {
        internal MinutesPastBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public JobBuilder MinutesPastTheHour => new JobBuilder(Configuration);
    }
}
