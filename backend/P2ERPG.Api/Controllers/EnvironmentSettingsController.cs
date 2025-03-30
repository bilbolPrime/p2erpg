using BilbolStack.Boonamai.P2ERPG.Api.Models.Responses;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentSettingsController : ControllerBase
    {
        private readonly ILogger<EnvironmentSettingsController> _logger;
        private readonly EnvironmentSettings _environmentSettings;
        public EnvironmentSettingsController(IOptions<EnvironmentSettings> envSettings, ILogger<EnvironmentSettingsController> logger)
        {
            _logger = logger;
            _environmentSettings = envSettings.Value;
        }

        [HttpGet]
        public async Task<EnvironmentSettingsResponse> Get()
        {
            return new EnvironmentSettingsResponse(_environmentSettings.Version ?? "Missing Version", _environmentSettings.Environment ?? "Missing Environment");
        }
    }
}
