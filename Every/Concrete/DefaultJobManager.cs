using Every.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Every.Concrete
{
    public class DefaultJobManager : IJobManager
    {
        private const int TimerResolution = 250;

        private Timer _timer;

        /// <summary>
        /// Fires when an job throws an exception.
        /// </summary>
        public event JobExceptionOccurredEventHandler JobExceptionOccurred;

        public ICollection<Job> Jobs { get; }

        public DefaultJobManager()
        {
            Jobs = new List<Job>();

            Start();
        }

        public void Dispose()
        {
            foreach (var job in Jobs.ToArray())
                job.Cancel();
        }


        public void Start()
        {
            if (_timer == null)
                _timer = new Timer(OnTimerElapsed, null, 0, TimerResolution);
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }


        private void OnTimerElapsed(object state)
        {
            var now = DateTimeOffset.Now;
            var jobs = Jobs.ToArray();

            Parallel.ForEach(jobs.Where(j => now >= j.Next && (j.RunSimultaneously || !j.IsRunning)), job =>
            {
                try
                {
                    job.Execute();
                }
                catch (Exception exception)
                {
                    JobExceptionOccurred?.Invoke(exception);
                }
            });
        }
    }
}
