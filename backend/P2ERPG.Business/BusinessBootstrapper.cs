using BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Business
{
    public static class BusinessBootstrapper
    {
        public static void BootstrapBusiness(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfigurationManager, ConfigurationManager>();
            serviceCollection.AddSingleton<IHealthManager, HealthManager>();
        }
    }
}
