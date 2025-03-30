
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Configuration;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration
{
    public interface IAppConfigurationsRepository
    {
        Task<AppConfiguration> GetAsync(string fieldName);
        Task UpdateAsync(string fieldName, string fieldValue);
    }
}