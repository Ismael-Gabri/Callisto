using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Company;
using Callisto.Domain.Handlers;
using Callisto.Domain.Infra.Repositories;
using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly CompanyHandler _handler;
        public CompanyController(ICompanyRepository repository, CompanyHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost("/companies")]
        [AllowAnonymous]
        public object Post([FromBody] CreateComapnyCommand command)
        {
            return _handler.Handler(command);
        }

        [HttpGet("/companies")]
        [AllowAnonymous]
        public object Get()
        {
            return _repository.GetAllCompanies();
        }

        [HttpGet("/companies/{id}")]
        [AllowAnonymous]
        public object GetById(int id)
        {
            return _repository.GetCompanyById(id);
        }

        [HttpDelete("/companies/{id}")]
        [AllowAnonymous]
        public object Delete(int id)
        {
            _repository.DeleteCompanyById(id);
            return true;
        }

        [HttpPut("/companies")]
        [AllowAnonymous]
        public object Delete([FromBody] UpdateCompanyCommand command)
        {
            _handler.Handler(command);
            return true;
        }
    }
}
