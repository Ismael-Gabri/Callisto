using Callisto.Domain.Commands;
using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [AllowAnonymous]
        public object Post([FromBody] CreateTicketCommand command)
        {
            return _ticketHandler.Handler(command);
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

        [HttpPut("/ticket")]
        [AllowAnonymous]
        public object Delete([FromBody] UpdateTicketCommand command)
        {
            _ticketHandler.Handler(command);
            return true;
        }
    }
}
