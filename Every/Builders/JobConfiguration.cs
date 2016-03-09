using System;

namespace Every
{
    public class JobConfiguration
    {
        internal JobType JobType { get; set; }

        public long N { get; set; }

        public long IntervalInSeconds { get; set; }
        public long Delay { get; set; }

        public DayOfWeek[] DaysOfWeek { get; set; }

        internal JobConfiguration(JobType jobType)
        {
            JobType = jobType;
        }
    }
}
