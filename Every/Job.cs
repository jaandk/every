using Every.Builders;
using System;
using System.Threading.Tasks;

namespace Every
{
    public class Job
    {
        protected Func<DateTimeOffset, DateTimeOffset> CalculateNext { get; set; }

        protected Action<Job> Action { get; set; }

        /// <summary>
        /// Gets next time that this job will be executed at.
        /// </summary>
        public DateTimeOffset Next { get; protected set; }

        public bool IsRunning { get; protected set; }
        public bool RunSimultaneously { get; protected set; }

        protected Job(JobConfiguration config)
        {
            Next = config.First;
            CalculateNext = config.CalculateNext;
            
            RunSimultaneously = config.Overlap;

            if (Next < DateTimeOffset.Now)
                Next = CalculateNext(Next);
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

            try
            {
                if (RunSimultaneously && Next < DateTimeOffset.Now)
                    Next = CalculateNext(Next);

                Action(this);

                if (!RunSimultaneously && Next < DateTimeOffset.Now)
                    Next = CalculateNext(DateTimeOffset.Now);
            }
            finally
            {
                IsRunning = false;
            }
        }


        public override string ToString() => $"Job, Next = {Next:dddd d MMMM yyyy HH:mm:ss}, IsRunning = {IsRunning}";
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
