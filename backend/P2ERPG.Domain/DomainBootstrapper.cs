using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Domain
{
    public static class DomainBootstrapper
    {
        public static void BootstrapDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAppConfigurationsRepository, AppConfigurationsMockRepository>();
            serviceCollection.AddTransient<IArmorRepository, ArmorMockRepository>();
            serviceCollection.AddTransient<IWeaponsRepository, WeaponsMockRepository>();
            serviceCollection.AddTransient<IShieldsRepository, ShieldsMockRepository>();
            serviceCollection.AddTransient<ICharactersRepository, CharactersMockRepository>();
        }
    }
}
