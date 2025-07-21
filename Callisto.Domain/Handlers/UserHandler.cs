using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.User_Commands.Input;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using Callisto.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class UserHandler : IHandlers<GetUserCommand>, IHandlers<CreateUserCommand>
    {
        IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Dictionary<string, string> Notifications { get; set; }
        public ICommandResult Handler(GetUserCommand command)
        {
            var users = _repository.GetAllUsers();
            return new CommandResult<List<User>>("Sucesso", users);
        }

        public ICommandResult Handler(CreateUserCommand command)
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);

            if (name.Notifications.Count > 0 && email.Notifications.Count > 0)
                Notifications.Add("Name or Email", "Incorrect format");

            var user = new User(name, email, command.PasswordHash, phone, command.CompanyId);

            _repository.Save(user);

            return new CommandResult<User>("Sucesso", user);
        }
    }
}
