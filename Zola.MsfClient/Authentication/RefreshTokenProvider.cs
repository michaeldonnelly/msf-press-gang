using System;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using IdentityModel;
using IdentityModel.Client;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Zola.MsfClient.Authentication
{
	public class RefreshTokenProvider : IAccessTokenProvider
	{
        public RefreshTokenProvider(ApiSettings apiSettings, string refreshToken) //: base()
        {
            HttpClient = new();
            ApiSettings = apiSettings;
            RefreshToken = refreshToken;
        }

        private ApiSettings ApiSettings;

        public AllowedHostsValidator AllowedHostsValidator => ApiSettings.AllowedHostsValidator;

        private HttpClient HttpClient { get; }

        private string RefreshToken;

        public async Task<string> GetAuthorizationTokenAsync(Uri? uri = null, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
        {

            RefreshTokenRequest request = new()
            {
                Address = ApiSettings.TokenUrl,
                ClientId = ApiSettings.ClientId,
                ClientSecret = ApiSettings.ClientSecret,
                RefreshToken = RefreshToken,
            };
            TokenResponse response = await HttpClient.RequestRefreshTokenAsync(request, cancellationToken);

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

