
namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Migrator
{
    public interface IMigratorRepository
    {
        Task MigrateAsync(string script);
        Task<bool> SchemaExistsAsync();
    }
}