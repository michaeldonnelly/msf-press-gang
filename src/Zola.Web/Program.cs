using Zola.Database;
using Zola.MsfClient;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddUserSecrets<ApiSettings>();
// https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
IConfiguration config = configurationBuilder.Build();


// TODO: do we even need these lines?
DbSettings dbSettings = new(config);
MsfDbContext dbContext = new(dbSettings);

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MsfDbContext>();
builder.Services.AddSingleton<IConfiguration>(config);

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
