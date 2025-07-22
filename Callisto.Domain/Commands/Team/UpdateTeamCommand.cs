using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Team
{
    public class UpdateTeamCommand : ICommand
    {
        public UpdateTeamCommand() { }

        public UpdateTeamCommand(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
