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


        public Job Do(Action<Job> job, bool runSimultaneously = true)
        {
            Configuration.RunSimultaneously = runSimultaneously;

            var jobContainer = new Job(Configuration, job);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }

        public Job Do(Action job, bool runSimultaneously = true) => Do(_ => job(), runSimultaneously);
        public Job Do(Func<Task> job, bool runSimultaneously = true) => Do(_ => Task.WaitAll(job()), runSimultaneously);
        public Job Do(Func<Job, Task> job, bool runSimultaneously = true) => Do((j) => Task.WaitAll(job(j)), runSimultaneously);


        public Job<TMetadata> Do<TMetadata>(Action<Job<TMetadata>> job, TMetadata metadata, bool runSimultaneously = true)
        {
            Configuration.RunSimultaneously = runSimultaneously;

            var jobContainer = new Job<TMetadata>(Configuration, job, metadata);

            JobManager.Current.Jobs.Add(jobContainer);
            return jobContainer;
        }        
        
        public Job Do<TMetadata>(Func<Job<TMetadata>, Task> job, TMetadata metadata, bool runSimultaneously = true) => Do((j) => Task.WaitAll(job(j)), metadata, runSimultaneously);
    }
}
