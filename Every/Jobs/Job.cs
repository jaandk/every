using System;

namespace Every
{
    public abstract class Job
    {
        protected internal Action<Job> JobAction { get; set; }
        protected internal JobConfiguration Configuration { get; set; }

        protected internal DateTime Next { get; set; }

        internal Job(Action<Job> job, JobConfiguration configuration)
        {
            JobAction = job;
            Configuration = configuration;
        }


        protected internal abstract void CalculateNextRun(DateTime now);
    }
}
