using JobCrawler.Logging;

namespace JobCrawler.Services{
	public class WebScraperService : IWebScraperService
	{
        private readonly HttpClient _httpClient;
        private readonly ILogger<WebScraperService> _logger;

        public WebScraperService (HttpClient httpClient, ILoggerManager loggerManager)
        {
            _httpClient = httpClient;
            _logger = loggerManager.CreateLogger<WebScraperService>();
        }

        public async Task<string> FetchHtml(string url)
        {
            _logger.LogInformation("Fetching HTML from {Url}", url);
            try
            {
                var response = _httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("Successfully fetched HTML from {Url}", url);
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch HTML from {Url}", url);
                return string.Empty;
            }
        }
	}
}