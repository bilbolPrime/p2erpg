using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Domain
{
    public static class DomainBootstrapper
    {
        public static void BootstrapDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAppConfigurationsRepository, AppConfigurationsMockRepository>();
        }
    }
}
