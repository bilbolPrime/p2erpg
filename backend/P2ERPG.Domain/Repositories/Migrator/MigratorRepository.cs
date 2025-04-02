using BilbolStack.Boonamai.P2ERPG.Common.Options;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Migrator
{
    public class MigratorRepository : BaseRepository<string>, IMigratorRepository
    {
        private const string SchemaCheck = "IF EXISTS (SELECT * FROM sys.schemas WHERE name = 'P2ERPG') BEGIN  select 1 END";
        public MigratorRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public async Task MigrateAsync(string script)
        {
            await Execute(script, null, System.Data.CommandType.Text);
        }

        public async Task<bool> SchemaExistsAsync()
        {
            return (await ExecuteScalar<string>(SchemaCheck, null, System.Data.CommandType.Text)) == "1";
        }
    }
}
