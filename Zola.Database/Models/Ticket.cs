using System;
using Microsoft.EntityFrameworkCore;

namespace Zola.Database.Models
{
    [Index(nameof(State))]
	public class Ticket
	{
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime Expiration { get; set; } = DateTime.Now + new TimeSpan(0, 5, 0);

        public User User { get; set; } 
        
        public string State { get; set; } = Guid.NewGuid().ToString();

        public TicketStatus TicketStatus { get; set; } = TicketStatus.New;
        
    }

    public enum TicketStatus
    {
        New,
        GivenToUser,
        CodeRequested,
        Deleted
    }
}

