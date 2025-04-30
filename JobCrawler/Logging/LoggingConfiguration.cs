using Serilog;

namespace JobCrawler.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigurLogging()
        {
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/webcrawler.log", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }
    }
}

