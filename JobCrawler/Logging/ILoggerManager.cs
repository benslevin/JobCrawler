namespace JobCrawler.Logging
{
    public interface ILoggerManager
    {
        ILogger<T> CreateLogger<T>();
    }
}
