using System;
using System.Threading;

namespace Every
{
    public class Job
    {
        internal Action<Job> JobAction { get; set; }
        internal JobConfiguration Configuration { get; set; }

        internal Timer Timer { get; set; }

        internal Job(Action<Job> job, JobConfiguration configuration)
        {
            JobAction = job;
            Configuration = configuration;
        }


        public virtual void Cancel()
        {
            Timer?.Dispose();
            Timer = null;
        }
    }
}
