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
    public class DeleteUserHandler : IHandlers<DeleteUserCommand>
    {
        public ICommandResult Handler(DeleteUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
