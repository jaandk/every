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
        private Timer _timer;

        public ICollection<Job> Jobs { get; private set; }

        public DefaultJobManager()
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

            Parallel.ForEach(Jobs.Where(j => now >= j.Next), job => job.Execute());
        }
    }
}
