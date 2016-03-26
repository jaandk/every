using Every.Builders;
using System;

namespace Every
{
    public class Job
    {
        protected Func<Job, DateTimeOffset> CalculateNext { get; set; }

        /// <summary>
        /// Gets or sets the action that this job executes.
        /// </summary>
        public Action<Job> Action { get; set; }

        /// <summary>
        /// Gets next time that this job will be executed at.
        /// </summary>
        public DateTimeOffset Next { get; protected set; }

        internal Job(JobConfiguration config)
        {
            CalculateNext = config.CalculateNext;
            Next = config.First;

            if (Next < DateTimeOffset.Now)
                Next = CalculateNext(this);
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

        /// <summary>
        /// Executes this job's action and sets the next moment to run.
        /// </summary>
        public void Execute()
        {
            if (Next < DateTimeOffset.Now)
                Next = CalculateNext(this);

            Action(this);            
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
