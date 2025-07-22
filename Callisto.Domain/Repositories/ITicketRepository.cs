using Callisto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface ITicketRepository
    {
        void Save(Ticket ticket);
        void Update(Ticket ticket);
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int ticketId);
        void DeleteTicketById(int ticketId);
        void SaveChanges();
    }
}
