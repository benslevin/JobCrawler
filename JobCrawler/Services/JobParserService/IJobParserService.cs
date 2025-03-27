using JobCrawler.Models;

namespace JobCrawler.Services{
    public interface IJobParserService
    {
        List<JobPosting> ParseJobs(string htmlContent);
    }
}