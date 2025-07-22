using Callisto.Domain.Commands.Company;
using Callisto.Domain.Commands.Team;
using Callisto.Domain.Handlers;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;
        private readonly TeamHandler _handler;

        public TeamController(ITeamRepository teamRepository, TeamHandler handler)
        {
            _repository = teamRepository;
            _handler = handler;
        }

        [HttpPost("/Team")]
        [AllowAnonymous]
        public object Post([FromBody] CreateTeamCommand command)
        {
            return _handler.Handler(command);
        }

        [HttpGet("/Team")]
        [AllowAnonymous]
        public object Get()
        {
            return _repository.GetAllTeams();
        }

        [HttpGet("/Team/{id}")]
        [AllowAnonymous]
        public object GetById(int id)
        {
            return _repository.GetTeamById(id);
        }

        [HttpPut("/Team")]
        [AllowAnonymous]
        public object Update([FromBody] UpdateTeamCommand command)
        {
            _handler.Handler(command);
            return true;
        }

        [HttpDelete("/Team")]
        [AllowAnonymous]
        public object Delete([FromBody] DeleteTeamCommand command)
        {
            _repository.DeleteTeamById(command.Id);
            return true;
        }
    }
}
