using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CallistoContext _context;
        public TicketRepository(CallistoContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetTicketById(int ticketId)
        {
            return _context.Tickets.FirstOrDefault(u => u.Id == ticketId);
        }

        public void Save(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteTicketById(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }
    }
}
