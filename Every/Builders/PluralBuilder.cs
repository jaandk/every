namespace Every
{
    public class PluralBuilder
    {
        private long _n;

        internal PluralBuilder(long n)
        {
            _n = n;
        }


        public JobBuilder Seconds()
        {
            return new JobBuilder(_n);
        }

        public JobBuilder Minutes()
        {
            return new JobBuilder(_n * 60);
        }

        public JobBuilder Hours()
        {
            return new JobBuilder(_n * 60 * 60);
        }

        public DaysBuilder Days()
        {
            return new DaysBuilder(_n * 60 * 60 * 24);
        }
    }
}
