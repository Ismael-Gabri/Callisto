using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Team
{
    public class CreateTeamCommand : ICommand
    {
        public CreateTeamCommand() { }

        public CreateTeamCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
