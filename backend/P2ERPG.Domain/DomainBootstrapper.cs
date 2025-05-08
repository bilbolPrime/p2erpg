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
            serviceCollection.AddTransient<IArmorsRepository, ArmorsRepository>();
            serviceCollection.AddTransient<IWeaponsRepository, WeaponsRepository>();
            serviceCollection.AddTransient<IShieldsRepository, ShieldsRepository>();
            serviceCollection.AddTransient<ICharactersRepository, CharactersRepository>();
            serviceCollection.AddTransient<ICharacterAssignedEquipmentRepository, CharacterAssignedEquipmentRepository>();
            serviceCollection.AddTransient<IWalletAccountRepository, WalletAccountRepository>();
            serviceCollection.AddTransient<IMigratorRepository, MigratorRepository>();
        }
    }
}
