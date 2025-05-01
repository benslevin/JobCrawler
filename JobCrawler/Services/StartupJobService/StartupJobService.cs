using JobCrawler.Logging;
using JobCrawler.Repositories;

namespace JobCrawler.Services.StartupJobService
{
    public class StartupJobService : BackgroundService
    {
        private readonly ILoggerManager _logger;
        private readonly IFileService _fileSErvice;
        private readonly IWebScraperService _scraper;
        private readonly IJobParserService _jobParser;
        private readonly IJobRepository _jobRepository;

        public StartupJobService(ILoggerManager logger, IFileService fileService, IWebScraperService scraper, 
                                IJobParserService jobParser, IJobRepository jobRepository)
        {
            _logger = logger;
            _fileSErvice = fileService;
            _scraper = scraper;
            _jobParser = jobParser;
            _jobRepository = jobRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInfo("StartupJobService is starting.");
            try
            {
                var websites = _fileSErvice.ReadInputFile();
                foreach(var site in websites)
                {
                    var html = await _scraper.FetchHtml(site.Url);
                    _logger.LogInfo($"Scraped {site.Name}");
                    var parsedJobs = await _jobParser.ParseJobs(html, site.Url);
                    _jobRepository.AddJobs(parsedJobs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error running startup job.", ex);
            }

            _logger.LogInfo("Startup job finished.");
        }
    }
}
