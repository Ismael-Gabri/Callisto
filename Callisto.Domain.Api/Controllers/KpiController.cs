using Callisto.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    public class KpiController : ControllerBase
    {
        private readonly IKpiRepository _repository;

        public KpiController(IKpiRepository kpiRepository)
        {
            _repository = kpiRepository;
        }

        [HttpGet("/kpi")]
        [AllowAnonymous]
        public Task<int> GetKpiValues()
        {
            return _repository.OpenTicketstotal();
        }
    }
}
