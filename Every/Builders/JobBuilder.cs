using System;

namespace Every.Builders
{
    public class JobBuilder : BuilderBase
    {
        internal JobBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public Job Do(Action<Job> job, bool runSimultaneously = true)
        {
            Configuration.RunSimultaneously = runSimultaneously;

            var jobContainer = new Job(Configuration, job);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }

        public Job Do(Action job, bool runSimultaneously = true) => Do(_ => job(), runSimultaneously);

        public Job<TMetadata> Do<TMetadata>(Action<Job<TMetadata>> job, TMetadata metadata, bool runSimultaneously = true)
        {
            Configuration.RunSimultaneously = runSimultaneously;

            var jobContainer = new Job<TMetadata>(Configuration, job, metadata);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }
    }
}
