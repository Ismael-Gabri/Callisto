using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Team
{
    public class DeleteTeamCommand : ICommand
    {
        public DeleteTeamCommand() { }
        public DeleteTeamCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
