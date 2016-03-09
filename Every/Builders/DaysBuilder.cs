using System;

namespace Every
{
    public class DaysBuilder : JobBuilder
    {
        internal DaysBuilder(Job job)
            : base(job)
        {
        }


        public JobBuilder At(TimeSpan at)
        {
            var nowDate = DateTime.Now;
            var nowTime = nowDate.TimeOfDay;

            Job.Next = nowDate.Add(at - nowTime);

            if (nowTime > at)
                Job.Next = Job.Next.AddDays(1);
                
            return new JobBuilder(Job);
        }

        public JobBuilder At(int hours, int minutes, int seconds = 0)
        {
            return At(new TimeSpan(hours, minutes, seconds));
        }
    }
}
