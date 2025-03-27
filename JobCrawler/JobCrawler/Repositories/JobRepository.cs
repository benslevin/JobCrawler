using JobCrawler.Models;

namespace JobCrawler.Repositories{
	public class JobRepository : IJobRepository
	{
        private readonly List<JobPosting> _jobs = new();

		public void AddJobs(List<JobPosting> jobs)
		{
			_jobs.AddRange(jobs);
		}

		public List<JobPosting> GetAllJobs()
		{
			return _jobs;
		}
	}
}