namespace Every.Builders
{
    public class SingularBuilder
    {
        internal JobConfiguration Parameters { get; set; }

        internal SingularBuilder(JobConfiguration jobParams)
        {
            Parameters = jobParams;
        }


        public JobBuilder Second
        {
            get
            {
                Parameters.CalculateNext = job => job.Next.AddSeconds(1);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Minute
        {
            get
            {
                Parameters.CalculateNext = job => job.Next.AddMinutes(1);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Hour
        {
            get
            {
                Parameters.CalculateNext = job => job.Next.AddHours(1);

                return new JobBuilder(Parameters);
            }
        }

        public AtBuilder Day
        {
            get
            {
                Parameters.CalculateNext = job => job.Next.AddDays(1);

                return new AtBuilder(Parameters);
            }
        }
    }
}
