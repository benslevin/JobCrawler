using JobCrawler.Models;
using HtmlAgilityPack;

namespace JobCrawler.Services{
	public class JobParserService : IJobParserService
	{
		public List<JobPosting> ParseJobs(string htmlContent)
		{
			var jobList = new List<JobPosting>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            //need to custumize based on website
            var jobNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'job-listing')]");
            if(jobNodes is not null)
            {
                foreach(var node in jobNodes)
                {
                    var job = new JobPosting
                    {
                        Title = node.SelectSingleNode(".//h2")?.InnerText.Trim(),
                        Location = node.SelectSingleNode(".//span[@class='location']")?.InnerText.Trim(),
                        Description = node.SelectSingleNode(".//p")?.InnerText.Trim(),
                        Url = node.SelectSingleNode(".//a")?.GetAttributeValue("href", string.Empty)
                    };
                    jobList.Add(job);
                }
            }
            return jobList;
		}
	}
}