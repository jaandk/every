using System.Collections.Generic;

namespace Every.Contracts
{
    public interface IJobManager
    {
        /// <summary>
        /// Gets all jobs in the job manager.
        /// </summary>
        ICollection<Job> Jobs { get; }

        /// <summary>
        /// Starts the job scheduler.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the job scheduler.
        /// </summary>
        void Stop();
    }
}
