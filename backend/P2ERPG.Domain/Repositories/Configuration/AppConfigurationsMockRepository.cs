using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Configuration;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration
{
    public class AppConfigurationsMockRepository : AppConfigurationsRepository
    {

        public AppConfigurationsMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public override async Task UpdateAsync(string fieldName, string fieldValue)
        {
            await Task.CompletedTask;
        }

        public override async Task<AppConfiguration> GetAsync(string fieldName)
        {
            return new AppConfiguration() { AppConfigurationId = 1, FieldName = fieldName, FieldValue = fieldName };
        }
    }
}
