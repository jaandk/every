using System;

namespace Every.Builders
{
    public class FromBuilder : JobBuilder
    {
        internal FromBuilder(JobConfiguration config)
            : base(config)
        {
        }


        public ToBuilder From(TimeSpan from)
        {
            Configuration.From = from;

            return new ToBuilder(Configuration);
        }

        public ToBuilder From(int hours, int minutes = 0, int seconds = 0) => From(new TimeSpan(hours, minutes, seconds));
    }
}
