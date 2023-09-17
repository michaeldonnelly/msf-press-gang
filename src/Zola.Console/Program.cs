#nullable disable
#pragma warning disable CS0162 // Unreachable code detected
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
using Serilog;

#if false
const bool downloadTraits = true;
const bool downloadCyclops = true;
const bool downloadPhoenix = true;
const bool downloadAllCharacters = true;
const bool prydeReport = false;
#else
const bool downloadTraits = false;
const bool downloadCyclops = true;
const bool downloadPhoenix = false;
const bool downloadAllCharacters = false;
const bool prydeReport = false;
const bool indexEffects = false;
#endif

const bool getUserProfile = false;
const bool usePlayerAuth = getUserProfile;

const string outputTemplate =
    "[{Level:w}]: {Timestamp:dd-MM-yyyy:HH:mm:ss} {MachineName} {EnvironmentName} {SourceContext} {Message}{NewLine}{Exception}";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: outputTemplate)
    .CreateLogger();

Log.Information("Starting console");

ConfigurationBuilder configurationBuilder = new();
configurationBuilder.AddUserSecrets<ApiSettings>();
// https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux
IConfiguration config = configurationBuilder.Build();
ApiSettings apiSettings = new(config);
DbSettings dbSettings = new(config);
MsfDbContext dbContext = new(Log.Logger, dbSettings);
DbInitializer.Initialize(dbContext, dbSettings);

IAuthenticationProvider authenticationProvider;
if (usePlayerAuth)
{
    ulong discordId = 559173272306974740;  // this is hard coded for testing
    ZolaUserTokenStore userTokenStore = new(dbContext, discordId);
    authenticationProvider = MsfAuthenticationProviders.PlayerAuthenticationProvider(apiSettings, userTokenStore);
}
else
{
    authenticationProvider = MsfAuthenticationProviders.GameAuthenticationProvider(apiSettings);
}

IRequestAdapter requestAdapter = new HttpClientRequestAdapter(authenticationProvider);
ApiClient client = new ApiClient(requestAdapter);
Download download = new(client, dbContext);

string tableName = "Characters";
IEnumerable<object> set = (IEnumerable<object>)dbContext.GetType().GetProperty(tableName).GetValue(dbContext, null);
int recordCount = set.Count();
Log.Debug($"Records in {tableName}: {recordCount}");



//try
//{
    if (downloadTraits)
    {
        await download.Traits();     
    }

    if (downloadAllCharacters)
    {
        await download.Characters();        
    }

    string characterId;
    CharacterInfo oneCharacter;

    if (downloadCyclops)
    {
        // GET /characters/{id}
        characterId = "Cyclops";
        oneCharacter = (await client.Game.V1.Characters[characterId].GetAsync()).Data;

        Log.Debug("Retrieved character: {Variables}", oneCharacter);
        Log.Debug("GearTierCollection.Count: {Variables}",oneCharacter.GearTierCollection.Count);
        dbContext.SafeAdd(oneCharacter);
    }

    if (downloadPhoenix)
    {
        characterId = "Phoenix";
        oneCharacter = (await client.Game.V1.Characters[characterId].GetAsync()).Data;
        Log.Debug("Retrieved character: {Variables}", oneCharacter);
        dbContext.SafeAdd(oneCharacter);
    }

    set = (IEnumerable<object>)dbContext.GetType().GetProperty(tableName).GetValue(dbContext, null);
    recordCount = set.Count();
    Log.Debug($"Records in {tableName}: {recordCount}");



    //Console.WriteLine("\r\n\r\n");
    GameReports gameReports = new(dbContext);

    if (prydeReport)
    {
        Console.WriteLine(gameReports.OneCharacter("KittyPryde"));
    }

    if (indexEffects)
    {
        Indexer indexer = new(dbContext);
        Log.Information($"indexer.IndexEffects: {indexer.IndexEffects()}");
    }


    if (getUserProfile)
    {
        PlayerCard playerCard = (await client.Player.V1.Card.GetAsync()).Data;
    Log.Information($"Retrieved player card\r\n  Name: {playerCard.Name}\r\n  TCP: {playerCard.Tcp}\r\n  Arena rank: {playerCard.LatestArena}");

    }

//Console.WriteLine(gameReports.CharactersWithEffect("27a82af8-3380-43c2-8893-8b9796391aba"));



//Console.WriteLine(gameReports.CharactersWithAllEffects());

//// GET /posts
//var allPosts = await client.Posts.GetAsync();
//Console.WriteLine($"Retrieved {allPosts?.Count} posts.");

//// GET /posts/{id}
//var specificPostId = "5";
//var specificPost = await client.Posts[specificPostId].GetAsync();
//Console.WriteLine($"Retrieved post - ID: {specificPost?.Id}, Title: {specificPost?.Title}, Body: {specificPost?.Body}");

//// POST /posts
//var newPost = new Post
//{
//    UserId = 42,
//    Title = "Testing Kiota-generated API client",
//    Body = "Hello world!"
//};

//var createdPost = await client.Posts.PostAsync(newPost);
//Console.WriteLine($"Created new post with ID: {createdPost?.Id}");

//// PATCH /posts/{id}
//var update = new Post
//{
//    // Only update title
//    Title = "Updated title"
//};

//var updatedPost = await client.Posts[specificPostId].PatchAsync(update);
//Console.WriteLine($"Updated post - ID: {updatedPost?.Id}, Title: {updatedPost?.Title}, Body: {updatedPost?.Body}");

//// DELETE /posts/{id}
//await client.Posts[specificPostId].DeleteAsync();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"{ex.GetType().ToString()} Exception: {ex.Message}");
//    Console.WriteLine(ex.StackTrace);
//}


Log.Warning("Done");
Console.ReadKey();

#pragma warning restore CS0162 // Unreachable code detected
