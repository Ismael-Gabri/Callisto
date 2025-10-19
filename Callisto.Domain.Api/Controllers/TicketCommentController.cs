using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Ticket_Commands;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        private readonly ITicketCommentRepository _ticketRepository;

        public TicketCommentController(ITicketCommentRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPost("/ticket/comment")]
        [AllowAnonymous]
        public object Post([FromBody] CreateCommentCommand command)
        {
            var ticketComment = new TicketComment(command.TicketId, command.UserId, command.Comment);
            return _ticketRepository.Save(ticketComment);
        }
    }
}
