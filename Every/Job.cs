using System;

namespace Every
{
    public class Job
    {
        protected internal Action<Job> Action { get; set; }
        protected internal Func<DateTime, DateTime> CalculateNext { get; set; }
        protected internal JobParameters Parameters { get; set; }

        /// <summary>
        /// Gets next time that this job will be executed at.
        /// </summary>
        public DateTime Next { get; protected internal set; }

        internal Job(JobParameters jobParams)
        {
            Parameters = jobParams;

            CalculateNext = jobParams.CalculateNext;
            Next = jobParams.Next;
        }

        internal Job(Action<Job> action, JobParameters jobParams)
            : this(jobParams)
        {
            Action = action;
        }


        /// <summary>
        /// Removes this job from the scheduler.
        /// </summary>
        public void Cancel()
        {
            JobManager.Instance.Jobs.Remove(this);
        }
    }

    public class Job<TMetadata> : Job
    {
        /// <summary>
        /// Gets or sets the metadata for this job.
        /// </summary>
        public TMetadata Metadata { get; set; }

        internal Job(Action<Job<TMetadata>> action, JobParameters jobParams, TMetadata metadata)
            : base(jobParams)
        {
            Action = (job) => action(this);

            Metadata = metadata;
        }
    }
}
