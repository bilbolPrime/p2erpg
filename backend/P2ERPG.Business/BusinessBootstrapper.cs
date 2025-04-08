using BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Armors;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Shields;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Weapons;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Migrations;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Security;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Wallets;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Business
{
    public static class BusinessBootstrapper
    {
        public static void BootstrapBusiness(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfigurationManager, ConfigurationManager>();
            serviceCollection.AddSingleton<IHealthManager, HealthManager>();
            serviceCollection.AddSingleton<ICharactersManager, CharactersManager>();
            serviceCollection.AddSingleton<IBattleManager, MockBattleManager>();
            serviceCollection.AddSingleton<IDBMigrationManager, DBMigrationManager>();
            serviceCollection.AddSingleton<IWeaponsManager, WeaponsManager>();
            serviceCollection.AddSingleton<IShieldsManager, ShieldsManager>();
            serviceCollection.AddSingleton<IArmorsManager, ArmorsManager>();
            serviceCollection.AddSingleton<IEquipmentsManager, EquipmentsManager>();
            serviceCollection.AddSingleton<ICharacterEquipmentManager, CharacterEquipmentManager>();
            serviceCollection.AddSingleton<IWalletsManager, WalletsManager>();
            serviceCollection.AddSingleton<ISecurityManager, SecurityManager>();
        }
    }
}
