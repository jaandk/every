using System;

namespace Every
{
    public class JobBuilder
    {
        protected long IntervalInSeconds { get; set; }
        protected long Delay { get; set; }


        internal JobBuilder(long intervalInSeconds, long delay = 0)
        {
            IntervalInSeconds = intervalInSeconds;
            Delay = delay;
        }

        public Job Do(Action<Job> job)
        {
            if (!Eve.Jobs.ContainsKey(job))
                Eve.Jobs[job] = new Job(job);

            var jobContainer = Eve.Jobs[job];
            jobContainer.AddTimer(IntervalInSeconds, Delay);

            return jobContainer;
        }
    }
}
