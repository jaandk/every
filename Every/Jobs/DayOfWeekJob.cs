using System;

namespace Every.Jobs
{
    public class DayOfWeekJob : Job
    {
        internal DayOfWeekJob(Action<Job> job, JobConfiguration configuration)
            : base(job, configuration)
        {
        }
    }
}
