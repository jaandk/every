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

        public bool IsRunning { get; protected set; }
        public bool RunSimultaneously { get; protected set; }

        protected Job(JobConfiguration config)
        {
            CalculateNext = config.CalculateNext;
            Next = config.First;
            RunSimultaneously = config.RunSimultaneously;

            if (Next < DateTimeOffset.Now)
                Next = CalculateNext(this);
        }

        internal Job(JobConfiguration config, Action<Job> action)
            : this(config)
        {
            Action = action;
        }


        /// <summary>
        /// Removes this job from the job manager.
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
            IsRunning = true;

            if (Next < DateTimeOffset.Now)
                Next = CalculateNext(this);

            Action(this);

            IsRunning = false;        
        }


        public override string ToString()
        {
            return $"Job, Next = {Next:dddd d MMMM yyyy HH:mm:ss}, IsRunning = {IsRunning}";
        }
    }

    public class Job<TMetadata> : Job
    {
        /// <summary>
        /// Gets or sets the metadata for this job.
        /// </summary>
        public TMetadata Metadata { get; set; }

        internal Job(JobConfiguration config, Action<Job<TMetadata>> action, TMetadata metadata)
            : base(config)
        {
            Metadata = metadata;

            Action = job => action(this);
        }
    }
}
