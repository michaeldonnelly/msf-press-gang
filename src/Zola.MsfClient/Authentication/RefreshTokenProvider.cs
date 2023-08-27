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
        public RefreshTokenProvider(ApiSettings apiSettings, IUserTokenStore userTokenStore) //: base()
        {
            HttpClient = new();
            ApiSettings = apiSettings;
            UserTokenStore = userTokenStore;
        }

        private ApiSettings ApiSettings;

        public AllowedHostsValidator AllowedHostsValidator => ApiSettings.AllowedHostsValidator;

        private HttpClient HttpClient { get; }

        private IUserTokenStore UserTokenStore;

        public async Task<string> GetAuthorizationTokenAsync(Uri? uri = null, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
        {
            if ((UserTokenStore.AccessToken is not null) && (UserTokenStore.AccessTokenExpiration > DateTime.Now))
            {
                return UserTokenStore.AccessToken;
            }

            if (UserTokenStore.RefreshToken is null)
            {
                throw new TokenRetrievalException(1, "Account is not linked");
            }

            RefreshTokenRequest request = new()
            {
                Address = ApiSettings.TokenUrl,
                ClientId = ApiSettings.ClientId,
                ClientSecret = ApiSettings.ClientSecret,
                RefreshToken = UserTokenStore.RefreshToken,
            };
            TokenResponse response = await HttpClient.RequestRefreshTokenAsync(request, cancellationToken);

            if (response.Exception is not null)
            {
                throw new TokenRetrievalException(2, response.Exception.Message, response.Exception);
            }

            if (response.IsError)
            {
                throw new TokenRetrievalException(3, $"error: {response.Error}\r\nerror_description: {response.ErrorDescription}");
            }

            if (response.AccessToken is null)
            {
                throw new TokenRetrievalException(4, "There was no exception or error, but AccessToken is null.");
            }

            _ = UserTokenStore.StoreToken(response);
            return response.AccessToken;
        }
    }
}

