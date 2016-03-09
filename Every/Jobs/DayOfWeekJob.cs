using System;

namespace Every.Jobs
{
    public class DayOfWeekJob : Job
    {
        internal DayOfWeekJob(Action<Job> job, JobConfiguration configuration)
            : base(job, configuration)
        {
            Next = DateTime.Now;
        }


        protected internal override void CalculateNextRun(DateTime now)
        {
            
        }
    }
}
