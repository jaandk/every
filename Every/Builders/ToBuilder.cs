using System;

namespace Every.Builders
{
    public class ToBuilder : BuilderBase
    {
        internal ToBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public UtcBuilder To(TimeSpan to)
        {
            Configuration.To = to;

            var currCalcNext = Configuration.CalculateNext;

            Configuration.CalculateNext = job =>
            {
                var next = currCalcNext(job);

                if (next.TimeOfDay > Configuration.To && (Configuration.To > Configuration.From || (Configuration.To < Configuration.From && next.TimeOfDay < Configuration.From)))
                {
                    next = new DateTimeOffset(next.Year, next.Month, next.Day, Configuration.From.Hours, Configuration.From.Minutes, Configuration.From.Seconds, next.Offset);

                    if (next < DateTimeOffset.Now)
                        next = next.AddDays(1);
                }

                return next;
            };

            return new UtcBuilder(Configuration);
        }

        public UtcBuilder To(int hours, int minutes = 0, int seconds = 0) => To(new TimeSpan(hours, minutes, seconds));
    }
}
