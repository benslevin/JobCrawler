namespace JobCrawler.Services{
    public interface IWebScraperService
    {
        string FetchHtml(string url);
    }
}