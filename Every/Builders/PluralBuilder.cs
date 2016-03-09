namespace Every
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
                Parameters.CalculateNext = (now) => now.AddSeconds(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddMinutes(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddHours(Parameters.N);

                return new JobBuilder(Parameters);
            }
        }

        public DaysBuilder Days
        {
            get
            {
                Parameters.CalculateNext = (now) => now.AddDays(Parameters.N);

                return new DaysBuilder(Parameters);
            }
        }
    }
}
