using Callisto.Domain.Commands.Ticket_Commands;
using Callisto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface ITicketCommentRepository
    {
        object Save(TicketComment team);
    }
}
