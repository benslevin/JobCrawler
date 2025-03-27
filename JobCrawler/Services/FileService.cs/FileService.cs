using JobCrawler.Models;
using System.Text.Json;

namespace JobCrawler.Services{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<InputWebsite> ReadInputFile()
        {
            var filePath = Path.Combine(_env.WebRootPath, "website.json");
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Website list file not found.");
            }
            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<InputWebsite>>(content) ?? new List<InputWebsite>();
        }
    }
}