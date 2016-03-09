using System;

namespace Every.Jobs
{
    public class FixedIntervalJob : Job
    {
        internal FixedIntervalJob(Action<Job> job, JobConfiguration configuration)
            : base(job, configuration)
        {
            Next = DateTime.Now.AddMilliseconds(configuration.Delay);
        }


        protected internal override void CalculateNextRun(DateTime now)
        {
            Next = now.AddSeconds(Configuration.IntervalInSeconds);
        }
    }
}
