using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zola.Database;
using Zola.Database.Models;
using Zola.MsfClient;
using Zola.Web.Models;
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


        Ticket? ticketRecord = _msfDbContext.Tickets.Where(t => t.Id == ticket).FirstOrDefault();
        if (ticketRecord is null)
        {
            _logger.LogWarning("Ticket not found");
            return BadRequest($"Unknown ticket {ticket}");
        }


        /*
        string state = ticketRecord.State;  // Guid.NewGuid().ToString();
        string clientId = "27558d21-595e-4e82-bf9a-629e68c56d50";
        string scope = "m3p.f.pr.pro m3p.f.pr.ros m3p.f.pr.inv m3p.f.pr.act m3p.f.ar.pro offline";
        string redirectUri = "http://localhost:8443/callback";
        Dictionary<string, string> queryParameters = new()
        {
            { "client_id", clientId },
            { "response_type", "code" },
            { "redirect_uri", redirectUri },
            { "scope", scope },
            { "state", state },
        };

        string url = "https://hydra-public.prod.m3.scopelypv.com/oauth2/auth";
        UriBuilder uriBuilder = new(url);
        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (KeyValuePair<string, string> kvp in queryParameters)
        {
            nameValueCollection[kvp.Key] = kvp.Value;
        }
        uriBuilder.Query = nameValueCollection.ToString();

        Console.WriteLine(uriBuilder.ToString());
        RedirectResult redirectResult = new RedirectResult(uriBuilder.ToString(), false);
        return redirectResult;
        */
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

        if (error is null)
        {
            Console.WriteLine($"code: {code}\r\nstate: {state}");
            Ticket? ticket = _msfDbContext.Tickets.Where(t => t.State == state).FirstOrDefault();

        }
        else
        {
            Console.WriteLine($"error: {error}\r\nerror_description: {error_description}");
        }
        return View();
    }


    //private string GetAccessToken(string code)
    //{

    //}

    public IActionResult Redirect(string code, string state)  // TODO: nix
    {
        Console.WriteLine($"code: {code}\r\nstate: {state}");
        return View();
    }
}
