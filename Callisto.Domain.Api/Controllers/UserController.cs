using Callisto.Domain.Commands;
using Callisto.Domain.Commands.User_Commands.Input;
using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Callisto.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserHandler _handler;
        private readonly CallistoContext _context;
        public UserController(IUserRepository repository, UserHandler handler)
        {
            _userRepository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
        [FromServices] CallistoContext context,
        [FromBody] LoginCommand model)
        {
            var users = _userRepository.GetAllUsers();

            var user = users.FirstOrDefault(x => x.Email.Address == model.Email);
            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (result == PasswordVerificationResult.Failed)
                return BadRequest(new { message = "Senha inválida" });

            var token = TokenService.Generate(user);
            return new
            {
                user = user,
                token = token, //
            };
        }

        [HttpPost("/users")]
        [AllowAnonymous]
        public object Post([FromBody] CreateUserCommand command)
        {
            return _handler.Handler(command);
        }

        [HttpGet("/users")]
        [AllowAnonymous]
        public object Get()
        {
            return _userRepository.GetAllUsers();
        }

        [HttpGet("/users/{id}")]
        [AllowAnonymous]
        public object GetById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        [HttpDelete("/users/{id}")]
        [AllowAnonymous]
        public object Delete(int id)
        {
            _userRepository.DeleteUserById(id);
            return true;
        }

        [HttpPut("/users")]
        [AllowAnonymous]
        public object Delete([FromBody] UpdateUserCommand command)
        {
            _handler.Handler(command);
            return true;
        }
    }
}
