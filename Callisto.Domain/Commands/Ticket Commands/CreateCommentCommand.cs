using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Ticket_Commands
{
    public class CreateCommentCommand : ICommand
    {
        public CreateCommentCommand() { }

        public CreateCommentCommand(int userId, int ticketId, string comment)
        {
            UserId = userId;
            TicketId = ticketId;
            Comment = comment;
        }

        public int UserId { get; set; }
        public int TicketId { get; set; }
        public string Comment { get; set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
