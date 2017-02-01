using System;
using System.Threading.Tasks;

namespace Every.Builders
{
    public class JobBuilder : BuilderBase
    {
        internal JobBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public Job Do(Action<Job> job, bool overlap = true)
        {
            Configuration.Overlap = overlap;

            var jobContainer = new Job(Configuration, job);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }

        public Job Do(Action job, bool overlap = true) => Do(_ => job(), overlap);
        public Job Do(Func<Task> job, bool overlap = true) => Do(_ => Task.WaitAll(job()), overlap);
        public Job Do(Func<Job, Task> job, bool overlap = true) => Do((j) => Task.WaitAll(job(j)), overlap);


        public Job<TMetadata> Do<TMetadata>(Action<Job<TMetadata>> job, TMetadata metadata, bool overlap = true)
        {
            Configuration.Overlap = overlap;

            var jobContainer = new Job<TMetadata>(Configuration, job, metadata);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }        
        
        public Job Do<TMetadata>(Func<Job<TMetadata>, Task> job, TMetadata metadata, bool overlap = true) => Do((j) => Task.WaitAll(job(j)), metadata, overlap);
    }
}
