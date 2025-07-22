using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Company
{
    public class DeleteCompanyCommand : ICommand
    {
        public DeleteCompanyCommand() { }
        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public Dictionary<string, string> Notifications { get; private set; } = new();
        public bool Validate()
        {
            return true;
        }
    }
}
