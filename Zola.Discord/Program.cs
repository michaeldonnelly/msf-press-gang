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

namespace Zola.Discord
{
    public class Program
    {
        private ulong _guildId;   // quick creation of handlers for iterative debugging
        public static Task Main(string[] args) => new Program().MainAsync();

        private DiscordSocketClient _discordClient;
        private ApiClient _apiClient;
        private MsfDbContext _dbContext;

        public async Task MainAsync()
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddUserSecrets<ApiSettings>();
            // https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
            IConfiguration config = configurationBuilder.Build();

            ApiSettings apiSettings = new(config);
            BotSettings botSettings = new(config);
            _guildId = botSettings.GuildId;
            IAuthenticationProvider authenticationProvider = MsfAuthenticationProviders.GameAuthenticationProvider(apiSettings);
            IRequestAdapter requestAdapter = new HttpClientRequestAdapter(authenticationProvider);
            _apiClient = new ApiClient(requestAdapter);

            DbSettings dbSettings = new(config);
            _dbContext = new(dbSettings);
            DbInitializer.Initialize(_dbContext, dbSettings);
            Download download = new(_apiClient, _dbContext);


            string tableName = "Characters";
            IEnumerable<object> set = (IEnumerable<object>)_dbContext.GetType().GetProperty(tableName).GetValue(_dbContext, null);
            int recordCount = set.Count();
            Console.WriteLine($"Records in {tableName}: {recordCount}");


            _discordClient = new DiscordSocketClient();
            _discordClient.Log += Log;
            _discordClient.Ready += Client_Ready;

            CommandHandler commandHandler = new(_dbContext, _discordClient);
            _discordClient.SlashCommandExecuted += commandHandler.SlashCommandHandler;

            await _discordClient.LoginAsync(TokenType.Bot, botSettings.Token);
            await _discordClient.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task Client_Ready()
        {
            CommandBuilder commandBuilder = new(_dbContext, _discordClient, _guildId);
            //commandBuilder.Register();
            //commandBuilder.Deregister();
        }

      
    }
}


