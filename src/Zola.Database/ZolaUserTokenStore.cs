using System;
using IdentityModel.Client;
using Zola.Database.Models;
using Zola.MsfClient.Authentication;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Zola.Database
{
	public class ZolaUserTokenStore : IUserTokenStore
    {
        private User _user;
        private readonly MsfDbContext _dbContext;

		public ZolaUserTokenStore(MsfDbContext msfDbContext, ulong discordId)
		{
            _dbContext = msfDbContext;
            User? user = _dbContext.Users.Where(u => u.DiscordId == discordId).FirstOrDefault();

            if (user is null)
            {
                user = new User()
                {
                    DiscordId = discordId
                };
                _dbContext.Add(user);
                _dbContext.SaveChanges();
            }
           _user = user;
		}

        public string UserId => _user.Id;
        public User User => _user;
        public string? AccessToken => _user.AccessToken;

        public DateTime? AccessTokenExpiration => _user.AccessTokenExpiration;

        public string? RefreshToken => _user.RefreshToken;

        public async Task StoreToken(TokenResponse tokenResponse)
        {
            _user.AccessToken = tokenResponse.AccessToken;
            _user.AccessTokenExpiration = new(0, 0, tokenResponse.ExpiresIn);
            _user.RefreshToken = tokenResponse.RefreshToken;
            await _dbContext.SaveChangesAsync();
        }
    }
}

