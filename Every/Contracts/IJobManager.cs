using System;
using System.Collections.Generic;

namespace Every.Contracts
{
    public delegate void JobExceptionOccurredEventHandler(Exception exception);

    public interface IJobManager : IDisposable
    {
        event JobExceptionOccurredEventHandler JobExceptionOccurred;

        /// <summary>
        /// Gets all jobs in the job manager.
        /// </summary>
        ICollection<Job> Jobs { get; }

        /// <summary>
        /// Starts the job manager.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the job manager.
        /// </summary>
        void Stop();
    }
}
