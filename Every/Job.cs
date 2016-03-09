using Every.Builders;
using System;

namespace Every
{
    public class Job
    {
        protected Func<Job, DateTime> CalculateNext { get; set; }
        protected internal Action<Job> Action { get; set; }
        protected internal JobConfiguration Parameters { get; set; }

        /// <summary>
        /// Gets next time that this job will be executed at.
        /// </summary>
        public DateTime Next { get; protected set; }

        internal Job(JobConfiguration jobParams)
        {
            Parameters = jobParams;

            CalculateNext = jobParams.CalculateNext;
            Next = jobParams.Next;
        }

        internal Job(Action<Job> action, JobConfiguration jobParams)
            : this(jobParams)
        {
            Action = action;
        }


        /// <summary>
        /// Removes this job from the scheduler.
        /// </summary>
        public void Cancel()
        {
            JobManager.Current.Jobs.Remove(this);
        }


        internal void Execute()
        {
            Action(this);

            Next = CalculateNext(this);
        }
    }

    public class Job<TMetadata> : Job
    {
        /// <summary>
        /// Gets or sets the metadata for this job.
        /// </summary>
        public TMetadata Metadata { get; set; }

        internal Job(Action<Job<TMetadata>> action, JobConfiguration jobParams, TMetadata metadata)
            : base(jobParams)
        {
            Action = job => action(this);

            Metadata = metadata;
        }
    }
}
