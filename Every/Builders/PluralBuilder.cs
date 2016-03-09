namespace Every.Builders
{
    public class PluralBuilder
    {
        internal JobParameters Parameters { get; set; }

        internal PluralBuilder(JobParameters jobParams)
        {
            Parameters = jobParams;
        }


        public JobBuilder Seconds
        {
            get
            {
                Parameters.CalculateNext = (job) => job.Next.AddSeconds(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Parameters.CalculateNext = (job) => job.Next.AddMinutes(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Parameters.CalculateNext = (job) => job.Next.AddHours(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public AtBuilder Days
        {
            get
            {
                Parameters.CalculateNext = (job) => job.Next.AddDays(Parameters.N);

                return new AtBuilder(Parameters);
            }
        }
    }
}
