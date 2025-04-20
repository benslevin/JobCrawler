using JobCrawler.Logging;
using JobCrawler.Repositories;
using JobCrawler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddSingleton<IWebScraperService, WebScraperService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IJobParserService, JobParserService>();
builder.Services.AddSingleton<IJobRepository, JobRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
