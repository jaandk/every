using System;
using System.Collections.Generic;

namespace Every.Contracts
{
    public interface IJobManager : IDisposable
    {
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
