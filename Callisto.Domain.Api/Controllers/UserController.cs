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
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;
        public UserController(UserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet("/users")]
        [AllowAnonymous]
        public object Get()
        {
            return _repository.GetAllUsers();
        }
    }
}
