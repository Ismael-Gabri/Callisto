using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class CreateUserHandler : IHandlers<CreateUserCommand>
    {
        public ICommandResult Handler(CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
