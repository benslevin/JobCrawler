using Serilog;

namespace JobCrawler.Logging
{
    public class LoggerManager : ILoggerManager
    {
        public ILogger<T> CreateLogger<T>() => new LoggerFactory().AddSerilog().CreateLogger<T>();

        public LoggerManager()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/webcrawler.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
