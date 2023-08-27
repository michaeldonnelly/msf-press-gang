using System;
using Microsoft.Extensions.Configuration;

namespace Zola.Discord
{
	public class BotSettings
	{
		public BotSettings(IConfiguration config)
		{
            string? botToken = config["Bot:Token"];
            string? guildId = config["Bot:GuildId"];  

            if ((botToken is null) || (guildId is null))
            {
                throw new Exception("Can't create BotSettings; missing value in secrets");
            }

            Token = botToken;
            GuildId = Convert.ToUInt64(guildId);
		}

        public string Token { get; set; }

        public ulong GuildId { get; set; }
	}
}


