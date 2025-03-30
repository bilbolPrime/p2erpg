using BilbolStack.Boonamai.P2ERPG.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreYouAliveController : ControllerBase
    {
        private readonly ILogger<AreYouAliveController> _logger;

        public AreYouAliveController(ILogger<AreYouAliveController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<HealthResponse> Get()
        {
            return new HealthResponse(true);
        }
    }
}
