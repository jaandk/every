using System;
using System.Threading;

namespace Every
{
    public class FixedIntervalJob : Job
    {
        internal FixedIntervalJob(Action<Job> job)
            : base(job)
        {
        }


        protected override void AddTimer(Action<Job> job, JobConfiguration configuration)
        {
            Timers.Add(new Timer((e) => JobAction(this), null, configuration.Delay, configuration.IntervalInSeconds * 1000));
        }
    }
}
