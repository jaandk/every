using System;
using System.Collections.Generic;
using System.Threading;

namespace Every
{
    public class Job
    {
        internal Action<Job> JobAction { get; set; }
        protected internal List<Timer> Timers { get; private set; }

        internal Job(Action<Job> job)
        {
            JobAction = job;
            Timers = new List<Timer>();
        }


        public void Cancel()
        {
            var timersCopy = new List<Timer>(Timers);

            foreach (var timer in timersCopy)
            {
                timer.Dispose();
                Timers.Remove(timer);
            }
        }

        protected virtual void AddTimer(Action<Job> job, JobConfiguration configuration)
        {
            throw new NotImplementedException("Developer is an idiot");
        }
    }
}
