namespace Every.Builders
{
    public abstract class BuilderBase
    {
        internal JobConfiguration Configuration { get; set; }

        internal BuilderBase(JobConfiguration config)
        {
            Configuration = config;
        }
    }
}
