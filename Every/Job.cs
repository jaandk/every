using System;
using System.Collections.Generic;
using System.Threading;

namespace Every
{
    public class Job
    {
        internal Action<Job> JobAction { get; set; }
        internal List<Timer> Timers { get; private set; }

        public Job(Action<Job> job)
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


        internal void AddTimer(long intervalInSeconds, long delay = 0)
        {
            Timers.Add(new Timer((e) => JobAction(this), null, delay, intervalInSeconds * 1000));
        }
    }
}
