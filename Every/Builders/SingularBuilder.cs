namespace Every
{
    public class SingularBuilder
    {
        internal JobParameters Parameters { get; set; }

        internal SingularBuilder(JobParameters jobParams)
        {
            Parameters = jobParams;
        }


        public JobBuilder Second
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddSeconds(1);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Minute
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddMinutes(1);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Hour
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddHours(1);

                return new JobBuilder(Parameters);
            }
        }

        public DaysBuilder Day
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddDays(1);

                return new DaysBuilder(Parameters);
            }
        }
    }
}
