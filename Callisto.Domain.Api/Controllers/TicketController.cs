using Callisto.Domain.Commands;
using Callisto.Domain.Enums.Ticket;
using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketHandler _ticketHandler;

        public TicketController(ITicketRepository ticketRepository, TicketHandler ticketHandler)
        {
            _ticketRepository = ticketRepository;
            _ticketHandler = ticketHandler;
        }

        [HttpPost("/ticket")]
        [Authorize]
        public object Post([FromBody] CreateTicketCommand command)
        {
            var userIdClaim2 = User.FindFirst("userId")?.Value;
            int userId = 0;

            if (!string.IsNullOrEmpty(userIdClaim2))
            {
                int.TryParse(userIdClaim2, out userId);
            }
            return _ticketHandler.Handler(command, userId);
        }

        [HttpGet("/ticket")]
        [AllowAnonymous]
        public object Get()
        {
            return _ticketRepository.GetAllTickets();
        }

        [HttpGet("/ticket/{id}")]
        [AllowAnonymous]
        public object GetById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        [HttpDelete("/ticket/{id}")]
        [AllowAnonymous]
        public object Delete(int id)
        {
            _ticketRepository.DeleteTicketById(id);
            return true;
        }

        [HttpPut("/ticket/assign")]
        [AllowAnonymous]
        public object Delete([FromBody] UpdateTicketCommand command)
        {
            _ticketHandler.Handler(command);
            return true;
        }

        [HttpPut("/ticket/{id}/conclude")]
        [AllowAnonymous]
        public object Conclude(int id)
        {
            var command = new UpdateTicketCommand
            {
                Id = id,
                Status = ETicketStatus.Resolved
            };

            _ticketHandler.Handler(command);
            return true;
        }
    }
}
