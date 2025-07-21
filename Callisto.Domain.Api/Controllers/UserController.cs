using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserHandler _handler;
        public UserController(IUserRepository repository, UserHandler handler)
        {
            _userRepository = repository;
            _handler = handler;
        }

        [HttpGet("/users")]
        [AllowAnonymous]
        public object Get()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
