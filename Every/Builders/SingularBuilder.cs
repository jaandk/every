namespace Every
{
    public class SingularBuilder
    {
        protected internal Job Job { get; set; }

        internal SingularBuilder(Job job)
        {
            Job = job;
        }


        public JobBuilder Second
        {
            get
            {
                Job.CalculateNext = (now) => now.AddSeconds(1);

                return new JobBuilder(Job);
            }
        }

        public JobBuilder Minute
        {
            get
            {
                Job.CalculateNext = (now) => now.AddMinutes(1);

                return new JobBuilder(Job);
            }
        }

        public JobBuilder Hour
        {
            get
            {
                Job.CalculateNext = (now) => now.AddHours(1);

                return new JobBuilder(Job);
            }
        }

        public DaysBuilder Day
        {
            get
            {
                Job.CalculateNext = (now) => now.AddDays(1);

                return new DaysBuilder(Job);
            }
        }
    }
}
