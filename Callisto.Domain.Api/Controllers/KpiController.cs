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
        public Task<int> GetKpiValue()
        {
            return _repository.OpenTicketstotal();
        }

        [HttpGet("/v2/kpi")]
        [AllowAnonymous]
        public Task<Dictionary<int, int>> GetKpiValues()
        {
            return _repository.GetTicketsCountByStatusAsync();
        }
    }
}
