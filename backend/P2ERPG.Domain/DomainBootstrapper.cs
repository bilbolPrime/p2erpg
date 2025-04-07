using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Migrator;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Wallets;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Domain
{
    public static class DomainBootstrapper
    {
        public static void BootstrapDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAppConfigurationsRepository, AppConfigurationsRepository>();
            serviceCollection.AddTransient<IArmorsRepository, ArmorsMockRepository>();
            serviceCollection.AddTransient<IWeaponsRepository, WeaponsMockRepository>();
            serviceCollection.AddTransient<IShieldsRepository, ShieldsMockRepository>();
            serviceCollection.AddTransient<ICharactersRepository, CharactersMockRepository>();
            serviceCollection.AddTransient<ICharacterAssignedEquipmentRepository, CharacterAssignedEquipmentRepository>();
            serviceCollection.AddTransient<IWalletAccountRepository, WalletAccountRepository>();
            serviceCollection.AddTransient<IMigratorRepository, MigratorRepository>();
        }
    }
}
