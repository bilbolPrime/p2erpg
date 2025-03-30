using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IAppConfigurationsRepository _appConfigurationsRepository;

        public ConfigurationManager(IAppConfigurationsRepository appConfigurationsRepository)
        {
            _appConfigurationsRepository = appConfigurationsRepository;
        }

        public async Task<string> GetConfiguration(string configurationName)
        {
            var result = await _appConfigurationsRepository.GetAsync(configurationName);
            return result == null ? null : result.FieldValue;
        }

        public async Task UpdateConfiguration(string configurationName, string configurationValue)
        {
            await _appConfigurationsRepository.UpdateAsync(configurationName, configurationValue);
        }
    }
}
