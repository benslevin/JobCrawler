using JobCrawler.Models;
using HtmlAgilityPack;
using System.Text.Json.Nodes;
using System;

namespace JobCrawler.Services{
	public class JobParserService : IJobParserService
	{
        private readonly HttpClient _httpClient;
		public async Task<List<JobPosting>> ParseJobs(string htmlContent, string url)
		{
			var jobList = new List<JobPosting>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            //need to custumize based on website
            var jobNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'position')]");
            if(jobNodes is not null)
            {
                foreach(var node in jobNodes)
                {
                    var titleNode = node.SelectSingleNode(".//h2");
                    var linkNode = node.SelectSingleNode(".//a");

                    var job = new JobPosting
                    {
                        Title = titleNode.InnerText.Trim(),
                        Url = new Uri(new Uri(url), linkNode.GetAttributeValue("href", "")).ToString()
                    };
                    jobList.Add(job);
                }
            }
            return jobList;
		}
	}
}