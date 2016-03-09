namespace Every
{
    public class SingularBuilder
    {
        internal SingularBuilder()
        {
        }


        public JobBuilder Second()
        {
            return new JobBuilder(1);
        }

        public JobBuilder Minute()
        {
            return new JobBuilder(60);
        }

        public JobBuilder Hour()
        {
            return new JobBuilder(60 * 60);
        }

        public DaysBuilder Day()
        {
            return new DaysBuilder(60 * 60 * 24);
        }
    }
}
