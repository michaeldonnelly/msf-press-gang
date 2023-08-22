using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zola.Database;
using Zola.Database.Models;
using Zola.MsfClient;
using Zola.Web.Models;
using Microsoft.Kiota.Abstractions.Authentication;


namespace Zola.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MsfDbContext _msfDbContext;
    private readonly ApiSettings _apiSettings;

    public HomeController(ILogger<HomeController> logger, MsfDbContext dbContext, IConfiguration configuration)
    {
        _logger = logger;
        _msfDbContext = dbContext;
        _apiSettings = new(configuration);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Link(string ticket)
    {
        _logger.LogInformation($"Link for ticket {ticket}");


        //Ticket? ticketRecord = _msfDbContext.Tickets.Where(t => t.Id == ticket).FirstOrDefault();
        Ticket? ticketRecord = _msfDbContext.RetrieveTicket(TicketStatus.GivenToUser, ticketId: ticket);

        if (ticketRecord is null)
        {
            _logger.LogWarning("Ticket not found");
            return BadRequest($"Unknown ticket {ticket}");
        }

        return GetAuthorizationCode(ticketRecord);
    }

    private RedirectResult GetAuthorizationCode(Ticket ticket)
    {
        Dictionary<string, string> queryParameters = new()
        {
            { "client_id", _apiSettings.ClientId },
            { "response_type", "code" },
            { "redirect_uri", _apiSettings.RedirectUri },
            { "scope", ApiSettings.Scope },
            { "state", ticket.State },
        };

        UriBuilder uriBuilder = new(ApiSettings.AuthUrl);
        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (KeyValuePair<string, string> kvp in queryParameters)
        {
            nameValueCollection[kvp.Key] = kvp.Value;
        }
        uriBuilder.Query = nameValueCollection.ToString();
        string url = uriBuilder.ToString();
        _logger.LogInformation($"Auth code URL: {url}");
        RedirectResult redirectResult = new RedirectResult(url, false);
        return redirectResult;
    }

    [Route("/callback")]
    public IActionResult Callback(string? code, string? state, string? error, string? error_description)
    {

        if (error is not null)
        {
            _logger.LogError($"error: {error}\r\nerror_description: {error_description}");
            return BadRequest(error_description);
        }

        _logger.LogInformation($"code: {code}\r\nstate: {state}");

        Ticket? ticket = _msfDbContext.RetrieveTicket(TicketStatus.CodeRequested, state: state);
        if (ticket is null)
        {
            return BadRequest("Ticket not found");
        }

        // TODO: async
        TokenResponse tokenResponse = GetAuthorizationTokenAsync(code).Result;

        Console.WriteLine($"\r\n\r\n     TOKEN RESPONSE      \r\n\r\n{tokenResponse.Raw}\r\n     --------------      \r\n");
        Console.WriteLine($"\r\n REFRESH TOKEN:  {tokenResponse.RefreshToken}");


        string? refreshToken = tokenResponse.RefreshToken;
        ticket.User.MsfRefreshToken = refreshToken;

        _msfDbContext.SaveChanges();

        //SaveTokensToUser(tokenResponse, ticket.User);



        return View();
    }

    private Task<int> SaveTokensToUser(TokenResponse tokenResponse, User user)
    {
        _logger.LogDebug("SaveTokensToUser");
        user.MsfRefreshToken = tokenResponse.RefreshToken;
        return _msfDbContext.SaveChangesAsync();
    }

    private async Task<TokenResponse> GetAuthorizationTokenAsync(string code)
    {
        _logger.LogDebug("GetAuthorizationTokenAsync");
        AuthorizationCodeTokenRequest request = new()
        {
            Address = ApiSettings.TokenUrl,
            ClientId = _apiSettings.ClientId,
            ClientSecret = _apiSettings.ClientSecret,
            Code = code,
            RedirectUri = _apiSettings.RedirectUri

        };

        CancellationToken cancellationToken = default;

        HttpClient httpClient = new();
        TokenResponse response = await httpClient.RequestAuthorizationCodeTokenAsync(request, cancellationToken);

        if (response.Exception is not null)
        {
            _logger.LogError(response.Exception.Message);
            throw response.Exception;
        }

        if (response.IsError)
        {
            Exception exception = new Exception($"error: {response.Error}\r\nerror_description: {response.ErrorDescription}");
            _logger.LogError(exception.Message);
            throw exception;
        }

        if (response.AccessToken is null)
        {
            Exception exception = new Exception("There was no exception or error, but AccessToken is null.");
            _logger.LogError(exception.Message);
            throw exception;
        }

        //Console.WriteLine($"access token: {response.AccessToken}");

        string tokenResponseString = $"TokenType: {response.TokenType}";
        tokenResponseString += "\r\n";
        tokenResponseString += $"AccessToken: {response.AccessToken}";
        tokenResponseString += "\r\n";
        tokenResponseString += $"Raw: {response.Raw}";
        tokenResponseString += "\r\n";
        Console.WriteLine("tokenResponseString:  \r\n", tokenResponseString);

        _logger.LogInformation(response.ToString());
        return response;
    }

    public IActionResult Redirect(string code, string state)  // TODO: nix
    {
        _logger.LogInformation($"code: {code}\r\nstate: {state}");
        return View();
    }
}
