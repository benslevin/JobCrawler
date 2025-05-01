using JobCrawler.Models;

namespace JobCrawler.Services{
    public interface IJobParserService
    {
        Task<List<JobPosting>> ParseJobs(string htmlContent, string url);
    }
}