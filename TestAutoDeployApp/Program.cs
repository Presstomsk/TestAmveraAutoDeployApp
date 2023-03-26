var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/ping", () => "pong");

app.MapGet("info", () => 
{
    return new
    {
        Environment.ProcessorCount,
        Environment.MachineName,
        Environment.OSVersion,
        Environment.Version,
    };
    
});

app.Run();
