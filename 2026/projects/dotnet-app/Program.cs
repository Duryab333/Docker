using SimpleApp.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Dependency Injection
builder.Services.AddSingleton<TimeService>();

// 🔥 Configuration access
var appConfig = builder.Configuration;

var app = builder.Build();

app.MapGet("/", (TimeService timeService) =>
{
    return new
    {
        message = "SimpleApp Running",
        time = timeService.GetUtcTime(),
        appName = appConfig["AppName"]
    };
});

app.MapGet("/health", () => new
{
    status = "OK",
    env = appConfig["Environment"]
});
app.MapGet("/file", () =>
{
    var content = File.ReadAllText("Data/info.txt");

    return new
    {
        fileContent = content
    };
});
app.Run();
