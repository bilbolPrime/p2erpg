using BilbolStack.Boonamai.P2ERPG.Business.Managers.Crypto;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;
using Microsoft.AspNetCore.Mvc;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly INFTScraperManager _nFTScraperManager;

        public CryptoController(ILogger<CryptoController> logger, INFTScraperManager nFTScraperManager)
        {
            _logger = logger;
            _nFTScraperManager = nFTScraperManager;
        }

        [HttpGet]
        public async Task Get()
        {
            await _nFTScraperManager.Tick();
        }
    }
}
