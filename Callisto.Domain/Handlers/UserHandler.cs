using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.User_Commands.Input;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Enums;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using Callisto.Domain.Value_Objects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class UserHandler : IHandlers<GetUserCommand>, IHandlers<CreateUserCommand>, IHandlers<UpdateUserCommand>
    {
        IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
            Notifications = new Dictionary<string, string>();
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
                return new CommandResult<Dictionary<string, string>>("Dados de cadastro inválidos", command.Notifications);

            //Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);

            if (name.Notifications.Count > 0 || email.Notifications.Count > 0)
                return new CommandResult<string>("Nome ou e-mail em formato inválido", string.Empty);

            var user = new User(name, email, command.PasswordHash, phone, command.CompanyId);

            var hasher = new PasswordHasher<User>();
            user.SetPasswordHash(hasher.HashPassword(user, command.PasswordHash));

            _repository.Save(user);

            return new CommandResult<User>("Sucesso", user);
        }

        public ICommandResult Handler(UpdateUserCommand command)
        {
            if (!command.Validate()) //Verificar Validação
                Notifications.Add("Command Validation", "Something is Wrong");

            var user = _repository.GetUserById(command.Id);

            if (!string.IsNullOrWhiteSpace(command.FirstName))
                user.ChangeFirstName(command.FirstName);

            if (!string.IsNullOrWhiteSpace(command.LastName))
                user.ChangeLastName(command.LastName);

            if (command.Email?.Address != null)
                user.ChangeEmail(command.Email.Address);

            if (command.TeamId.HasValue)
                user.ChangeTeam(command.TeamId.Value);

            if (command.Role.HasValue)
                user.ChangeRole((ERole)command.Role.Value);

            if (command.Phone?.CellPhone != null)
                user.ChangePhone(command.Phone.CellPhone);

            if (!string.IsNullOrWhiteSpace(command.ProfileImage))
                user.ChangeProfileImage(command.ProfileImage);



            _repository.Update(user);
            _repository.SaveChanges();

            return new CommandResult<User>("Campo alterado com sucesso!", user);
        }
    }
}
