using System;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Zola.MsfClient.Authentication
{
	public static class MsfAuthenticationProviders
	{
		public static IAuthenticationProvider GameAuthenticationProvider(ApiSettings apiSettings)
		{
            IAccessTokenProvider accessTokenProvider = new ClientCredentialsTokenProvider(apiSettings);
            IAuthenticationProvider authenticationProvider = new BearerTokenPlusApiKeyAuthenticationProvider(accessTokenProvider, apiSettings.ApiKey, ApiSettings.ApiKeyHeaderName);
            return authenticationProvider;
        }

        // NOTE: THis isn't tested yet.  It might never have worked.
        public static IAuthenticationProvider PlayerAuthenticationProvider(ApiSettings apiSettings, IUserTokenStore userTokenStorage)
        {
            IAccessTokenProvider accessTokenProvider = new RefreshTokenProvider(apiSettings, userTokenStorage);
            IAuthenticationProvider authenticationProvider = new BearerTokenPlusApiKeyAuthenticationProvider(accessTokenProvider, apiSettings.ApiKey, ApiSettings.ApiKeyHeaderName);
            return authenticationProvider;
        }

    }
}

