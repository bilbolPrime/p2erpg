using BilbolStack.Boonamai.P2ERPG.Api.Models.Responses;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;
using Microsoft.AspNetCore.Mvc;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly ILogger<BattleController> _logger;
        private readonly IBattleManager _battleManager;

        public BattleController(ILogger<BattleController> logger, IBattleManager battleManager)
        {
            _logger = logger;
            _battleManager = battleManager;
        }

        [HttpGet]
        public async Task<BattleResult> Get()
        {
            return _battleManager.Battle((BattlePvP?) null);
        }
    }
}
