using Every.Contracts;
using Every.Concrete;

namespace Every
{
    public static class JobManager
    {
        public static IJobManager Current { get; set; }

        static JobManager()
        {
            Current = new DefaultJobManager();
        }
    }
}
