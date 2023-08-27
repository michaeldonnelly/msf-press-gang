using System;
using IdentityModel.Client;

namespace Zola.MsfClient.Authentication
{
	public interface IUserTokenStore
	{
        public string? AccessToken { get; }

        public DateTime? AccessTokenExpiration { get; }

        public string? RefreshToken { get; }

        public Task StoreToken(TokenResponse tokenResponse);
        //public Task StoreToken(string accessToken, DateTime accessTokenExpiration, string refreshToken);
    }
}

