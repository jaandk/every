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

            Start();
        }


        public void Start()
        {
            if (_timer == null)
                _timer = new Timer(OnTimerElapsed, null, 0, 250);
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }


        private void OnTimerElapsed(object state)
        {
            var now = DateTime.Now;

            Parallel.ForEach(Jobs.Where(j => now >= j.Next), job =>
            {
                job.Action(job);

                job.Next = job.CalculateNext(now);
            });
        }
    }
}
