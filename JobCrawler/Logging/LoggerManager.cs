using Serilog;

namespace JobCrawler.Logging
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger<LoggerManager> _logger;

        public LoggerManager(ILogger<LoggerManager> logger)
        {
            _logger = logger;
        }

        public void LogInfo(string message) => _logger.LogInformation(message);

        public void LogWarn(string message) => _logger.LogWarning(message);

        public void LogDebug(string message) => _logger.LogDebug(message);

        public void LogError(string message, Exception? ex = null) =>
            _logger.LogError(ex, message);
    }
}
