
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
});
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();


builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

//builder.WebHost.ConfigureLogging((hostingContext, logging) =>
//{
//    logging.ClearProviders(); // Clear out existing logging providers

//    // Add configuration from appsettings.json
//    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

//    // Add console logging
//    logging.AddConsole();

//    // Add debug logging
//    logging.AddDebug();
//});

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
