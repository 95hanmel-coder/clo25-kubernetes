var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.WriteIndented = true);
var app = builder.Build();

app.MapGet("/", () => new
{
    app = "Beacon",
    status = "ok",
    version = "4"
});

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

// The name of the machine that answered. In a cluster, that is the pod.
app.MapGet("/info", () => new
{
    app = "Beacon",
    machine = Environment.MachineName,
    environment = Environment.GetEnvironmentVariable("BEACON_ENVIRONMENT") ?? "unset",
    message = Environment.GetEnvironmentVariable("BEACON_MESSAGE") ?? "unset",
    apiKeySet = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BEACON_API_KEY"))
});

app.Run();
