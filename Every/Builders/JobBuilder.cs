using System;

namespace Every
{
    public class JobBuilder
    {
        protected internal Job Job { get; set; }

        internal JobBuilder(Job job)
        {
            Job = job;
        }


        public Job Do(Action<Job> job)
        {
            Job.Action = job;

            JobManager.Instance.Jobs.Add(Job);
            return Job;
        }

        public Job Do(Action job)
        {
            return Do(_ => job());
        }
    }
}
