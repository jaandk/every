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
            Job jobContainer = null;

            switch (Configuration.JobType)
            {
                case JobType.FixedInterval:
                    jobContainer = CreateFixedIntervalJob(job);
                    break;

                case JobType.DayOfWeek:
                    jobContainer = CreateDayOfWeekJob(job);
                    break;
            }

            if (jobContainer == null)
                throw new InvalidOperationException("Developer is an idiot");

            JobManager.Instance.Jobs.Add(jobContainer);
            return jobContainer;
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
