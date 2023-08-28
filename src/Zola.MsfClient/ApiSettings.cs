using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Zola.MsfClient
{
	public class ApiSettings
	{
        public ApiSettings(IConfiguration config)
        {
            foreach (string key in [ "Client:ClientId", "Client:ClientSecret", "Client:RedirectUri", "Client:LinkUri" ])
            {
                if (config[key] is null)
                {
                    throw new Exception($"Can't create ApiSettings; missing value for {key} in secrets.");
                }
            }

            string? clientId = config["Client:ClientId"];
            string? clientSecret = config["Client:ClientSecret"];
            string? redirectUri = config["Client:RedirectUri"];
            string? linkUri = config["Client:LinkUri"];
            string? apiKey = config["Client:ApiKey"];

            if ((clientId is null) || (clientSecret is null) || (redirectUri is null) || (linkUri is null) || (apiKey is null))
            {
                // This should be impossible given the check above, but leaving this check here is the least intrusive way to appease VS
                throw new Exception("Can't create ApiSettings; missing value in secrets");
            }

            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            LinkUri = linkUri;
            ApiKey = apiKey;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; }

        public string LinkUri { get; set; }

        public static string Scope => "m3p.f.pr.pro m3p.f.pr.ros m3p.f.pr.inv m3p.f.pr.act m3p.f.ar.pro offline";

        public static string ApiKeyHeaderName => "x-api-key";

        public string ApiKey { get; set; }

        public static string AuthUrl => "https://hydra-public.prod.m3.scopelypv.com/oauth2/auth";

        public static string TokenUrl => "https://hydra-public.prod.m3.scopelypv.com/oauth2/token";

        private static List<string> _allowedHosts = new()
        {
            "hydra-public.prod.m3.scopelypv.com"
        };

        public static AllowedHostsValidator AllowedHostsValidator = new(_allowedHosts);

    }
}

