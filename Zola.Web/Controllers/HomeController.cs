using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Zola.Web.Models;

namespace Zola.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
        string state = "foo";
        string clientId = "27558d21-595e-4e82-bf9a-629e68c56d50";
        string scope = "m3p.f.pr.pro m3p.f.pr.ros m3p.f.pr.inv m3p.f.pr.act m3p.f.ar.pro offline";
        string redirectUri = "http://localhost:8443/Home/Redirect";
        Dictionary<string, string> queryParameters = new()
        {
            { "client_id", clientId },
            { "response_type", "code" },
            { "redirect_uri", redirectUri },
            { "scope", scope },
            { "state", state }
        };

        string url = "https://hydra-public.prod.m3.scopelypv.com/oauth2/auth";
        UriBuilder uriBuilder = new(url);
        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (KeyValuePair<string, string> kvp in queryParameters)
        {
            nameValueCollection[kvp.Key] = kvp.Value;
        }
        uriBuilder.Query = nameValueCollection.ToString();

        ContentResult contentResult = new();
        contentResult.Content = uriBuilder.ToString();
        return contentResult;

        //RedirectResult redirectResult = new RedirectResult(uriBuilder.ToString(), false);
        //return redirectResult;
    }

    public IActionResult Redirect(string code, string state)
    {
        Console.WriteLine($"code: {code}\r\nstate: {state}");
        return View();
    }
}
