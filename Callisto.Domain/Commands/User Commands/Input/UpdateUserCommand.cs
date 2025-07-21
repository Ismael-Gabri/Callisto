using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? CompanyId { get; private set; }
        public int? TeamId { get; private set; }
        public Email? Email { get; private set; }
        public Phone? Phone { get; private set; }
        public string? ProfileImage { get; private set; }

        public bool Validate()
        {
            return true;
        }
    }
}
