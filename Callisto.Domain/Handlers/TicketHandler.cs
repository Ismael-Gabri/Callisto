using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.Ticket_Commands;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers.Contracts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Handlers
{
    public class TicketHandler : IHandlers<CreateTicketCommand>, IHandlers<UpdateTicketCommand>
    {
        ITicketRepository _repository;
        IUserRepository _userRepository;
        ITeamRepository _teamRepository;
        ICompanyRepository _companyRepository;
        public TicketHandler(ITicketRepository repository, IUserRepository userRepository, ITeamRepository teamRepository, ICompanyRepository companyRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _companyRepository = companyRepository;
        }
        public Dictionary<string, string> Notifications { get; set; }

        public ICommandResult Handler(CreateTicketCommand command, int userId)
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            //Recuperar e validar o User
            var user = _userRepository.GetUserById(userId);



            //Recuperar e validar o team
            var team = _teamRepository.GetTeamById(user.TeamId);

            //Recuperar e validar o company
            var company = _companyRepository.GetCompanyById(user.CompanyId);

            //Criar Ticket
            var ticket = new Ticket(company.Id, team.Id, user.Id, command.Title, command.Description, command.Priority);

            _repository.Save(ticket);
            _repository.SaveChanges();

            return new CommandResult<Ticket>("Sucesso", ticket);
        }

        public ICommandResult Handler(UpdateTicketCommand command)
        {
            if (!command.Validate()) //Verificar Validação
                Notifications.Add("Command Validation", "Something is Wrong");

            var ticket = _repository.GetTicketById(command.Id);

            if (command.TeamId.HasValue)
                ticket.ChangeTeam(command.TeamId.Value);

            if (!string.IsNullOrWhiteSpace(command.Title))
                ticket.ChangeTitle(command.Title);

            if (!string.IsNullOrWhiteSpace(command.Description))
                ticket.ChangeDescription(command.Description);

            if (command.Priority.HasValue)
                ticket.ChangePriority(command.Priority.Value);

            if (command.Status.HasValue)
                ticket.ChangeStatus(command.Status.Value);

            if (command.ResolutionDate.HasValue)
                ticket.SetResolutionDate(command.ResolutionDate.Value);

            _repository.Update(ticket);
            _repository.SaveChanges();

            return new CommandResult<Ticket>("Ticket atualizado com sucesso!", ticket);
        }

        public ICommandResult Handler(CreateTicketCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
