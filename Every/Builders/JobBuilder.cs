using System;

namespace Every
{
    public class JobBuilder
    {
        protected internal JobConfiguration Configuration { get; set; }

        internal JobBuilder(JobConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Job Do(Action<Job> job)
        {
            if (!Eve.Jobs.ContainsKey(job))
                Eve.Jobs[job] = CreateJob(job);

            return Eve.Jobs[job];
        }


        private Job CreateJob(Action<Job> job)
        {
            switch (Configuration.JobType)
            {
                case JobType.FixedInterval:
                    return CreateFixedIntervalJob(job);

                default:
                    return null;
            }
        }

        private FixedIntervalJob CreateFixedIntervalJob(Action<Job> job)
        {
            return new FixedIntervalJob(job);
        }
    }
}
