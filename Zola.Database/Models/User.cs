﻿using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Zola.Database.Models
{
	[Index(nameof(DiscordId), IsUnique = true)]
	public class User
	{
        public string Id { get; set; } = Guid.NewGuid().ToString();

		public string? MsfPid { get; set; }

		public string? MsfRefreshToken { get; set; }

		public ulong DiscordId { get; set; }  // TODO: is this a string or a number?

    }
}

