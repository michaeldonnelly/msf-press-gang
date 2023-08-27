using System;
using Microsoft.EntityFrameworkCore;
using Zola.Database.Models;

namespace Zola.Database.Operations
{
	public static class TicketOperations
	{
        public static Ticket NewTicket(MsfDbContext msfDbContext, User user)
        {
            Ticket ticket = new();
            ticket.User = user;
            msfDbContext.Add(ticket);
            msfDbContext.SaveChanges();
            return ticket;
        }

        public static Ticket? RetrieveTicket(MsfDbContext msfDbContext, TicketStatus expectedStatus, string? ticketId = null, string? state = null)
		{
            Ticket? ticket;

            if (ticketId is not null)
            {
                ticket = msfDbContext.Tickets.Where(t => t.Id == ticketId)
                    .Include(ticket => ticket.User)
                    .FirstOrDefault();
            }
            else if (state is not null)
            {
                ticket = msfDbContext.Tickets.Where(t => t.State == state)
                    .Include(ticket => ticket.User)
                    .FirstOrDefault();
            }
            else
            {
                throw new Exception("You need to pass in a ticketId or a state.");
            }

            if (ticket is null)
            {
                return null;
            }

            if (ticket.Expiration < DateTime.Now)
            {
                DeleteTicket(msfDbContext, ticket);
                return null;
            }

            //if (ticket.TicketStatus != expectedStatus)
            //{
            //    DeleteTicket(msfDbContext, ticket);
            //    return null;
            //}

            return ticket;            
        }

        private static int DeleteTicket(MsfDbContext msfDbContext, Ticket ticket)
        {
            // TODO: delete the ticket
            return -1;
        }
    }
}

