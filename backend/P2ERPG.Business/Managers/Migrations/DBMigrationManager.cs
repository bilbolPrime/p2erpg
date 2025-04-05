using BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Migrator;
using MoreLinq;
using System;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Migrations
{
    public class DBMigrationManager : IDBMigrationManager
    {
        private const string MigrationAt = "DB_MIGRATION_AT";
        private readonly IConfigurationManager _configurationManager;
        private readonly IMigratorRepository _migratorRepository;

        public DBMigrationManager(IConfigurationManager configurationManager, IMigratorRepository migratorRepository)
        {
            _configurationManager = configurationManager;
            _migratorRepository = migratorRepository;
        }

        public async Task Migrate()
        {
            var schemaExists = await _migratorRepository.SchemaExistsAsync();
            var migrationAt = !schemaExists ? 0 : int.Parse(await _configurationManager.GetConfiguration(MigrationAt));

            Assembly domainAssembly = AppDomain.CurrentDomain.GetAssemblies().
                                    Single(assembly => assembly.GetName().Name == "BilbolStack.Boonamai.P2ERPG.Domain");
            var sqlFiles = domainAssembly.GetManifestResourceNames();
            var filesSorted = sqlFiles.Select(x => new { ordinal = int.Parse(x.Replace("BilbolStack.Boonamai.P2ERPG.Domain.Migrations.", "").Split('_')[0]), file = x });

            foreach (var file in filesSorted.OrderBy(i => i.ordinal).Skip(migrationAt))
            {
                using (Stream stream = domainAssembly.GetManifestResourceStream(file.file))
                using (StreamReader reader = new StreamReader(stream))
                {
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        foreach (var batch in reader.ReadToEnd().Split("GO"))
                        {
                            StringBuilder sb = new StringBuilder();
                            batch.Split("\r\n").ForEach(i => sb.AppendLine(i));
                            var result = sb.ToString().Trim();
                            if (string.IsNullOrEmpty(result)) continue;
                            await _migratorRepository.MigrateAsync(result);
                        }
                        await _configurationManager.UpdateConfiguration(MigrationAt, (++migrationAt).ToString());
                        scope.Complete();
                    }
                }
            }
        }
    }
}
