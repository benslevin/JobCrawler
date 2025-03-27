using JobCrawler.Models;

namespace JobCrawler.Services{
    public interface IFileService
    {
        List<InputWebsite> ReadInputFile ();
    }
}