using System;
using System.Threading;

namespace Every.Jobs
{
    public class FixedIntervalJob : Job
    {
        internal FixedIntervalJob(Action<Job> job, JobConfiguration configuration)
            : base(job, configuration)
        {
            Timer = new Timer((e) => job(this), null, configuration.Delay, configuration.IntervalInSeconds * 1000);
        }
    }
}
