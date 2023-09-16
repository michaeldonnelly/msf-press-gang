using System.Runtime.Intrinsics.X86;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Zola.MsfClient;
using Zola.MsfClient.Models;
using Microsoft.Kiota.Abstractions;
using Zola.MsfClient.Authentication;
using Zola.Database;
using Microsoft.Extensions.Configuration;
using Zola.Database.Reports;
using Microsoft.EntityFrameworkCore;
using Zola.Database.Models;
using Zola.Database.Searches;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Events;



namespace Zola.Discord
{
    public class Program
    {
        private ulong _guildId;   // quick creation of handlers for iterative debugging
        public static Task Main(string[] args) => new Program().MainAsync();

        private DiscordSocketClient _discordClient;
        private ApiClient _apiClient;
        private MsfDbContext _dbContext;
        private ApiSettings _apiSettings;
        private BotSettings _botSettings;
        private const string outputTemplate = "[{Level:w}]: {Timestamp:dd-MM-yyyy:HH:mm:ss} {MachineName} {EnvironmentName} {SourceContext} {Message}{NewLine}{Exception}";

        public Program()
        {
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Information()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.OpenTelemetry(opts =>
                {
                    opts.ResourceAttributes = new Dictionary<string, object>
                    {
                        ["app"] = "discord",
                        ["runtime"] = "dotnet",
                        ["service.name"] = "Zola.Discord"
                    };
                })
                .CreateLogger();

            Log.Information("Starting up Discord bot");

            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddUserSecrets<ApiSettings>();
            // https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
            IConfiguration config = configurationBuilder.Build();

            _apiSettings = new(config);
            _botSettings = new(config);
            _guildId = _botSettings.GuildId;
            IAuthenticationProvider authenticationProvider = MsfAuthenticationProviders.GameAuthenticationProvider(_apiSettings);
            IRequestAdapter requestAdapter = new HttpClientRequestAdapter(authenticationProvider);
            _apiClient = new ApiClient(requestAdapter);

            DbSettings dbSettings = new(config);
            _dbContext = new(dbSettings);
            DbInitializer.Initialize(_dbContext, dbSettings);

            _discordClient = new DiscordSocketClient();
            _discordClient.Log += LogAsync;
            _discordClient.Ready += Client_Ready;
        }

        public async Task MainAsync()
        {
            Download download = new(_apiClient, _dbContext);

            try
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string tableName = "Characters";
                IEnumerable<object> set = (IEnumerable<object>)_dbContext.GetType().GetProperty(tableName).GetValue(_dbContext, null);
                int recordCount = set.Count();
                Log.Debug("Records in {Variables}", tableName, recordCount);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex.Message);
            }



            CommandHandler commandHandler = new(_dbContext, _discordClient, _apiSettings);
            _discordClient.SlashCommandExecuted += commandHandler.SlashCommandHandler;

            await _discordClient.LoginAsync(TokenType.Bot, _botSettings.Token);
            await _discordClient.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage message)
        {
            var severity = message.Severity switch
            {
                LogSeverity.Critical => LogEventLevel.Fatal,
                LogSeverity.Error => LogEventLevel.Error,
                LogSeverity.Warning => LogEventLevel.Warning,
                LogSeverity.Info => LogEventLevel.Information,
                LogSeverity.Verbose => LogEventLevel.Verbose,
                LogSeverity.Debug => LogEventLevel.Debug,
                _ => LogEventLevel.Information
            };
            Log.Write(severity, message.Exception, "[{Source}] {Message}", message.Source, message.Message);            
            return Task.CompletedTask;
        }

        public async Task Client_Ready()
        {
            CommandBuilder commandBuilder = new(_dbContext, _discordClient, _guildId);
            await commandBuilder.Register();
            //commandBuilder.Deregister();
        }

      
    }
}


