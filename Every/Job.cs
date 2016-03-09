using System;

namespace Every
{
    public class Job
    {
        protected internal Action<Job> Action { get; set; }
        protected internal Func<DateTime, DateTime> CalculateNext { get; set; }

        public DateTime Next { get; protected internal set; }

        internal Job()
        {
            Next = DateTime.Now;
        }
    }

    public class Job<TMetadata> : Job
    {
        public TMetadata Metadata { get; set; }

        internal Job(TMetadata metadata)
        {
            Metadata = metadata;
        }
    }
}
