using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Configuration;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration
{
    public class AppConfigurationsRepository : BaseRepository<AppConfiguration>, IAppConfigurationsRepository
    {
        private const string GET_APP_CONFIG = "appconfigs_get";
        private const string UPDATE_APP_CONFIG = "appconfigs_update";

        public AppConfigurationsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task UpdateAppConfigs(string fieldName, string fieldValue)
        {
            var param = new
            {
                fieldName,
                fieldValue
            };

            await Execute(UPDATE_APP_CONFIG, param);
        }

        public virtual async Task<AppConfiguration> Get(string fieldName)
        {
            var param = new
            {
                fieldName
            };

            return (await GetList(GET_APP_CONFIG, param)).FirstOrDefault();
        }
    }
}
