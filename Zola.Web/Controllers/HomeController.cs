using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zola.Database;
using Zola.MsfClient;
using Zola.Web.Models;

namespace Zola.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IOptions<ApiSettings> _options;
    private readonly MsfDbContext _msfDbContext;

    public HomeController(ILogger<HomeController> logger, MsfDbContext dbContext, IConfiguration configuration)
    {
        _logger = logger;
        _msfDbContext = dbContext;
        

        //var foo = apiOptions.Value;
        //Console.WriteLine(foo.GetType());

        //ApiSettings apiSettings1 = apiOptions.Value;
        //Console.WriteLine(apiSettings1.ApiKey);
        //_options = options;
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


        string state = Guid.NewGuid().ToString();
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
    }

    [Route("/callback")]
    public IActionResult Callback(string? code, string? state, string? error, string? error_description)
    {
        if (error is null)
        {
            Console.WriteLine($"code: {code}\r\nstate: {state}");
        }
        else
        {
            Console.WriteLine($"error: {error}\r\nerror_description: {error_description}");
        }
        return View();
    }

    public IActionResult Redirect(string code, string state)  // TODO: nix
    {
        Console.WriteLine($"code: {code}\r\nstate: {state}");
        return View();
    }
}
