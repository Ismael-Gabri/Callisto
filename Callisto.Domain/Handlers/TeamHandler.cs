using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Commands.Team;
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
    public class TeamHandler : IHandlers<CreateTeamCommand>, IHandlers<UpdateTeamCommand>
    {
        ITeamRepository _repository;
        public TeamHandler(ITeamRepository repository)
        {
            _repository = repository;
        }
        public Dictionary<string, string> Notifications { get; set; }
        public ICommandResult Handler(CreateTeamCommand command)
        {
            if (!command.Validate())
                Notifications.Add("Command Validation", "Something is Wrong");

            var team = new Team(command.Name);

            _repository.Save(team);
            return new CommandResult<Team>("Sucesso", team);
        }

        public ICommandResult Handler(UpdateTeamCommand command)
        {
            var team = _repository.GetTeamById(command.Id);

            if (!string.IsNullOrWhiteSpace(command.Name))
                team.ChangeTeamName(command.Name);

            _repository.Update(team);
            _repository.SaveChanges();
            return new CommandResult<Team>("Sucesso", team);
        }
    }
}
