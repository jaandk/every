using Every.Builders;
using System;

namespace Every
{
    public class Job
    {
        protected Func<Job, DateTime> CalculateNext { get; set; }
        protected Action<Job> Action { get; set; }

        /// <summary>
        /// Gets next time that this job will be executed at.
        /// </summary>
        public DateTime Next { get; protected set; }

        internal Job(JobConfiguration config)
        {
            CalculateNext = config.CalculateNext;
            Next = config.First;
        }

        internal Job(Action<Job> action, JobConfiguration config)
            : this(config)
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

        internal Job(Action<Job<TMetadata>> action, JobConfiguration config, TMetadata metadata)
            : base(config)
        {
            Metadata = metadata;

            Action = job => action(this);
        }
    }
}
