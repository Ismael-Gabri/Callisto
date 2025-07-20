using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.Ticket_Commands;
using Callisto.Domain.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers.Ticket_Handlers
{
    public class DeleteTicketHandler : IHandlers<DeleteTicketCommand>
    {
        public ICommandResult Handler(DeleteTicketCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
