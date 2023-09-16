using Zola.Database;
using Zola.MsfClient;
using Zola.Web;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

const string outputTemplate =
    "[{Level:w}]: {Timestamp:dd-MM-yyyy:HH:mm:ss} {MachineName} {EnvironmentName} {SourceContext} {Message}{NewLine}{Exception}";


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .WriteTo.Console(outputTemplate: outputTemplate)
    .WriteTo.OpenTelemetry(opts =>
    {
        opts.ResourceAttributes = new Dictionary<string, object>
        {
            ["app"] = "web",
            ["runtime"] = "dotnet",
            ["service.name"] = "MainService"
        };
    })
    .CreateLogger();

Log.Information("Starting up");

ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddUserSecrets<ApiSettings>();
// https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
IConfiguration config = configurationBuilder.Build();


// TODO: do we even need these lines?
DbSettings dbSettings = new(config);
MsfDbContext dbContext = new(dbSettings);

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console()
//    //.WriteTo.GrafanaLoki("https://logs-prod-006.grafana.net")
//    .WriteTo.GrafanaLoki("http://localhost:3100")
//    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MsfDbContext>();
builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.AddSingleton<Instrumentor>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
        tracerProviderBuilder
            .AddSource(Instrumentor.ServiceName)
            .ConfigureResource(resource => resource
                .AddService(Instrumentor.ServiceName))
            .AddAspNetCoreInstrumentation(opts =>
            {
                opts.Filter = ctx =>
                {
                    var ignore = new[]
                    {
                        "/_blazor", "/_framework", ".css",
                        "/css", "/favicon"
                    };
                    return !ignore.Any(s => ctx.Request.Path.Value!.Contains(s));
                };
            })
            .AddHttpClientInstrumentation(opts =>
            {
                var ignore = new[] { "/loki/api" };

                opts.FilterHttpRequestMessage = req =>
                {
                    return !ignore.Any(s => req.RequestUri!.ToString().Contains(s));
                };
            })
            .AddOtlpExporter())
    .WithMetrics(metricsProviderBuilder =>
        metricsProviderBuilder
            .AddMeter(Instrumentor.ServiceName)
            .ConfigureResource(resource => resource
                .AddService(Instrumentor.ServiceName))
            .AddRuntimeInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation().AddOtlpExporter());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSerilogRequestLogging();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

Log.Information("Shut down complete");
Log.CloseAndFlush();
