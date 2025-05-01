using JobCrawler.Logging;

namespace JobCrawler.Services{
	public class WebScraperService : IWebScraperService
	{
        private readonly HttpClient _httpClient;
        private readonly ILoggerManager _logger;

        public WebScraperService (HttpClient httpClient, ILoggerManager loggerManager)
        {
            _httpClient = httpClient;
            _logger = loggerManager;
        }

        public async Task<string> FetchHtml(string url)
        {
            _logger.LogInfo($"Fetching HTML from {url}");
            try
            {
                var response = _httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                _logger.LogInfo($"Successfully fetched HTML from {url}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to fetch HTML from {url}", ex);
                return string.Empty;
            }
        }
	}
}