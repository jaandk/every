using Every.Jobs;
using System;

namespace Every
{
    public class JobBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal JobBuilder(JobConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Job Do(Action<Job> job)
        {
            switch (Configuration.JobType)
            {
                case JobType.FixedInterval:
                    return CreateFixedIntervalJob(job);

                case JobType.DayOfWeek:
                    return CreateDayOfWeekJob(job);
            }

            return null;
        }

        public Job Do(Action job)
        {
            return Do((j) => job());
        }


        private FixedIntervalJob CreateFixedIntervalJob(Action<Job> job)
        {
            return new FixedIntervalJob(job, Configuration);
        }

        private DayOfWeekJob CreateDayOfWeekJob(Action<Job> jobAction)
        {
            return new DayOfWeekJob(jobAction, Configuration);
        }
    }
}
