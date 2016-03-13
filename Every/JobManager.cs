using Every.Concrete;
using Every.Contracts;

namespace Every
{
    public static class JobManager
    {
        private static IJobManager _current;
        public static IJobManager Current
        {
            get { return _current ?? (_current = new DefaultJobManager()); }
            set { _current = value; }
        }
    }
}
