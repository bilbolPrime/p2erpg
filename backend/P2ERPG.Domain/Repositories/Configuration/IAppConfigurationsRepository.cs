
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Configuration;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration
{
    public interface IAppConfigurationsRepository
    {
        Task<AppConfiguration> Get(string fieldName);
        Task UpdateAppConfigs(string fieldName, string fieldValue);
    }
}