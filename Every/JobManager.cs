using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Every
{
    public class JobManager
    {
        private static JobManager _instance;
        public static JobManager Instance => _instance ?? (_instance = new JobManager());

        private Timer _timer;

        public List<Job> Jobs { get; private set; }

        private JobManager()
        {
            Jobs = new List<Job>();

            _timer = new Timer(OnTimerElapsed, null, 0, 250);
        }


        private void OnTimerElapsed(object state)
        {
            var now = DateTime.Now;

            Parallel.ForEach(Jobs.Where(j => now >= j.Next), (job) =>
            {
                job.JobAction(job);

                job.CalculateNextRun(now);
            });
        }
    }
}
