using System;
using System.Collections.Generic;

namespace Every
{
    public static class Eve
    {
        internal static Dictionary<Action<Job>, Job> Jobs { get; private set; }

        static Eve()
        {
            Jobs = new Dictionary<Action<Job>, Job>();
        }


        public static SingularBuilder ry()
        {
            return new SingularBuilder();
        }

        public static PluralBuilder ry(int n)
        {
            return new PluralBuilder(n);
        }

        public static DayOfWeekBuilder ry(params DayOfWeek[] daysOfWeek)
        {
            return new DayOfWeekBuilder(daysOfWeek);
        }
    }
}
