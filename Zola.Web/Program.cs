using Zola.Database;
using Zola.MsfClient; 

ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddUserSecrets<ApiSettings>();
// https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
IConfiguration config = configurationBuilder.Build();
ApiSettings apiSettings = new(config);


DbSettings dbSettings = new(config);
MsfDbContext dbContext = new(dbSettings);
//DbInitializer.Initialize(dbContext, dbSettings);




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOptions<ApiSettings>().Bind(config);
//builder.Services.AddOptions<DbSettings>().Bind(config);
builder.Services.AddDbContext<MsfDbContext>();

builder.Services.AddSingleton<IConfiguration>(config);
// TODO: add apisettings - maybe IConfiguration?


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllerRoute("callback", "{controller=Home}/{action=Callback}"); // TODO: nix

app.Run();
