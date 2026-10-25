var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new { app = "Beacon", status = "ok" });

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

// The name of the machine that answered. In a cluster, that is the pod.
app.MapGet("/info", () => new { app = "Beacon", machine = Environment.MachineName });

app.Run();
