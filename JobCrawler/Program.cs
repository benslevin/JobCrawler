using JobCrawler.Logging;
using JobCrawler.Repositories;
using JobCrawler.Services;
using JobCrawler.Services.StartupJobService;
using Serilog;

LoggingConfiguration.ConfigurLogging();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddSingleton<IWebScraperService, WebScraperService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IJobParserService, JobParserService>();
builder.Services.AddSingleton<IJobRepository, JobRepository>();

builder.Services.AddHostedService<StartupJobService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.MapControllers();
app.Run();
