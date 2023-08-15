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
    }
}

