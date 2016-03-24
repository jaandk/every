using System;

namespace Every.Builders
{
    public class JobBuilder : BuilderBase
    {
        internal JobBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public Job Do(Action<Job> job)
        {
            var jobContainer = new Job(job, Configuration);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }

        public Job Do(Action job)
        {
            return Do(_ => job());
        }

        public Job<TMetadata> Do<TMetadata>(Action<Job<TMetadata>> job, TMetadata metadata)
        {
            var jobContainer = new Job<TMetadata>(job, Configuration, metadata);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }
    }
}
