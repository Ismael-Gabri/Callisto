using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Callisto.Domain.Infra;
using Callisto.Domain.Infra.Contexts;

namespace Callisto.Domain.Api.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly CallistoContext _context;

        public HealthController(CallistoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Testa conexão com o banco
                var canConnect = await _context.Database.CanConnectAsync();

                if (!canConnect)
                    return StatusCode(503, new
                    {
                        api = "online",
                        database = "offline"
                    });

                return Ok(new
                {
                    api = "online",
                    database = "online"
                });
            }
            catch
            {
                return StatusCode(503, new
                {
                    api = "online",
                    database = "offline"
                });
            }
        }
    }
}
