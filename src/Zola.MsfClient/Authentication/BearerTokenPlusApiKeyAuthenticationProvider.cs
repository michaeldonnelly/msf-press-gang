using System;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Zola.MsfClient.Authentication
{
	public class BearerTokenPlusApiKeyAuthenticationProvider : IAuthenticationProvider
    {
        public BearerTokenPlusApiKeyAuthenticationProvider(IAccessTokenProvider accessTokenProvider, string apiKey, string apiKeyHeaderName)
        {
            AccessTokenProvider = accessTokenProvider ?? throw new ArgumentNullException(nameof(accessTokenProvider));
            ApiKey = apiKey;
            ApiKeyHeaderName = apiKeyHeaderName;
        }

        public IAccessTokenProvider AccessTokenProvider { get; private set; }
        public string ApiKey { get; private set; }
        public string ApiKeyHeaderName { get; private set; }

        private const string AuthorizationHeaderKey = "Authorization";
        private const string ClaimsKey = "claims";
            
        public async Task AuthenticateRequestAsync(RequestInformation request, Dictionary<string, object>? additionalAuthenticationContext = default, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (additionalAuthenticationContext != null &&
                additionalAuthenticationContext.ContainsKey(ClaimsKey) &&
                request.Headers.ContainsKey(AuthorizationHeaderKey))
                request.Headers.Remove(AuthorizationHeaderKey);

            if (!request.Headers.ContainsKey(AuthorizationHeaderKey))
            {
                var token = await AccessTokenProvider.GetAuthorizationTokenAsync(request.URI, additionalAuthenticationContext, cancellationToken);
                if (!string.IsNullOrEmpty(token))
                    request.Headers.Add(AuthorizationHeaderKey, $"Bearer {token}");
            }

            request.Headers.Add(ApiKeyHeaderName, ApiKey);
        }
    }
}


