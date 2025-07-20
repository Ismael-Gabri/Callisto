using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.User_Commands.Input;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class UserHandler : IHandlers<GetUserCommand>
    {
        IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handler(GetUserCommand command)
        {
            var users = _repository.GetAllUsers();
            return new CommandResult<List<User>>("Sucesso", users);
        }
    }
}
