using BilbolStack.Boonamai.P2ERPG.Api.Models.Responses;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity;
using Microsoft.AspNetCore.Mvc;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SanityController : ControllerBase
    {
        private readonly ILogger<SanityController> _logger;
        private readonly IHealthManager _healthManager;

        public SanityController(ILogger<SanityController> logger, IHealthManager healthManager)
        {
            _logger = logger;
            _healthManager = healthManager;
        }

        [HttpGet]
        public async Task<HealthResponse> Get()
        {
            var check = await _healthManager.Check();
            return new HealthResponse(check.online, check.dbCanConnect);
        }
    }
}
