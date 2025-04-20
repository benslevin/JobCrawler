namespace JobCrawler.Services{
    public interface IWebScraperService
    {
        Task<string> FetchHtml(string url);
    }
}