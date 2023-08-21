using System;
using Microsoft.EntityFrameworkCore;

namespace Zola.Database.Models
{
    [Index(nameof(State))]
	public class Ticket
	{
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime Expiration { get; set; } = DateTime.Now + new TimeSpan(0, 5, 0);

        public string UserId { get; set; }
        
        public string State { get; set; } = Guid.NewGuid().ToString();

    }
}

