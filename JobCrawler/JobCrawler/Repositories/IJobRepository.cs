using JobCrawler.Models;

namespace JobCrawler.Repositories{
    public interface IJobRepository
    {
        void AddJobs(List<JobPosting> jobs);
        List<JobPosting> GetAllJobs();
    }
}