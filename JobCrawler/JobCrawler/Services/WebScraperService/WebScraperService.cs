namespace JobCrawler.Services{
	public class WebScraperService : IWebScraperService
	{
        private readonly HttpClient _httpClient;

        public WebScraperService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string FetchHtml(string url)
        {
            var response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
	}
}