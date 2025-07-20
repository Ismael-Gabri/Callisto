using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Ticket_Commands
{
    public class DeleteTicketCommand : ICommand
    {
        public DeleteTicketCommand() { }

        public DeleteTicketCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public Dictionary<string, string> Notifications { get; private set; } = new();
        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
