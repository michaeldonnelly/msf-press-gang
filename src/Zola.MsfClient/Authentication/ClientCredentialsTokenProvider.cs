using System;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using IdentityModel;
using IdentityModel.Client;

namespace Zola.MsfClient.Authentication
{
    public class ClientCredentialsTokenProvider : IAccessTokenProvider
    {
        public ClientCredentialsTokenProvider(ApiSettings apiSettings) //: base()
        {
            HttpClient = new();
            ApiSettings = apiSettings;
        }

        private ApiSettings ApiSettings;

        public AllowedHostsValidator AllowedHostsValidator => ApiSettings.AllowedHostsValidator;

        private HttpClient HttpClient { get; }

        public async Task<string> GetAuthorizationTokenAsync(Uri? uri = null, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
        {
            ClientCredentialsTokenRequest request = new()
            {
                Address = ApiSettings.TokenUrl,
                ClientId = ApiSettings.ClientId,
                ClientSecret = ApiSettings.ClientSecret,
            };
            TokenResponse response = await HttpClient.RequestClientCredentialsTokenAsync(request, cancellationToken);

            if (response.Exception is not null)
            {
                throw response.Exception;
            }

            if (response.IsError)
            {
                throw new Exception($"error: {response.Error}\r\nerror_description: {response.ErrorDescription}");
            }

            if (response.AccessToken is null)
            {
                throw new Exception("There was no exception or error, but AccessToken is null.");
            }

            //Console.WriteLine($"access token: {response.AccessToken}");

            return response.AccessToken;            
        }
    }
}

