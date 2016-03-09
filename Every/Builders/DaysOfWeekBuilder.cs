using System.Linq;

namespace Every.Builders
{
    public class DayOfWeekBuilder : AtBuilder
    {
        internal DayOfWeekBuilder(JobParameters jobParams)
            : base(jobParams)
        {
            while (!Parameters.DaysOfWeek.Contains(Parameters.Next.DayOfWeek))
                Parameters.Next = Parameters.Next.AddDays(1);

            Parameters.CalculateNext = (job) =>
            {
                var next = Parameters.Next;

                do
                    next = next.AddDays(1);
                while (!Parameters.DaysOfWeek.Contains(next.DayOfWeek));

                return next;
            };
        }
    }
}
