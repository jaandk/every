using System;

namespace Every
{
    public class JobBuilder
    {
        internal JobParameters Parameters { get; set; }

        internal JobBuilder(JobParameters jobParams)
        {
            Parameters = jobParams;
        }


        public Job Do(Action<Job> job)
        {
            var jobContainer = new Job(job, Parameters);

            JobManager.Instance.Jobs.Add(jobContainer);
            return jobContainer;
        }

        public Job Do(Action job)
        {
            return Do(_ => job());
        }

        public Job<TMetadata> Do<TMetadata>(Action<Job<TMetadata>> job, TMetadata metadata)
        {
            var jobContainer = new Job<TMetadata>(job, Parameters, metadata);

            JobManager.Instance.Jobs.Add(jobContainer);
            return jobContainer;
        }
    }
}
