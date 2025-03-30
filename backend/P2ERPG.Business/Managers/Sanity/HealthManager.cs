
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Sanity;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity
{
    public class HealthManager : IHealthManager
    {
        private readonly IConfigurationManager _configurationManager;
        public HealthManager(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public async Task<HealthCheck> Check()
        {
            bool dbCheck = false;
            try
            {
                await _configurationManager.GetConfiguration(string.Empty);
                dbCheck = true;
            }
            catch
            {
                dbCheck = false;
            }

            return new HealthCheck(true, dbCheck);
        }
    }
}
