using System;

namespace Every
{
    public static class Eve
    {
        public static SingularBuilder ry()
        {
            return new SingularBuilder(new Job());
        }

        public static PluralBuilder ry(int n)
        {
            return new PluralBuilder(new Job(), n);
        }

        public static DayOfWeekBuilder ry(params DayOfWeek[] daysOfWeek)
        {
            return new DayOfWeekBuilder(new Job(), daysOfWeek);
        }
    }
}
