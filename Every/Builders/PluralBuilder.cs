namespace Every
{
    public class PluralBuilder
    {
        private long _n;

        protected internal Job Job { get; set; }

        internal PluralBuilder(Job job, long n)
        {
            Job = job;

            _n = n;
        }


        public JobBuilder Seconds
        {
            get
            {
                Job.CalculateNext = (now) => now.AddSeconds(_n);

                return new JobBuilder(Job);
            }
        }

        public JobBuilder Minutes
        {
            get
            {
                Job.CalculateNext = (now) => now.AddMinutes(_n);

                return new JobBuilder(Job);
            }
        }

        public JobBuilder Hours
        {
            get
            {
                Job.CalculateNext = (now) => now.AddHours(_n);

                return new JobBuilder(Job);
            }
        }

        public DaysBuilder Days
        {
            get
            {
                Job.CalculateNext = (now) => now.AddDays(_n);

                return new DaysBuilder(Job);
            }
        }
    }
}
